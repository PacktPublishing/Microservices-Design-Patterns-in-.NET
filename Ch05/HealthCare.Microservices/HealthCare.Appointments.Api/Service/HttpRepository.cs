namespace HealthCare.Appointments.Api.Service
{
    public class HttpRepository<T> : IHttpRepository<T> where T : class
    {
        private readonly HttpClient _client;

        public HttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task Create(string url, T obj)
        {
            await _client.PostAsJsonAsync(url, obj);
        }

        public async Task Delete(string url, string id)
        {

            await _client.DeleteAsync($"{url}/{id}");
        }

        public async Task<T> Get(string url, string id)
        {
            return await _client.GetFromJsonAsync<T>($"{url}/{id}");
        }

        public async Task<T> GetDetails(string url, string id)
        {
            return await _client.GetFromJsonAsync<T>($"{url}/{id}/details");
        }

        public async Task<List<T>> GetAll(string url)
        {
            return await _client.GetFromJsonAsync<List<T>>($"{url}");
        }

        public async Task Update(string url, T obj, string id)
        {
            await _client.PutAsJsonAsync($"{url}/{id}", obj);
        }
    }
}
