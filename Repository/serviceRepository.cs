using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{

	public class serviceRepository
	{
		
		private readonly Datacontext _datacontext;

		public serviceRepository(Datacontext datacontext)
		{
			_datacontext = datacontext;
		}

		public List<serviceModelList> serviceModelList()
		{
			List<serviceModelList> serviceModelLists = new List<serviceModelList>();
			var data = _datacontext.serviceMsts.ToList();
			{
				foreach (var item in data)
				{
					serviceModelList list = new serviceModelList();
					list.Id = item.Id;
					list.Name = item.Name;
					serviceModelLists.Add(list);
				}
			}
			return serviceModelLists;
		}


		public void serviceAdd(serviceModelList serviceModelList)
		{
			serviceMst service = new serviceMst()
			{
				//Id = serviceModelList.Id,
				Name = serviceModelList.Name
			};
			_datacontext.serviceMsts.Add(service);
			_datacontext.SaveChanges();
		}

		public void serviceEdit(serviceModelList serviceModelList)
		{
			serviceMst service = new serviceMst()
			{
				Id = serviceModelList.Id,
				Name = serviceModelList.Name
			};
			_datacontext.serviceMsts.Update(service);
			_datacontext.SaveChanges();

		}

		//public serviceModelList serviceDeatails(int id)
		//{
		//	serviceModelList model = new serviceModelList();
		//	var data = _datacontext.serviceMsts.Find(id);
		//	model.Id = data.Id;
		//	model.Name = data.Name;

		//	return model;
		//}
		public void serviceDelete(int id)
		{
			var data = _datacontext.serviceMsts.Find(id);
			_datacontext.serviceMsts.Remove(data);
			_datacontext.SaveChanges();
		}



	}
}
