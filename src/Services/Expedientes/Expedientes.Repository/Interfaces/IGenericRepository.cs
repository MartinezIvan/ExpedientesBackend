using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expedientes.Repository.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;

    namespace Iam.Repository.Interfaces
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<IList<T>> GetAll();
            Task<IList<T>> GetAllIncludingRelations();
            Task<T> GetById(int id);
            Task<ICollection<T>> GetByCriteria(Expression<Func<T, bool>> predicate);
            Task<T> Insert(T entity);
            Task<T> Update(T entity);
            Task<bool> Delete(int id);
            Task UpdateRange(ICollection<T> entities);
            Task RemoveRange(ICollection<T> entities);
            Task<ICollection<T>> AddRange(ICollection<T> entities);
        }

        public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            private readonly AppExpedientesContext _context;
            public GenericRepository(AppExpedientesContext context)
            {
                _context = context;
            }

            public async Task<IList<T>> GetAll()
            {
                return await _context.Set<T>().ToListAsync();
            }

            public async Task<IList<T>> GetAllIncludingRelations()
            {
                var query = _context.Set<T>().AsQueryable();

                var navigationProperties = _context.Model.FindEntityType(typeof(T))
                                                .GetNavigations()
                                                .Select(navigation => navigation.Name);

                foreach (var propertyName in navigationProperties)
                {
                    query = query.Include(propertyName);
                }

                return await query.ToListAsync();
            }

            public async Task<ICollection<T>> GetByCriteria(Expression<Func<T, bool>> predicate)
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }


            public async Task<T> GetById(int id)
            {
                var entity = await _context.Set<T>().FindAsync(id);

                if (entity == null)
                {
                    return null;
                }

                return entity;
            }

            public async Task<bool> Delete(int id)
            {
                var entity = await GetById(id);

                if (entity == null)
                {
                    return false;
                }
                _context.Set<T>().Remove(entity);
                return true;
            }

            public async Task<T> Insert(T entity)
            {
                await _context.Set<T>().AddAsync(entity);
                return entity;
            }

            public async Task<T> Update(T entity)
            {
                _context.Set<T>().Update(entity);
                return entity;
            }

            public async Task RemoveRange(ICollection<T> entities)
            {
                _context.Set<T>().RemoveRange(entities);
            }
            public async Task UpdateRange(ICollection<T> entities)
            {
                _context.Set<T>().UpdateRange(entities);
            }
            public async Task<ICollection<T>> AddRange(ICollection<T> entities)
            {
                await _context.Set<T>().AddRangeAsync(entities);
                return entities;
            }
        }
    }

}
