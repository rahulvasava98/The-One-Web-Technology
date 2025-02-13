using System.ComponentModel.DataAnnotations.Schema;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class courseLectureDetailsModel
    {
        public int courseLectureId { get; set; }

        public string LectureName { get; set; }
        public string LectureLink { get; set; }
        public DateTime LectureUploadDate { get; set; }
        public int courseModuleId { get; set; }
    }
    public class courseLectureDetailsModelList : courseLectureDetailsModel
    {
        public List<courseLectureDetailsModelList> courseLectureDetailsLists {  get; set; }
        
        public List<courseModuleDetailsMst> courseModuleDetailsMstsList { get; set; }


    }
}
