using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class courseCategoriesMst
    {
        [Key]
        public int id { get; set; }

        public Boolean courseCategoriesStatus { get; set; }

        public int courseId { get; set; }
    }
}
