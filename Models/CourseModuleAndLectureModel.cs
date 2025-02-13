using System.ComponentModel.DataAnnotations.Schema;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class CourseModuleAndLectureModel
    {
        //course Module
        public int courseModuleId { get; set; }

        public string SectionName { get; set; }
        public int courseId { get; set; }

        //course Lecture
        public int courseLectureId { get; set; }

        public string LectureName { get; set; }
        public string LectureLink { get; set; }
        public DateTime LectureUploadDate { get; set; }

    }

    public class CourseModuleAndLectureModelList : CourseModuleAndLectureModel
    {
        public List<CourseModuleAndLectureModelList> courseModuleAndLectureModelLists { get; set; }

        public List<courseLectureDetailsMst> courseLectureList { get; set; }

        public List<courseModuleDetailsMst> courseModuleList { get; set; }

        public List<courseDetailsMst> courseDetailsList { get; set; }

    }
}
