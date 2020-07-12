using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services
{
    public interface IPatientServiceFake
    {
        IEnumerable<Patient> GetAllItems();
        Patient Add(Patient patient);
        Patient GetById(int id);
        void Remove(int id);
    }
}
