using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpidemicTracker.data.Models
{
    public class Disease
    {
        
        public int DiseaseId { get; set; }
  
        public string Name { get; set; }
        public int? DiseaseTypeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual DiseaseType DiseaseType { get; set; }
        public virtual ICollection<Treatment> Treatment { get; set; }
    }
}