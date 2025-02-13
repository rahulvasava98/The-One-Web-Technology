using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class courseLikeRepository
    {
        private readonly Datacontext _datacontext;

        public courseLikeRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<courseLikeModel> courseLikeMstList()
        {
            List<courseLikeModel> list = new List<courseLikeModel>();
            var data = _datacontext.courseLikeMsts.ToList();
            {
                foreach (var item in data) {
                    courseLikeModel courseLikeModel = new courseLikeModel() { 
                    
                        courselikeID = item.courselikeID,
                        courseIds = item.courseIds,
                        userIds = item.userIds,
                        courselikedstatus = item.courselikedstatus,
                        courseLikeTime = item.courseLikeTime,                    
                    };
                    list.Add(courseLikeModel);                      
                }
            }
            return list;
}
    }
}
