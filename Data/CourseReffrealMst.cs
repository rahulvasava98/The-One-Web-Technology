using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_One_Web_Technology.Data
{
    public class CourseReffrealMst
    {
        [Key]
        public int id { get; set; }
        public int creffrealpoint { get; set; }

        [ForeignKey("courseDetailsMst")]
        public int courseid { get; set; }
        public courseDetailsMst courseDetailsMst { get; set; }

        public DateTime startingdate { get; set; } = System.DateTime.Now;
        public DateTime? endingdate { get; set; }
        public Boolean status { get; set; }
    }
}
