using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
	public class contactRepository
	{
		private readonly Datacontext _datacontext;

		public contactRepository(Datacontext datacontext)
		{
			_datacontext = datacontext;
		}

		public List<contactModel> contactModelList()
		{
			List<contactModel> list = new List<contactModel>();
			var data = _datacontext.contactMsts.ToList();
			{
				foreach(var item in data)
				{
					contactModel contactModel = new contactModel();
					{
						contactModel.Id = item.Id;	
						contactModel.Fname = item.Fname;
						contactModel.Lname = item.Lname;
						contactModel.email = item.email;
						contactModel.subject = item.subject;
						contactModel.message = item.message;
						list.Add(contactModel);
					}
				}
				return list;
			}
		}
		
		public void AddContact(contactModel contactModel)
		{
			contactMst contactMsts = new contactMst() { 
				Id = contactModel.Id,
				Fname = contactModel.Fname,
				Lname = contactModel.Lname,
				email = contactModel.email,
				subject = contactModel.subject,
				message = contactModel.message,
			};
			_datacontext.contactMsts.Add(contactMsts);
			_datacontext.SaveChanges();

		}	
		
	}
}
