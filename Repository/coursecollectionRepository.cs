using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class coursecollectionRepository
    {
        private readonly Datacontext _datacontext;

        public coursecollectionRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<coursecollectionModelList> coursecollectionList()
        {
            List<coursecollectionModelList> coursecollectionModelLists = new List<coursecollectionModelList>();
            var data = _datacontext.coursecollectionMsts.ToList();
            {
                foreach (var item in data)
                {
                    coursecollectionModelList list = new coursecollectionModelList();
                    list.id = item.id;
                    list.courseName = item.courseName;
                    coursecollectionModelLists.Add(list);
                }

            }
            return coursecollectionModelLists;
        }

        public void coursecollectionAdd(coursecollectionModelList coursecollectionModelList)
        {
            coursecollectionMst coursecollectionMst = new coursecollectionMst()
            {
                courseName = coursecollectionModelList.courseName
            };
            _datacontext.coursecollectionMsts.Add(coursecollectionMst);
            _datacontext.SaveChanges();
        }

        public void coursecollectionEdit(coursecollectionModelList coursecollectionModelList)
        {
            coursecollectionMst coursecollectionMst = new coursecollectionMst()
            {
                id = coursecollectionModelList.id,
                courseName = coursecollectionModelList.courseName

            };
            _datacontext.coursecollectionMsts.Update(coursecollectionMst);
            _datacontext.SaveChanges();
        }

        public void coursecollectionDelete(int id)
        {
            var data = _datacontext.coursecollectionMsts.Find(id);
            _datacontext.coursecollectionMsts.Remove(data);
            _datacontext.SaveChanges();
        }

    }
}
