using System.ComponentModel.DataAnnotations.Schema;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class courseDetailsModel
    {
        public int courseId { get; set; }

        public string courseName { get; set; }

        public string courseInstructor { get; set; }
        public string courseCategories { get; set; }

        public string courseLevel { get; set; }

        public bool courseActiveStatus { get; set; }

        public string courseWallpaper { get; set; }

        public string videoLink { get; set; }

        //courseRequestHandle


        public int cRequestId { get; set; }


        public int studentRequestedId { get; set; }

        public int courseDetailsId { get; set; }

        public string courseRequestedName { get; set; }
        public bool courseAccesstatus { get; set; }

        public DateTime courseRequestTIme { get; set; } = System.DateTime.Now;

        #region courseLikeMst
        //courseLikeMst
        public int courselikeID { get; set; }

        public int courseIds { get; set; }

        public int userIds { get; set; }

        public DateTime courseLikeTime { get; set; }

        public Boolean courselikedstatus { get; set; }

        #endregion
        //public List<courseLikeMst> courseLikeMstss { get; set; }


        //public List<courseRequestHandleMst> courseRequestHandleModalListss { get; set; }

        //cartMst

        #region paymentMst
        public int paymentId { get; set; }


        public int StudentId { get; set; }
        //public string courseName { get; set; }

        //public int courseId { get; set; }

        public bool PaymentStatus { get; set; }

        //public IFormFile filelink { get; set; }
        public string FileUrl { get; set; }

        public IFormFile imglink { get; set; }


        //public int cRequestId { get; set; }
        #endregion



    }



    public class courseDetailsModelList : courseDetailsModel
    {

        public List<courseDetailsModelList> courseDetailsModelLists { get; set; }
        
        public List<courseRequestHandleMst> courseRequestHandleModalList { get; set; }

        public List<courseLikeModel> courseLikeModels { get; set; }

        public List<cartMst> cartMsts { get; set; }


        public List<coursePaymentRequestMst> coursePaymentRequests { get; set; }



    }
}
