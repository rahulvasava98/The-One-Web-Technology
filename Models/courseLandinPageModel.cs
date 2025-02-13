using System.Security.Cryptography.X509Certificates;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class courseLandinPageModel
    {

        //courseCategoriesMst
        public int id { get; set; }

        public Boolean courseCategoriesStatus { get; set; }

        public int courseId { get; set; }


        //courseDetailsMst

        //public int courseId { get; set; }

        public string courseName { get; set; }

        public string courseInstructor { get; set; }
        public string courseCategories { get; set; }

        public string courseLevel { get; set; }

        public bool courseActiveStatus { get; set; }

        public string courseWallpaper { get; set; }

        public string videoLink { get; set; }

        //courseModuleDetailsMst
        public int courseModuleId { get; set; }

        public string SectionName { get; set; }

        //courseLectureMst
        public string LectureLink { get; set; }

        public int courseLectureId { get; set; }
    }
    public class courseLandingPageModelList : courseLandinPageModel
    {
        public List<courseLandingPageModelList> courseLandingPageModelLists { get; set; }

        public List<courseCategoriesMst> courseCategoriesMsts { get; set; }

        public List<courseDetailsMst> courseDetailsMsts { get; set; }

        public List<courseModuleDetailsMst> CourseModuleDetailsmstList { get; set; }

        public List<courseLectureDetailsMst> courseLectureDetailsMstList { get; set; } 


    }
}
