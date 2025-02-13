using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class courseRequestHandleRepository
    {
        private readonly Datacontext _datacontext;
        public courseRequestHandleRepository(Datacontext datacontext)
            {
                _datacontext = datacontext;
            }

        //Course RequestHandle start

        public List<courseRequestHandleModelList> courseRequestHandleModelListofData()
        {
            List<courseRequestHandleModelList> list = new List<courseRequestHandleModelList>();
            var data = _datacontext.courseRequestHandleMsts.ToList();
            {
                foreach (var item in data)
                {
                    courseRequestHandleModelList courseRequestHandleModelList = new courseRequestHandleModelList()
                    {
                        cRequestId = item.cRequestId,
                        studentRequestedId = item.studentRequestedId,
                        courseDetailsId = item.courseDetailsId,
                        courseRequestedName = item.courseRequestedName,
                        courseAccesstatus = item.courseAccesstatus,
                        courseRequestTIme = item.courseRequestTIme

                    };
                    list.Add(courseRequestHandleModelList);
                }
                return list;
            }
        }

        //Course RequestHandle end


        //public void AddcourseRequestHandleModelListofData(courseRequestHandleModelList courseRequestHandleModelList)
        //{
        //    courseRequestHandleMst courseRequestHandleMst = new courseRequestHandleMst()
        //    {
        //        studentRequestedId = courseRequestHandleModelList.studentRequestedId,
        //        courseDetailsId = courseRequestHandleModelList.courseDetailsId,
        //        courseRequestedName = courseRequestHandleModelList.courseRequestedName,
        //        courseActiveStatus = courseRequestHandleModelList.courseActiveStatus,
        //        courseRequestTIme = courseRequestHandleModelList.courseRequestTIme            };
        //    _datacontext.courseRequestHandleMsts.Add(courseRequestHandleMst);
        //    _datacontext.SaveChanges();
        //}
    }
}
