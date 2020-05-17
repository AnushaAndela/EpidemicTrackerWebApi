using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Services.Dtos
{
    public class TreatmentDto
    {
        public int TreatmentDtoId { get; set; }
        public int TreatmentId { get; set; }
        public DateTime AdmittedDate { get; set; }
        public decimal PercentageCure { get; set; }
        public DateTime? RelievingDate { get; set; }
        public string Isfatility { get; set; }
        public int? PatientId { get; set; }
        public int? DiseaseId { get; set; }
        public int? HospitalId { get; set; }
        public virtual Disease Disease { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
