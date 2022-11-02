using HealthCare.SharedAssets.DataPaging;

namespace HealthCare.Patients.Api.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<PagedResult<T>> GetAllAsync(QueryParameters queryParameters);
    }

}
