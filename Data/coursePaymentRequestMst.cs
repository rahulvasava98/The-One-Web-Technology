using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_One_Web_Technology.Data
{
    public class coursePaymentRequestMst
    {
        [Key]
        public int paymentId { get; set; }


        public int StudentId { get; set; }  
        public string courseName { get; set; }

        public int courseId { get; set; }

        public bool PaymentStatus { get; set; }

        public string FileUrl { get; set; }

        [ForeignKey("courseRequestHandleMst")]
        public int cRequestId { get; set; }

        public courseRequestHandleMst courseRequestHandleMst { get; set; }

    }
}
