using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
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
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; } 

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int? CarId { get; set; }
        public string DrivingLicesnsenNo { get; set; }

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
