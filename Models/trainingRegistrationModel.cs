using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Models
{
    public class trainingRegistrationModel
    {
        public int? id { get; set; }


        [Required(ErrorMessage = "firstname is required")]
        [StringLength(50, ErrorMessage = "Name can't exceed 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only alphabets and spaces are allowed")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "firstname is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only alphabets and spaces are allowed")]
        public string lastName { get; set; }



        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string phoneNumber { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Education is required")]
        [StringLength(100, ErrorMessage = "Education can't exceed 100 characters")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabets and spaces are allowed")]
        public string educationQualification { get; set; }


        [Required(ErrorMessage = "location is required")]
        [StringLength(50, ErrorMessage = "location can't exceed 50 characters")]

        public string location { get; set; }


        [Required(ErrorMessage = "Message is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabets and spaces are allowed")]
        [StringLength(150, ErrorMessage = "location can't exceed 150 characters")]
        public string yourMessage { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "location can't exceed 16 characters")]
        public string trainingRegistrationPassword { get; set; }

        public int? referenceId { get; set; }
        public string? referenceCode { get; set; }

        //new Added

        public string? fileUrl { get; set; }

        [Required(ErrorMessage = "Add Your Resume")]
        public IFormFile formFile { get; set; }

        public int? tOTP { get; set; }

    }

    public class trainingRegistrationModelList : trainingRegistrationModel
    {
        public List<trainingRegistrationModelList> trainingRegistrationModelLists { get; set; }
    }
}
