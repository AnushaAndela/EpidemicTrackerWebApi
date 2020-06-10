using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpidemicTracker.data.Models
{
    public class OccupationType
    {
        
        public int OccupationTypeId { get; set; }
        
        public string Type { get; set; }
        public int? OccupationId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Occupation Occupation { get; set; }
    }
}