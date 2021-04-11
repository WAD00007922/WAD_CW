using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarRental.DAL.DBO;

namespace CarRental.DAL.DBO
{
    public class Client: IValidatableObject
    
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; } 

        [Required]
        [DisplayName("Address Line #1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address Line #2")]

        public string AddressLine2 { get; set; }

        [DisplayName("ID of the car")]
        public int? CarId { get; set; }

        [DisplayName("Driving License Number")]
        public string DrivingLicenseNo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DateTime.Now.AddYears(+18) <= DateOfBirth)
            {
                yield return new ValidationResult("Should be 18+", new[] { "DateOfBirth" });
            }
        }

        public virtual Car Car { get; set; }

     }
    public enum Gender
    {
        Female,
        Male
    }
}
