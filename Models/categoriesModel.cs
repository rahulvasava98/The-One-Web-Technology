namespace The_One_Web_Technology.Models
{
    public class categoriesModel
    {
        public int categoriesId { get; set; }

        public string categoriesName { get; set; }
        public Boolean categoriestatus { get; set; }
    }
    public class categoriesModelList : categoriesModel
    {
        public List<categoriesModelList> categoriesList { get; set;}
    }
}
