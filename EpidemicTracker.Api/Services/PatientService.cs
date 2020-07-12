using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class PatientService : IPatientService
    {
        private EpidemicTrackerContext _context;
        public PatientService(EpidemicTrackerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var patients =_context.Patient
                 .Include(x => x.Address)
                 .Include(x => x.Occupation)
                 .Include(x=>x.Treatment)
                 .Select(a => new PatientDto()
                 {
                     PatientDtoId = a.PatientId,
                     Name = a.Name,
                     Age = a.Age,
                     Gender = a.Gender,
                     Phone = a.Phone,
                     AadharId = a.AadharId,
                     IsAffected = a.IsAffected,
                     Addresses = a.Address.Select(b => new AddressDto()
                     {
                         AddressDtoId = b.AddressId,
                         AddressType = b.AddressType,
                         Hno = b.Hno,
                         Street = b.Street,
                         City = b.City,
                         State = b.State,
                         Country = b.Country,
                         Pincode = b.Pincode
                     }).ToList(),
                     Occupations = a.Occupation.Select(o => new OccupationDto()
                     {
                         OccupationDtoId = o.OccupationId,
                         Name = o.Name,
                         Phone = o.Phone,
                         StreetNo = o.StreetNo,
                         Area = o.Area,
                         City = o.City,
                         State = o.State,
                         Country = o.Country,
                         Pincode = o.Pincode

                     }).ToList(),
                     Treatments = a.Treatment.Select(t => new TreatmentDto()
                     {
                         TreatmentDtoId = t.TreatmentId,
                         AdmittedDate = t.AdmittedDate,
                         PercentageCure = t.PercentageCure,
                         RelievingDate = t.RelievingDate,
                         Isfatility = t.Isfatility
                     }).ToList()
                 });


            return patients;
        }
        public async Task<PatientDto> GetPatientAsync(int id)
        {
            var patients = _context.Patient
                .Include(x => x.Address)
                .Include(x => x.Occupation)
                
                .Select(a => new PatientDto()
                {
                    PatientDtoId = a.PatientId,
                    Name = a.Name,
                    Age = a.Age,
                    Gender = a.Gender,
                    Phone = a.Phone,
                    AadharId = a.AadharId,
                    IsAffected = a.IsAffected,
                    Addresses = a.Address.Select(b => new AddressDto()
                    {
                        AddressDtoId = b.AddressId,
                        AddressType = b.AddressType,
                        Hno = b.Hno,
                        Street = b.Street,
                        City = b.City,
                        State = b.State,
                        Country = b.Country,
                        Pincode=b.Pincode
                    }).ToList(),
                    Occupations=a.Occupation.Select(o=>new OccupationDto()
                    {
                        OccupationDtoId = o.OccupationId,
                        Name = o.Name,
                        Phone = o.Phone,
                        StreetNo = o.StreetNo,
                        Area = o.Area,
                        City = o.City,
                        State = o.State,
                        Country = o.Country,
                        Pincode = o.Pincode

                    }).ToList(),
                    Treatments=a.Treatment.Select(t=>new TreatmentDto()
                    {
                        TreatmentDtoId = t.TreatmentId,
                        AdmittedDate = t.AdmittedDate,
                        PercentageCure = t.PercentageCure,
                        RelievingDate = t.RelievingDate,
                        Isfatility = t.Isfatility
                    } ).ToList()
                }) ;

        

            return await patients.FirstOrDefaultAsync(x => x.PatientDtoId == id);

        }

        public IEnumerable<TreatmentDto> GetCuredPatients()
        {

            var curedList = (from t in _context.Treatment
                 .Include(x => x.Patient)
                 .Include(x => x.Disease)
                 .Where(x => x.PercentageCure >= 100 && x.Disease.Name == "COVID")

                 
                             select new TreatmentDto()
                             {
                                 AdmittedDate = t.AdmittedDate,
                                 PercentageCure = t.PercentageCure,
                                 RelievingDate = t.RelievingDate,
                                 Isfatility = t.Isfatility,
                                 DiseaseDto = new DiseaseDto
                                 {
                                     DiseaseDtoId = t.Disease.DiseaseId,
                                     Name = t.Disease.Name
                                 },
                                 HospitalDto = new HospitalDto
                                 {
                                     HospitalDtoId = t.Hospital.HospitalId,
                                     Name = t.Hospital.Name
                                 },

                                 PatientDto = new PatientDto
                                 {
                                     Name = t.Patient.Name,
                                     Age = t.Patient.Age,
                                     Gender = t.Patient.Gender,
                                     Phone = t.Patient.Phone,
                                     AadharId = t.Patient.AadharId,
                                     IsAffected = t.Patient.IsAffected,
                                     Addresses = (from b in t.Patient.Address
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

                             }).ToList();



            return curedList;

        }

        public IEnumerable<TreatmentDto> GetUnCuredPatients()
        {


            var uncuredList = (from t in _context.Treatment
                 .Include(x => x.Patient)
                 .Include(x => x.Disease)
                 .Where(x => x.Patient.IsAffected == "Yes" && x.Disease.Name == "COVID")
                               select new TreatmentDto()
                               {
                                   AdmittedDate = t.AdmittedDate,
                                   PercentageCure = t.PercentageCure,
                                   RelievingDate = t.RelievingDate,
                                   Isfatility = t.Isfatility,
                                   DiseaseDto = new DiseaseDto
                                   {
                                       DiseaseDtoId = t.Disease.DiseaseId,
                                       Name = t.Disease.Name
                                   },
                                   HospitalDto = new HospitalDto
                                   {
                                       HospitalDtoId = t.Hospital.HospitalId,
                                       Name = t.Hospital.Name
                                   },
                                   PatientDto = new PatientDto
                                   {
                                       Name = t.Patient.Name,
                                       Age = t.Patient.Age,
                                       Gender = t.Patient.Gender,
                                       Phone = t.Patient.Phone,
                                       AadharId = t.Patient.AadharId,
                                       IsAffected = t.Patient.IsAffected,
                                       Addresses = (from b in t.Patient.Address
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

                               }).ToList();

            return uncuredList;

        }
        public IEnumerable<TreatmentDto> GetFatilityCount()
        {


            var fatilityList = (from t in _context.Treatment
                 .Include(x => x.Patient)
                 .Include(x => x.Disease)
                 .Where(x => x.Isfatility == "Yes" && x.Disease.Name == "COVID")
                                select new TreatmentDto()
                                {
                                    AdmittedDate = t.AdmittedDate,
                                    PercentageCure = t.PercentageCure,
                                    RelievingDate = t.RelievingDate,
                                    Isfatility = t.Isfatility,
                                    DiseaseDto = new DiseaseDto
                                    {
                                        DiseaseDtoId = t.Disease.DiseaseId,
                                        Name = t.Disease.Name
                                    },
                                    HospitalDto = new HospitalDto
                                    {
                                        HospitalDtoId = t.Hospital.HospitalId,
                                        Name = t.Hospital.Name
                                    },
                                    PatientDto = new PatientDto
                                    {
                                        Name = t.Patient.Name,
                                        Age = t.Patient.Age,
                                        Gender = t.Patient.Gender,
                                        Phone = t.Patient.Phone,
                                        AadharId = t.Patient.AadharId,
                                        IsAffected = t.Patient.IsAffected,
                                        Addresses = (from b in t.Patient.Address
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


                                }).ToList();

            return fatilityList;


        }


        public async Task PostPatientAsync(PatientDto patientdto)
        {

            var patient = new Patient();
            patient.PatientId = patientdto.PatientDtoId;
            patient.Name = patientdto.Name;
            patient.Age = patientdto.Age;
            patient.Gender = patientdto.Gender;
            patient.Phone = patientdto.Phone;
            patient.AadharId = patientdto.AadharId;
            patient.IsAffected = patientdto.IsAffected;
            patient.Address = new List<Address>();
            foreach (var item in patientdto.Addresses)
            {
                var address = new Address();
                address.AddressType = item.AddressType;
                address.Hno = item.Hno;
                address.Street = item.Street;
                address.City = item.City;
                address.State = item.State;
                address.Country = item.Country;
                address.Pincode = item.Pincode;
                patient.Address.Add(address);

            }
            patient.Occupation = new List<Occupation>();
            foreach (var item in patientdto.Occupations)
            {
                var occupation = new Occupation();

                occupation.Name = item.Name;
                occupation.Phone = item.Phone;
                occupation.StreetNo = item.StreetNo;
                occupation.Area = item.Area;
                occupation.City = item.City;
                occupation.State = item.State;
                occupation.Country = item.Country;
                occupation.Pincode = item.Pincode;
                patient.Occupation.Add(occupation);
            }

            patient.Treatment = new List<Treatment>();
            foreach (var item in patientdto.Treatments)
            {
                var treatment = new Treatment();
                treatment.AdmittedDate = item.AdmittedDate;
                treatment.PercentageCure = item.PercentageCure;
                treatment.RelievingDate = item.RelievingDate;
                treatment.Isfatility = item.Isfatility;
                


                treatment.Disease = new Disease()
                {
                    DiseaseId = item.DiseaseDto.DiseaseDtoId,
                    Name = item.DiseaseDto.Name


                };
                treatment.Hospital = new Hospital()
                {
                    HospitalId = item.HospitalDto.HospitalDtoId,
                    Name = item.HospitalDto.Name,

                };
                patient.Treatment.Add(treatment);

            }


            _context.Patient.Add(patient);

            await _context.SaveChangesAsync();



        }


        public async Task DeletePatientAsync(int id)
        {

            var patient = await _context.Patient.Include(a => a.Address).Include(a => a.Occupation).Include(a => a.Treatment)
                .ThenInclude(a=>a.Disease)
                .FirstOrDefaultAsync(x => x.PatientId == id);

            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(int id, PatientDto patientdto)
        {

            var patient = await _context.Patient.Include(a => a.Address).FirstOrDefaultAsync(x => x.PatientId == id);
            patient.Name = patientdto.Name;
            patient.Age = patientdto.Age;
            patient.Gender = patientdto.Gender;
            patient.Phone = patientdto.Phone;
            patient.AadharId = patientdto.AadharId;
            patient.IsAffected = patientdto.IsAffected;
            
                _context.Patient.Update(patient);

                await _context.SaveChangesAsync();


            
        }
    }
}