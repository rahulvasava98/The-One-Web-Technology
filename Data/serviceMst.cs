using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class serviceMst
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool serviceStatus { get; set; }
    }
}
