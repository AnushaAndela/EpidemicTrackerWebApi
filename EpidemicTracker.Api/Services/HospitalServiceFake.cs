using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class HospitalServiceFake : IHospitalService
    {
        private readonly List<HospitalDto> _hospitals;
        public HospitalServiceFake()
        {
            _hospitals = new List<HospitalDto>()
            {
                new HospitalDto()
                {
                    HospitalDtoId=1,
                    Name="Yashoda",
                    Phone=9878767652,
                    StreetNo="12-3-4",
                    Area="Kothapet",
                    City="Hyderabd",
                    Country="India",
                    Pincode=987654
                },
                new HospitalDto()
                {
                    HospitalDtoId=2,
                    Name="Apollo",
                    Phone=9878767652,
                    StreetNo="12-3-4",
                    Area="Kothapet",
                    City="Hyderabd",
                    Country="India",
                    Pincode=987654
                },
                new HospitalDto()
                {
                    HospitalDtoId=3,
                    Name="Yashoda",
                    Phone=9878767652,
                    StreetNo="12-3-4",
                    Area="Kothapet",
                    City="Hyderabd",
                    Country="India",
                    Pincode=987654
                }
            };
        }
        public async Task DeleteHospitalAsync(int id)
        {
            var existing = _hospitals.First(a => a.HospitalDtoId == id);
            _hospitals.Remove(existing);
        }

        public async Task<IList<HospitalDto>> GetAllAsync()
        {

            return  _hospitals;

        }
        

        public async Task<HospitalDto> GetHospitalAsync(int id)
        {
            return _hospitals.Where(a => a.HospitalDtoId == id)
         .FirstOrDefault();
        }

        public Task PostHospitalAsync(HospitalDto hospitalDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHospitalAsync(int id, HospitalDto hospitalDto)
        {
            throw new NotImplementedException();
        }
    }
}
