using System.ComponentModel.DataAnnotations;

namespace Test_MVC_EF_01.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = string.Empty;
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
