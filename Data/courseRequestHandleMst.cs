using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class courseRequestHandleMst
    {
        [Key]
        public int cRequestId { get; set; }

        public int studentRequestedId { get; set; }

        public int courseDetailsId { get; set; }

        public string courseRequestedName { get; set; }
        public bool courseAccesstatus { get; set; }

        public DateTime courseRequestTIme { get; set; } = System.DateTime.Now;


    }

}
