using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EpidemicTracker.data.Models
{
   public class Treatment
    {
        
        public int TreatmentId { get; set; }
       
        public DateTime AdmittedDate { get; set; }
       
        public decimal PercentageCure { get; set; }
        public DateTime? RelievingDate { get; set; }
       
        public string Isfatility { get; set; }
        public int? PatientId { get; set; }
        public int? DiseaseId { get; set; }
        public int? HospitalId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Disease Disease { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
