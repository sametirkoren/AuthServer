using ExampleApp1.API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExampleApp1.API.Data
{
    public class StockRepository : IStockRepository
    {
        private readonly ExampleApp1Context _context;

        public StockRepository(ExampleApp1Context context)
        {
            _context = context;
          
        }
        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await _context.Set<Stock>().ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            var entity = await _context.Set<Stock>().FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task AddAsync(Stock entity)
        {
            await _context.Set<Stock>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Stock> Where(Expression<Func<Stock, bool>> predicate)
        {
            return _context.Set<Stock>().Where(predicate);
        }

       
    }
}
