using The_One_Web_Technology.Data;
using The_One_Web_Technology.Migrations;

namespace The_One_Web_Technology.Models
{
    public class courseRequestHandleModel
    {

        public int cRequestId { get; set; }

        public int studentRequestedId { get; set; }

        public int courseDetailsId { get; set; }

        public string courseRequestedName { get; set; }
        public bool courseAccesstatus { get; set; }

        public DateTime courseRequestTIme { get; set; }

        //coursePaymentRequestMst
        public int paymentId { get; set; }       

        public bool PaymentStatus { get; set; }



    }

    public class courseRequestHandleModelList : courseRequestHandleModel
    {
        public List<courseRequestHandleModelList> courseRequestHandleModelLists { get; set; }

        public List<coursePaymentRequestMst> coursePaymentLists { get; set; }

    }


}
