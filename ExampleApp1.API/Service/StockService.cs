using ExampleApp1.API.Data;
using ExampleApp1.API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExampleApp1.API.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task AddAsync(Stock entity)
        {
             await _stockRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _stockRepository.GetAllAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _stockRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Stock>> Where(Expression<Func<Stock, bool>> predicate)
        {
            var list = _stockRepository.Where(predicate);

            return await list.ToListAsync();
        }
    }
}
