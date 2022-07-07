namespace HealthCare.Appointments.Api.Service
{
    public interface IHttpRepository<T> where T : class
    {
        Task<T> Get(string url, int id);
        Task<T> GetDetails(string url, int id);
        Task<List<T>> GetAll(string url);
        Task Create(string url, T obj);
        Task Update(string url, T obj, int id);
        Task Delete(string url, int id);
    }
}
