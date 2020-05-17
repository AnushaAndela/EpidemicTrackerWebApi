using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.data.Models;
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
            return null;
        }
    }
}
