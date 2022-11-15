using AutoMapper;
using HealthCare.Appointments.Api.Dtos;
using HealthCare.Appointments.Api.Models;

namespace HealthCare.Appointments.Api.Configuraitons
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<Appointment, AppointmentDetailsDto>();
        }
    }
}
