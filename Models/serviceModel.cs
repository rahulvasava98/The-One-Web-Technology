namespace The_One_Web_Technology.Models
{

	public class serviceModel
	{	
        public int Id { get; set; }
        public string Name { get; set; }

        public bool serviceStatus { get; set; }
    }

	public class serviceModelList : serviceModel
	{
		public List<serviceModelList> serviceList { get; set; }
	}
}
