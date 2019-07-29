using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Customer Name is Mandatory")]

        [StringLength(50)]
        
        [Display(Name ="Customer Name")]
        public string Name { get; set; }

        public bool IsSubscribeTypeNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Types")]
        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]

        [Display(Name = "Date of Birth")]
        public DateTime Date { get; set; }

    }
}