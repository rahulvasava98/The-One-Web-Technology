using System.ComponentModel.DataAnnotations.Schema;
using The_One_Web_Technology.Data;

namespace The_One_Web_Technology.Models
{
    public class CourseRefreallManageModel
    {
        public int id { get; set; }
        public int usershareid { get; set; }
        public int userid { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public int refreallid { get; set; }
    }

    public class CourseRefreallManageModelList : CourseRefreallManageModel
    {
        public List<CourseRefreallManageModelList> courseRefreallManageModelLists { get; set; }
    }

}
