using EpidemicTracker.Api.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IDiseaseService
    {
        Task<IEnumerable<DiseaseDto>> GetAllAsync();
        Task<DiseaseDto> GetDiseaseAsync(int id);
        Task PostDiseaseAsync(DiseaseDto diseaseDto);
    }
}
