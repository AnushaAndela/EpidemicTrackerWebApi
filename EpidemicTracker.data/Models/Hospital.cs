using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpidemicTracker.data.Models
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HospitalId { get; set; }
        [Required]
        public string Name { get; set; }
      
        public long Phone { get; set; }
        
        public string StreetNo { get; set; }
        
        public string Area { get; set; }
        
        public string City { get; set; }
      
        public string State { get; set; }
        
        public string Country { get; set; }
        public int? Pincode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Treatment> Treatment { get; set; }
    }
}