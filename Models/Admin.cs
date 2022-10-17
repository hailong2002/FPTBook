using System;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Name cannot be blank !")]
        [MinLength(3, ErrorMessage ="Minimum length is 3 characters !"), MaxLength(30, ErrorMessage = "Maximum length is 30 characters !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cannot be blank !")]
        [EmailAddress(ErrorMessage = "Inappropriate email")]
        [MinLength(12, ErrorMessage = "Minium length is 12 characters !"), MaxLength(30, ErrorMessage = "Maximum length is 30 characters !")]
        public string Email { get; set; }

      /*  [Required(ErrorMessage = "Username cannot be blank !")]
        [MinLength(6, ErrorMessage = "Minium length is 6 characters !"), MaxLength(20, ErrorMessage = "Maximum length is 20 characters !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be blank !")]
        [MinLength(6, ErrorMessage = "Minium length is 6 characters !"), MaxLength(20, ErrorMessage = "Maximum length is 20 characters !")]
        public string Password { get; set; }*/

        [Required(ErrorMessage = "Image link cannot be blank !")]
        public string Image { get; set;}

        [Required(ErrorMessage = "Address cannot be blank !")]
        [MinLength(6, ErrorMessage = "Minium length is 6 characters !"), MaxLength(30, ErrorMessage = "Maximum length is 20 characters !")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Birthday cannot be blank !")]
        public DateTime Birthday { get; set; }

    }
}
