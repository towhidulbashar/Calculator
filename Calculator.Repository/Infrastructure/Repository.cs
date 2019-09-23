using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Repository.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> entities;
        protected readonly CalculatorDbContext calculatorDbContext;

        public Repository(CalculatorDbContext calculatorDbContext)
        {
            entities = calculatorDbContext.Set<T>();
            this.calculatorDbContext = calculatorDbContext;
        }

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> addEntities)
        {
            entities.AddRange(addEntities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync(IList<string> includes = null)
        {
            IQueryable<T> query = entities;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = entities.Include(include);
                }
            }
            return await query
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await entities.FindAsync(id);
        }

        public void Remove(T entity)
        {
            entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> removeEntities)
        {
            entities.RemoveRange(removeEntities);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }
    }
}
