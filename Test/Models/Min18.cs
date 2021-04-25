using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Min18: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            
            if (customer.BirthDate == null)
                return new ValidationResult("The birthdate Is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                 ? ValidationResult.Success : new ValidationResult("You should be at least 18 Yearsold");
        }
    }
}