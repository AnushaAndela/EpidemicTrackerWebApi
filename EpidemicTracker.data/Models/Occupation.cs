using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpidemicTracker.data.Models
{
    public class Occupation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OccupationId { get; set; }
        [Required]
        public string Name { get; set; }
        public long? Phone { get; set; }
        [Required]
        public string StreetNo { get; set; }
        [Required]
        public string Area { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        public int? Pincode { get; set; }
        public int? PatientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual ICollection<OccupationType> OccupationType { get; set; }
    }
}