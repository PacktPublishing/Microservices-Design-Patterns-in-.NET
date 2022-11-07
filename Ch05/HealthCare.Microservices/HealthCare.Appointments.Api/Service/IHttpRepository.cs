namespace HealthCare.Appointments.Api.Service
{
    public interface IHttpRepository<T> where T : class
    {
        Task<T> Get(string url, string id);
        Task<T> GetDetails(string url, string id);
        Task<List<T>> GetAll(string url);
        Task Create(string url, T obj);
        Task Update(string url, T obj, string id);
        Task Delete(string url, string id);
    }
}
