using System.ComponentModel.DataAnnotations.Schema;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class courseModuleModel
    {
        public int courseModuleId { get; set; }

        public string SectionName { get; set; }

        public int courseId { get; set; }

        //from course Details
        //public int courseId { get; set; }

        public string courseName { get; set; }
    }

    public class courseModuleModelList : courseModuleModel{
        public List<courseModuleModelList> courseModuleList { get; set; }

        public List<courseDetailsMst> courseDetailsMstsList { get; set; }

    }
}
