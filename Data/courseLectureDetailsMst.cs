using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_One_Web_Technology.Data
{
    public class courseLectureDetailsMst
    {
        [Key]
        public int courseLectureId { get; set; }

        public string LectureName { get; set; }
        public string LectureLink { get; set; }
        public DateTime LectureUploadDate { get; set; }

        

        [ForeignKey("courseModuleDetailsMst")]

        public int courseModuleId { get; set; }
        public courseModuleDetailsMst courseModuleDetailsMst { get; set; }


    }
}
