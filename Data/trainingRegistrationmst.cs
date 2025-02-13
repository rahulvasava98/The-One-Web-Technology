using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class trainingRegistrationmst
    {
        [Key]
        public int id { get; set; }
        public string firstName  { get; set; }
        public string lastName { get; set; }

        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public string educationQualification { get; set; }
        public string location { get; set; }
        public string yourMessage { get; set; }

        public string trainingRegistrationPassword { get; set; }

        public int referenceId { get; set; }
        public string referenceCode { get; set; }

        //public int traningotp { get; set; }
        //public int referenceId { get; set; }

        //new added
        public string? fileUrl { get; set; }


        public  int? tOTP { get; set; }



    }
}
