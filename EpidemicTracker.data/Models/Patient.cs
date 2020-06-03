using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpidemicTracker.data.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }
        
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public string Gender { get; set; }
        
        public long Phone { get; set; }
        
        public long? AadharId { get; set; }

        public string IsAffected { get; set; }

        public string CreatedBy { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Occupation> Occupation { get; set; }
        public virtual ICollection<Treatment> Treatment { get; set; }
    }
}