using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EpidemicTracker.data.Models
{
    public class Address
    {
       
        public int AddressId { get; set; }
       
        public string AddressType { get; set; }
       
        public string Hno { get; set; }
       
        public string Street { get; set; }
       
        public string City { get; set; }
       
        public string State { get; set; }
      
        public string Country { get; set; }
        public int? Pincode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}