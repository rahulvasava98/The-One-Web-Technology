using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class courseModuleRepository
    {
        private readonly Datacontext _datacontext;

        public courseModuleRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }


        public List<courseModuleModelList> courseModuleMstList()
        {
            List<courseModuleModelList> list = new List<courseModuleModelList>();
            var data = _datacontext.courseModuleDetailsMsts.ToList();
            foreach (var item in data)
            {
                courseModuleModelList courseModuleModelList = new courseModuleModelList()
                {
                    courseModuleId = item.courseModuleId,
                    SectionName = item.SectionName,
                    courseId = item.courseId
                };
                list.Add(courseModuleModelList);
            }
            return list;
        }

        public void AddCourseModuleData(courseModuleModelList courseModuleModelList)
        {
            var data = new courseModuleDetailsMst()
            {

                SectionName = courseModuleModelList.SectionName,
                courseId = courseModuleModelList.courseId
            };
            _datacontext.courseModuleDetailsMsts.Add(data);
            _datacontext.SaveChanges();
        }

        public void EditCourseModuleData(courseModuleModelList courseModuleModelList)
        {
            var data = new courseModuleDetailsMst()
            {
                courseModuleId = courseModuleModelList.courseModuleId,
                SectionName = courseModuleModelList.SectionName,
                courseId = courseModuleModelList.courseId
            };
            _datacontext.courseModuleDetailsMsts.Update(data);
            _datacontext.SaveChanges();
        }

        public void DeleteModuleDataRe(int id)
        {
            var data = _datacontext.courseModuleDetailsMsts.Find(id);
            _datacontext.courseModuleDetailsMsts.Remove(data);
            _datacontext.SaveChanges();
        }

        public List<CourseReffrealModelList> courserefrealllist()
        {
            //List<CourseReffrealModelList> list = new List<CourseReffrealModelList>();
            //var data = _datacontext.courseReffrealMsts.ToList();
            //foreach (var item in data)
            //{
            //    CourseReffrealModelList courseReffrealModel = new CourseReffrealModelList()
            //    {
            //        id = item.id,
            //        creffrealpoint = item.creffrealpoint,
            //        startingdate = item.startingdate,
            //        endingdate = (DateTime)item.endingdate,
            //        courseid = item.courseid,
            //        status = item.status
            //    };
            //    list.Add(courseReffrealModel);
            //}
            return null;
        }
    }
}