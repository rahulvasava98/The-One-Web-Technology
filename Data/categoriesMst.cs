using System.ComponentModel.DataAnnotations;

namespace The_One_Web_Technology.Data
{
    public class categoriesMst
    {
        [Key]
    public int categoriesId { get; set; }

    public string? categoriesName { get; set; }
    public Boolean categoriestatus { get; set; }

    }
}
