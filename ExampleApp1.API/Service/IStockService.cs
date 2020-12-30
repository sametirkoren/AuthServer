using ExampleApp1.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExampleApp1.API.Service
{
    public interface IStockService
    {
        Task<Stock> GetByIdAsync(int id);

        Task<IEnumerable<Stock>> GetAllAsync();

        Task<IEnumerable<Stock>> Where(Expression<Func<Stock, bool>> predicate);

        Task AddAsync(Stock entity);
    }
}
