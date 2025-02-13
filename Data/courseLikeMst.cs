using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class courseLikeMst
    {
        [Key]
        public int courselikeID { get; set; }


        public Boolean courselikedstatus { get; set; }

        public int courseIds { get; set; }

        public int userIds { get; set; }

        public DateTime courseLikeTime { get; set; }

    }

}
