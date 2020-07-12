using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public class PatientServiceFake:IPatientServiceFake
    {
        private readonly List<Patient> _patients;
        public PatientServiceFake()
        {
            _patients = new List<Patient>()
            {
                new Patient()
                {
                    PatientId=1,
                    Name="Amulya",
                    Age=30,
                    Gender="Female",
                    Phone=9878766272,
                    AadharId=98736277272,
                    Address=new List<Address>()
                    {
                       new Address()
                       {
                           AddressId=2,
                           AddressType="Permanant",
                           Hno="12-3-8",
                           Street="Road no3",
                           City="Waraangal",
                           Country="Hyderabad",
                           Pincode=675552
                       }
                    },
                    Occupation=new List<Occupation>()
                    {
                       new Occupation()
                       {
                           OccupationId=3,
                           Name="Automobiles",
                           Phone=9878765432,
                           StreetNo="2-4-5",
                           Area="Hyderabad",
                           City="Hyderabad",
                           State="Telanagana",
                           Country="India",
                           Pincode=986767

                       }
                    },
                    Treatment=new List<Treatment>()
                    {
                        new Treatment()
                        {
                            TreatmentId=4,
                            AdmittedDate=new DateTime(2020, 3, 1, 7, 47, 0),
                            PercentageCure=30,
                            RelievingDate=new DateTime(2020, 4, 1, 7, 47, 0),
                            Isfatility="Yes"

                        }
                    }
                


                },
                new Patient()
                {
                    PatientId=2,
                    Name="Amrutha",
                    Age=30,
                    Gender="Female",
                    Phone=9878766272,
                    AadharId=98736277272,
                    Address=new List<Address>()
                    {
                       new Address()
                       {
                           AddressId=2,
                           AddressType="Permanant",
                           Hno="12-3-8",
                           Street="Road no3",
                           City="Waraangal",
                           Country="Hyderabad",
                           Pincode=675552
                       }
                    },
                    Occupation=new List<Occupation>()
                    {
                       new Occupation()
                       {
                           OccupationId=3,
                           Name="Automobiles",
                           Phone=9878765432,
                           StreetNo="2-4-5",
                           Area="Hyderabad",
                           City="Hyderabad",
                           State="Telanagana",
                           Country="India",
                           Pincode=986767

                       }
                    },
                    Treatment=new List<Treatment>()
                    {
                        new Treatment()
                        {
                            TreatmentId=4,
                            AdmittedDate=new DateTime(2020, 3, 1, 7, 47, 0),
                            PercentageCure=30,
                            RelievingDate=new DateTime(2020, 4, 1, 7, 47, 0),
                            Isfatility="Yes"

                        }
                    }



                }

            };
        }

        public Patient Add(Patient patient)
        {

            
            _patients.Add(patient);
            return patient;
        }

        public IEnumerable<Patient> GetAllItems()
        {
            return _patients;
        }

        public Patient GetById(int id)
        {
            return _patients.Where(a => a.PatientId == id)
          .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _patients.First(a => a.PatientId == id);
            _patients.Remove(existing);
        }
    }
}
