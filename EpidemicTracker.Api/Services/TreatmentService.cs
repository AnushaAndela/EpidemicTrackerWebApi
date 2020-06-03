using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class TreatmentService : ITreatmentService
    {
        private EpidemicTrackerContext _context;
        public TreatmentService(EpidemicTrackerContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<TreatmentDto>> GetAllAsync()
        {
            var patients = from a in _context.Treatment
                                      .Include(a => a.Patient)
                                      .Include(a => a.Disease)
                                      .Include(a => a.Hospital)
                           select new TreatmentDto()
                           {
                               TreatmentDtoId = a.TreatmentId,
                               AdmittedDate = a.AdmittedDate,
                               PercentageCure = a.PercentageCure,
                               RelievingDate = a.RelievingDate,
                               DiseaseDto = new DiseaseDto
                               {
                                   DiseaseDtoId = a.Disease.DiseaseId,
                                   Name = a.Disease.Name
                               },
                               HospitalDto = new HospitalDto
                               {
                                   HospitalDtoId = a.Hospital.HospitalId,
                                   Name = a.Hospital.Name
                               },

                               PatientDto = new PatientDto
                               {
                                   Name = a.Patient.Name,
                                   Age = a.Patient.Age,
                                   Gender = a.Patient.Gender,
                                   Phone = a.Patient.Phone,
                                   AadharId = a.Patient.AadharId,
                                   IsAffected = a.Patient.IsAffected,
                                   Addresses = (from b in a.Patient.Address
                                                select new AddressDto
                                                {
                                                    AddressType = b.AddressType,
                                                    Hno = b.Hno,
                                                    Street = b.Street,
                                                    City = b.City,
                                                    State = b.State,
                                                    Country = b.Country

                                                }).ToList()

                               }

                           };
        

            return patients;
        }
    }
}
