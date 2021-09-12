using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Models.Order>, IDisposable
    {
    }
}
