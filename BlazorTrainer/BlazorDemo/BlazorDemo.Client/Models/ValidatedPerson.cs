// It is generally a good practice to create seperate models that are used for data objects and for UI objects to keep the concerns separate. This model is used for the UI and has validation attributes on it. The data model is in the Shared project.
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Client.Models
{
    public class ValidatedPerson
    {
        [Required]
        [DisplayName("First Name")]
        [MinLength(1, ErrorMessage ="The First Name is not long enough")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MinLength(2, ErrorMessage ="Last Name must be at least 2 characters in length")]
        public string? LastName { get; set; }

        public string? LifeStory { get; set; }
        public bool IsEnrolled { get; set; }

        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [Range(1, 100, ErrorMessage = "The number must be between 1 and 100")]
        public int MyNumber { get; set; }
        // If this is a double, then the range needs to be a double in order for it to work as expected
        // For example, if the upper range is 100, and the provided number is 100.1, it will pass validation, so instead the range would need to be 100.0

        [Required]
        public string? Department { get; set; }
        [Required]
        public EmployeeType EmployeePayrollStatus { get; set; }

        public string? CellPhoneProvider { get; set; }
    }

    public enum EmployeeType
    {
        FullTime,
        PartTime,
        Contractor
    }
}
