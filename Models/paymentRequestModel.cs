using System.ComponentModel.DataAnnotations.Schema;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class paymentRequestModel
    {
        public int paymentId { get; set; }

        public int StudentId { get; set; }
        public string courseName { get; set; }

        public int courseId { get; set; }

        public bool PaymentStatus { get; set; }

        public string FileUrl { get; set; }

        public IFormFile ImgUrl { get; set; }
        public int cRequestId { get; set; }
    }
    public class paymentRequestModelList : paymentRequestModel { 
        
        public List<paymentRequestModel> paymentRequestList { get; set; }

        public List<coursePaymentRequestMst> coursePaymentRequestList { get; set; }
        
    
    }
}
