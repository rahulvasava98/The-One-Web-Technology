using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class serviceRegistrationMaster
    {
        [Key]
        public int clientId { get; set; }
        public string clientfirstName { get; set; }
        public string clientlastName { get; set; }
        public string clientemail { get; set; }
        public string clientlocation { get; set; }
        public string clientservice { get; set; }
        public string clientmessage { get; set; }
        public string clientPassword { get; set; }
        public int clientReferenceId { get; set; }
        public string clientReferenceCode { get; set; }


        public int serviceOtp { get; set; }
        public bool registrationStatus { get; set; }


    }
}
