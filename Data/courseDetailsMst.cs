using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class courseDetailsMst
    {
        [Key]
        public int courseId  { get; set; }

        public string courseName { get; set; }

        public string courseInstructor { get; set; }
        public string courseCategories { get; set; }

        public  string courseLevel { get; set; }

        public bool courseActiveStatus { get; set; }

        public string courseWallpaper { get; set; }

        public string videoLink { get; set; }

    }
}
