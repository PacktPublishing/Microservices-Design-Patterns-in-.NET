namespace HealthCare.Appointments.Api.Constants
{
    public class ApiEndpoints
    {
        public ApiEndpoints(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
       
        private const string Documents = "/documents";
        private const string Doctors = "/doctors";
        private const string Patients = "/patients";
        private readonly IConfiguration configuration;

        public string GetDocumentsApi()
        {
            return configuration["ApiEndpoints:DocumentsApi"] + Documents;
        }

        public string GetDoctorsApi()
        {
            return configuration["ApiEndpoints:DoctorsApi"] + Doctors;
        }

        public string GetPatientsApi()
        {
            return configuration["ApiEndpoints:PatientsApi"] + Patients;
        }
    }
}
