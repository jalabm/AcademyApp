using System;
using Academy.Core.Models.BaseModels;
using Academy.Core.Repositories;

namespace Academy.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T:BaseModel
    {
        List<T> values = new List<T>();
        public async Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync(Func<T, bool> func)
        {
            throw new NotImplementedException();
        }

        public async Task GetAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

