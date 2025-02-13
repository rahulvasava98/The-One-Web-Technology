using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Models
{
    public class courseCategoriesModel
    {        
            public int id { get; set; }

            public Boolean courseCategoriesStatus { get; set; }

            public int courseId { get; set; }        
    }
    public class courseCategoriesModelList : courseCategoriesModel { 
        public List<courseCategoriesModelList> courseCategories {  get; set; } 
        
    }
}
