using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class cartModel
    {        
        public int cartItemid { get; set; }

        public string courseName { get; set; }

        public string courseInstructor { get; set; }

        public string courseWallpaper { get; set; }

        public int courseId { get; set; }
    }

    public class cartModelList : cartModel
    {
        public List<cartModelList> cartModelLists { get; set; }

        public List<cartMst> cartMstList { get; set; }
    }
}

                               