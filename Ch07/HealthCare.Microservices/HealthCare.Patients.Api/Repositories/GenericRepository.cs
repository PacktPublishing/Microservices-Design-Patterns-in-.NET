using HealthCare.Patients.Api.Models;
using HealthCare.SharedAssets.DataPaging;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Patients.Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PatientsDatabaseContext _context;

        public GenericRepository(PatientsDatabaseContext context)
        {
            this._context = context;
        }

        public async Task Delete(int id)
        {
            var entity = await GetAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagedResult<T>> GetAllAsync(QueryParameters queryParameters)
        {
            var totalSize = await _context.Set<T>().CountAsync();
            var items = await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize
            };
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }


}
