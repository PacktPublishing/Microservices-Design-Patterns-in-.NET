using HealthCare.Appointments.Api.Models;
using System.Text.Json;

namespace HealthCare.Appointments.Api.Service
{
    public class PatientsApiRepository : IPatientsApiRepository
    {
        private readonly HttpClient _httpClient;

        public PatientsApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Patient> GetPatient(string id)
        {
            var response = await _httpClient.GetAsync($"api/Patients/{id}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <Patient>(responseStream);
        }

        public async Task<List<Patient>> GetPatients()
        {
            var response = await _httpClient.GetAsync("api/Patients");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <List<Patient>>(responseStream);
        }
    }
}
