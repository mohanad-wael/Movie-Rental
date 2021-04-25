using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Birth Of Date")]
        [Min18]
        public DateTime? BirthDate { get; set; }


        public bool IsSubcribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        [Display(Name ="Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}