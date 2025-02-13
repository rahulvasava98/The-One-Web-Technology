using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class cartRepository
    {
        private readonly Datacontext _datacontext;

        public cartRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }


        public List<cartModelList> cartModelList()
        {
            List<cartModelList> list = new List<cartModelList>();
            var data = _datacontext.cartMsts.ToList();
            {
                foreach(var item in data)
                {
                    cartModelList cartModel = new cartModelList() { 
                        cartItemid = item.cartItemid,
                        courseWallpaper = item.courseWallpaper,
                        courseName = item.courseName,
                        courseId = item.courseId,
                        courseInstructor = item.courseInstructor                    
                    };                    
                    list.Add(cartModel);
                }
            }
            return list;
        }
    }
}
