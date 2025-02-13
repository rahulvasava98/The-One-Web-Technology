namespace The_One_Web_Technology.Models
{
    public class courseLikeModel
    {
        public int courselikeID { get; set; }

        public int courseIds { get; set; }

        public int userIds { get; set; }

        public DateTime courseLikeTime { get; set; }

        public Boolean courselikedstatus { get; set; }

    }

    public class courseLikeModelList : courseLikeModel
    {
        public List<courseLikeModelList> courseLikeModels { get; set; }

    }
}
