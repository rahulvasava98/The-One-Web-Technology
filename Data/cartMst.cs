using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class cartMst
    {
        [Key]
        public int cartItemid { get; set; }

        public string courseName { get; set; }

        public string courseInstructor { get; set; }

        public string courseWallpaper { get; set; }

        public int courseId { get; set; }
    }
}
