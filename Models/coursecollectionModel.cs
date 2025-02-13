namespace The_One_Web_Technology.Models
{
    public class coursecollectionModel
    {
        public int id { get; set; }
        public string courseName { get; set; }

        public bool courseStatus { get; set; }
    }

    public class coursecollectionModelList : coursecollectionModel
    {
        public List<coursecollectionModelList> coursecollectionlist { get; set; }
    }
}
