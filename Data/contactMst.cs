using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class contactMst
    {
        [Key]
        
        public int Id { get; set; }
        public string Fname { get; set; }

        public string Lname { get; set; }
        public string email { get; set; }

        public string subject { get; set; }
        public string message { get; set; }
                    
    }
}
