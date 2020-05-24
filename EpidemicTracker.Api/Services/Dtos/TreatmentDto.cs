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
       
        public DateTime AdmittedDate { get; set; }
        public decimal PercentageCure { get; set; }
        public DateTime? RelievingDate { get; set; }
        public string Isfatility { get; set; }
        //public int? PatientId { get; set; }
        //public int? DiseaseId { get; set; }
        //public int? HospitalId { get; set; }
        public virtual DiseaseDto DiseaseDto { get; set; }
        public virtual HospitalDto HospitalDto { get; set; }
        public virtual PatientDto PatientDto { get; set; }
    }
}
