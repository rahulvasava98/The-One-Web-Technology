using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class CourseReffrealModel
    {
        public int id { get; set; }
        public int creffrealpoint { get; set; }
        public DateTime startingdate { get; set; }
        public DateTime endingdate { get; set; }
        public int courseid { get; set; }
        public Boolean status { get; set; }
    }

    public class CourseReffrealModelList : CourseReffrealModel
    {
        public List<CourseReffrealModelList> CourseReffrealModelLists { get; set; }
        public List<courseDetailsMst> courseDetailsMsts { get; set; }
    }

}
