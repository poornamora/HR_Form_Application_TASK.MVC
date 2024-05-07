using System.ComponentModel.DataAnnotations;

namespace First_Sample_Project.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Please Enter EmailID")]
        [Required(ErrorMessage ="Email is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter valid Email")]
        public string? Email { get; set; }
        

        [Display(Name = "Please Enter  Password")]
        [Required(ErrorMessage = "Password is requried!")]
        public string? Password { get; set; }
    }
}
