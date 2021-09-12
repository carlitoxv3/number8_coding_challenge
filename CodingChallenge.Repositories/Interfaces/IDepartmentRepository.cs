using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Repositories.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Models.Department>, IDisposable
    {
    }
}
