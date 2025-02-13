using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Models
{
	public class serviceRegistrationModel
	{
        public int clientId { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        public string clientfirstName { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        public string clientlastName { get; set; }

        [EmailAddress(ErrorMessage = "Email Required")]
        public string clientemail { get; set; }

        [Required(ErrorMessage = "Location Required")]
        public string clientlocation { get; set; }

        [Required(ErrorMessage = "Select Service")]
        public string clientservice { get; set; }

        [Required(ErrorMessage = "Message Required")]
        public string clientmessage { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string? clientPassword { get; set; }
        public int clientReferenceId { get; set; }
        public string? clientReferenceCode { get; set; }

        //new added
        public int serviceOtp { get; set; }

        public bool registrationStatus { get; set; }

        //get temp otp
        public int getotp { get; set; }
    }

    public class serviceRegistrationModelList : serviceRegistrationModel
    {
        public List<serviceRegistrationModelList> serviceRegistrationModelLists { get; set; } 
    }

}
