using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace The_One_Web_Technology.Data
{
    public class courseModuleDetailsMst
    {
        [Key]
        public int courseModuleId { get; set; }

        public string SectionName { get; set; }        

        [ForeignKey("courseDetailsMst")]
        public int courseId { get; set; }

        public courseDetailsMst courseDetailsMst { get; set; }

    }
}
