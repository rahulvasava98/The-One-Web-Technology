using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Models
{
    public class trainingloginModel
    {
        public int id { get; set; }

        public string? phoneNumber { get; set; }
        public string? Email { get; set; }




        public string? tOTP { get; set; }
        public int referenceId { get; set; }
        public string? referenceCode { get; set; }

        //confirmPassword
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string trainingRegistrationPassword { get; set; }


        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("trainingRegistrationPassword", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }


}
