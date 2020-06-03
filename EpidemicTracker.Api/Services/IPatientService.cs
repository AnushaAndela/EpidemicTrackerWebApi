using EpidemicTracker.Api.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientAsync(int id);
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<IEnumerable<TreatmentDto>> GetCuredPatients();
        Task<IEnumerable<TreatmentDto>> GetUnCuredPatients();
        Task<IEnumerable<TreatmentDto>> GetFatilityCount();
        
        Task PostPatientAsync(PatientDto patientDto);
        Task DeletePatientAsync(int id);

    }
}
