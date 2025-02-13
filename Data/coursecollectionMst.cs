using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class coursecollectionMst
    {
        [Key]
        public int id { get; set; }
        public string courseName { get; set; }

        public bool courseStatus { get; set; }

    }
}
