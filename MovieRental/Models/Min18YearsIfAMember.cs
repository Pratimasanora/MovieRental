using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Date == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Date.Year;
            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("Should be greater than 18 to avail membership");
        }
    }
}