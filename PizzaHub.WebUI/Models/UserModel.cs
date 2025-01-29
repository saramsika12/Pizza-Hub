using System.ComponentModel.DataAnnotations;

namespace PizzaHub.WebUI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Compare Password doesn't match")]

        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]

        public string PhoneNumber { get; set; }
    }
}
