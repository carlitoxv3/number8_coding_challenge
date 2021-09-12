using CodingChallenge.Models.DTOs.Request;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace CodingChallenge.UnitTests.Orders
{
    public class OrderTest
    {
        /// <summary>
        /// Based in Input 1 of challenge
        /// </summary>
        [Fact]
        public async void Input_1()
        {
            using (var server = new TestContext())
            {
                CodingChallenge.Services.Interfaces.IOrderService orderService = server.ServiceProvider.GetRequiredService<CodingChallenge.Services.Interfaces.IOrderService>();

                Models.DTOs.Request.OrderRequestDTO orderRequestDTO = new Models.DTOs.Request.OrderRequestDTO();
                orderRequestDTO.Products = new List<ProductRequestDTO>();

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "book",
                    Description = "Book",
                    Price = 12.49,
                    IsImported = false,
                    DepartmentID = 1
                });

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "book",
                    Description = "Book",
                    Price = 12.49,
                    IsImported = false,
                    DepartmentID = 1
                });

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "cd",
                    Description = "Music CD",
                    Price = 14.99,
                    IsImported = false,
                    DepartmentID = 4
                });

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "chbar",
                    Description = "Chocolate bar",
                    Price = 0.85,
                    IsImported = false,
                    DepartmentID = 2
                });

                var orderResponse = await orderService.Calculate(orderRequestDTO);

                Assert.Equal(42.32, orderResponse.Total);
                Assert.Equal(1.50, orderResponse.SalesTaxes);

            }
        }

        /// <summary>
        /// Based in Input 2 of challenge
        /// </summary>
        [Fact]
        public async void Input_2()
        {
            using (var server = new TestContext())
            {
                CodingChallenge.Services.Interfaces.IOrderService orderService = server.ServiceProvider.GetRequiredService<CodingChallenge.Services.Interfaces.IOrderService>();

                Models.DTOs.Request.OrderRequestDTO orderRequestDTO = new Models.DTOs.Request.OrderRequestDTO();
                orderRequestDTO.Products = new List<ProductRequestDTO>();

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "perfume",
                    Description = "bootle of perfume",
                    Price = 47.50,
                    IsImported = true,
                    DepartmentID = 4
                });


                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "chbar",
                    Description = "Chocolate bar",
                    Price = 10,
                    IsImported = true,
                    DepartmentID = 2
                });

                var orderResponse = await orderService.Calculate(orderRequestDTO);

                Assert.Equal(65.15, orderResponse.Total);
                Assert.Equal(7.65, orderResponse.SalesTaxes);

            }
        }

        /// <summary>
        /// Based in Input 3 of challenge
        /// </summary>
        [Fact]
        public async void Input_3()
        {
            using (var server = new TestContext())
            {
                CodingChallenge.Services.Interfaces.IOrderService orderService = server.ServiceProvider.GetRequiredService<CodingChallenge.Services.Interfaces.IOrderService>();

                Models.DTOs.Request.OrderRequestDTO orderRequestDTO = new Models.DTOs.Request.OrderRequestDTO();
                orderRequestDTO.Products = new List<ProductRequestDTO>();

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "perfume",
                    Description = "bootle of perfume",
                    Price = 27.99,
                    IsImported = true,
                    DepartmentID = 4
                });

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "perfume",
                    Description = "bootle of perfume",
                    Price = 18.99,
                    IsImported = false,
                    DepartmentID = 4
                });


                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "headache",
                    Description = "Packet of headache",
                    Price = 9.75,
                    IsImported = false,
                    DepartmentID = 3
                });


                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "chbar",
                    Description = "Chocolate bar",
                    Price = 11.25,
                    IsImported = true,
                    DepartmentID = 2
                });

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "chbar",
                    Description = "Chocolate bar",
                    Price = 11.25,
                    IsImported = true,
                    DepartmentID = 2
                });

                var orderResponse = await orderService.Calculate(orderRequestDTO);

                Assert.Equal(86.53, orderResponse.Total);
                Assert.Equal(7.30, orderResponse.SalesTaxes);

            }
        }

        /// <summary>
        /// Evaluates the case that insert a product with a department that doesn't exists, must generate an MissingMemberException
        /// </summary>
        [Fact]
        public async void SaveAndCalculate_InputWithWrongDepartment_ThrowsMissingMemberException()
        {
            using (var server = new TestContext())
            {
                CodingChallenge.Services.Interfaces.IOrderService orderService = server.ServiceProvider.GetRequiredService<CodingChallenge.Services.Interfaces.IOrderService>();

                Models.DTOs.Request.OrderRequestDTO orderRequestDTO = new Models.DTOs.Request.OrderRequestDTO();
                orderRequestDTO.Products = new List<ProductRequestDTO>();


                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "chbar",
                    Description = "Chocolate bar",
                    Price = 11.25,
                    IsImported = true,
                    DepartmentID = 6
                });


                await Assert.ThrowsAsync<MissingMemberException>(async () => await orderService.Calculate(orderRequestDTO));

            }
        }

        /// <summary>
        /// Evaluates the case that doesn't have products, must generate an InvalidOperationException
        /// </summary>
        [Fact]
        public async void SaveAndCalculate_InputWithoutProducts_ThrowsInvalidOperationException()
        {
            using (var server = new TestContext())
            {
                CodingChallenge.Services.Interfaces.IOrderService orderService = server.ServiceProvider.GetRequiredService<CodingChallenge.Services.Interfaces.IOrderService>();

                Models.DTOs.Request.OrderRequestDTO orderRequestDTO = new Models.DTOs.Request.OrderRequestDTO();
                orderRequestDTO.Products = new List<ProductRequestDTO>();

                await Assert.ThrowsAsync<InvalidOperationException>(async () => await orderService.Calculate(orderRequestDTO));

            }
        }

        [Fact]
        public async void Input4()
        {
            using (var server = new TestContext())
            {
                CodingChallenge.Services.Interfaces.IOrderService orderService = server.ServiceProvider.GetRequiredService<CodingChallenge.Services.Interfaces.IOrderService>();

                Models.DTOs.Request.OrderRequestDTO orderRequestDTO = new Models.DTOs.Request.OrderRequestDTO();
                orderRequestDTO.Products = new List<ProductRequestDTO>();

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "perfume",
                    Description = "bootle of perfume",
                    Price = 27.99,
                    IsImported = true,
                    DepartmentID = 4
                });

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "headache",
                    Description = "Packet of headache",
                    Price = 9.75,
                    IsImported = true,
                    DepartmentID = 3
                });


                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "chbar",
                    Description = "Chocolate bar",
                    Price = 11.25,
                    IsImported = true,
                    DepartmentID = 2
                });

                orderRequestDTO.Products.Add(new ProductRequestDTO()
                {
                    Code = "chbar",
                    Description = "Chocolate bar",
                    Price = 11.25,
                    IsImported = false,
                    DepartmentID = 2
                });

                var orderResponse = await orderService.Calculate(orderRequestDTO);

                Assert.Equal(65.54, orderResponse.Total);
                Assert.Equal(5.3, orderResponse.SalesTaxes);

            }
        }
    }
}
