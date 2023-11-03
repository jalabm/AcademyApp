using System;
using Academy.Core.Models;

namespace Academy.Core.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetAsync(Func<object, bool> value);
    }
}

