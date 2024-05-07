using First_Sample_Project.Repository;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Sample_Project.Models
{
    public class UserRegistration: ISoftDelete
    {
        [Key]

        [Required]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please Enter Name")]
        //[RegularExpression(" ^[A-Za-z]+$", ErrorMessage = "Name Field should contains only alphabetic characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Please Enter Email")]
        [Column(TypeName ="varchar(120)")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Enter valid Email")]
        public string? Email { get; set; }

        [Column(TypeName ="varchar(200)")]
        [Required(ErrorMessage="Please Enter Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Please Enter Conform Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Conform Password")]
        [Compare("Password")]
        [NotMapped]
        public string? ConformPassword { get; set; }

        public bool IsActive { get; set; } = true;
      

        //[Required(ErrorMessage ="Please select Date of Birth")]
        //public DateTime DOB { get; set; }

        //[Required(ErrorMessage ="Please Enter MobileNumber")]
        //[Display(Name= "Mobile Number")]
        //public string MobileNumber { get; set; }


        //[Required(ErrorMessage ="Please Select Gender")]
        //public string Gender { get; set; }


        //[Required(ErrorMessage ="Select the martial status")]
        //[Display(Name= "Martial Status")]
        //public string MartialStatus { get; set; }
    }
}
