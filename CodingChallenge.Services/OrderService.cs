using CodingChallenge.Models;
using CodingChallenge.Services.Extensions;
using CodingChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Services
{
    public partial class OrderService : IOrderService
    {
        private Repositories.Interfaces.IOrderRepository _orderRepository;
        private Services.Interfaces.ITaxService _taxService;
        private Services.Interfaces.IDepartmentService _departmentService;
        private Repositories.DBContexts.LocalDBContext _localDBContext;
        public OrderService(
            Repositories.DBContexts.LocalDBContext localDBContext,
             Services.Interfaces.IDepartmentService departmentService,
             Services.Interfaces.ITaxService taxService
            )
        {
            _localDBContext = localDBContext;
            _departmentService = departmentService;
            _taxService = taxService;
        }

        public async Task<Models.DTOs.Response.OrderSummaryResponseDTO> SaveAndCalculate(Models.DTOs.Request.OrderRequestDTO orderRequestDTO)
        {
            //Avoid to use Automapper beacause is a simple mapping
            try
            {
                // Validate that contains a least one product
                if (orderRequestDTO.Products == null || (orderRequestDTO.Products != null && !orderRequestDTO.Products.Any()))
                    throw new InvalidOperationException("The order must contains almost one product");

                var productosToSave = orderRequestDTO.Products.Select(p => new Models.Product()
                {
                    DepartmentID = p.DepartmentID,
                    Description = p.Description,
                    Code = p.Code,
                    Price = p.Price,
                    Imported = p.IsImported
                });

                Models.Order order = new Order();
                order.Products = productosToSave;

                //Save into DB
                //this._orderRepository.Insert(order);
                //await this._orderRepository.Save();

                Models.DTOs.Response.OrderSummaryResponseDTO orderResponseDTO = new Models.DTOs.Response.OrderSummaryResponseDTO();


                var productsImportedGroup = order.Products.GroupBy(p => p.Imported);
                foreach (var groupImportedOrNot in productsImportedGroup)
                {
                    var productSummaryResponseDTOs = await this.getInternalCostAndTaxes(groupImportedOrNot.ToList(), groupImportedOrNot.Key);

                    orderResponseDTO.Products.AddRange(productSummaryResponseDTOs);
                }



                return orderResponseDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IList<Models.DTOs.Response.ProductSummaryResponseDTO>> getInternalCostAndTaxes(IList<Product> products, bool areImported = false)
        {
            var productsDescriptionGroup = products.GroupBy(p => p.Code.ToLower());
            IList<Models.DTOs.Response.ProductSummaryResponseDTO> productSummaryResponseDTOs = new List<Models.DTOs.Response.ProductSummaryResponseDTO>();
            IEnumerable<Models.Tax> taxesImported = new List<Models.Tax>();

            if (areImported)
                taxesImported = await this._taxService.GetAllForImported();

            foreach (var groupDescription in productsDescriptionGroup)
            {
                Models.DTOs.Response.ProductSummaryResponseDTO productSummaryResponseDTO = new Models.DTOs.Response.ProductSummaryResponseDTO();

                int departmentID = groupDescription.FirstOrDefault().DepartmentID;
                var departmentFromDB = await _departmentService.GetByID(departmentID);
                if (departmentFromDB == null)
                    throw new MissingMemberException($"The department {departmentID} doesn't exists. Please check and try again.");

                double taxValueToApply = departmentFromDB.Taxes != null ? departmentFromDB.Taxes.Sum(s => s.Value) : 0;

                //In case that are imported and exists some tax to apply, must aggregate
                if (taxesImported != null && taxesImported.Any())
                    taxValueToApply += taxesImported.Sum(s => s.Value);

                productSummaryResponseDTO.DepartmentName = departmentFromDB.Name;
                productSummaryResponseDTO.Description = groupDescription.Key;
                productSummaryResponseDTO.Count = groupDescription.Count();
                productSummaryResponseDTO.Imported = areImported;

                var price = groupDescription.Max(p => p.Price);
                double priceTaxes = 0;
                if (taxValueToApply > 0)
                    priceTaxes = price * (taxValueToApply / 100);

                priceTaxes = priceTaxes.RoundCentimalTo(0.05);

                productSummaryResponseDTO.TaxTotal = Math.Round(priceTaxes * productSummaryResponseDTO.Count, 2);
                productSummaryResponseDTO.UnitPrice = Math.Round(price + priceTaxes, 2);
                productSummaryResponseDTO.PriceTotal = productSummaryResponseDTO.UnitPrice * productSummaryResponseDTO.Count;

                productSummaryResponseDTOs.Add(productSummaryResponseDTO);
            }

            return productSummaryResponseDTOs;

        }


    }
}
