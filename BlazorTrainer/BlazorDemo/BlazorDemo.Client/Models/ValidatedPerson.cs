// It is generally a good practice to create seperate models that are used for data objects and for UI objects to keep the concerns separate. This model is used for the UI and has validation attributes on it. The data model is in the Shared project.
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Client.Models
{
    public class ValidatedPerson
    {
        [Required]
        [DisplayName("First Name")]
        [MinLength(5, ErrorMessage ="The First Name is not long enough")]
        public string? FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MinLength(8, ErrorMessage ="Last Name must be at least 8 characters in length")]
        public string? LastName { get; set; }

        public string LifeStory { get; set; }
        public bool IsEnrolled { get; set; }
    }
}
