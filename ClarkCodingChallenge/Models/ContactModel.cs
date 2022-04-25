using System.ComponentModel.DataAnnotations;

namespace ClarkCodingChallenge.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Last Name cannot be blank")]        
        public string LastName { get; set; }

        [Required(ErrorMessage = "First Name cannot be blank")]        
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email! (example: name@domain.com)")]
        public string Email { get; set; }
    }
}
