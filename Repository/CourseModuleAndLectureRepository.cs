using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class CourseModuleAndLectureRepository
    {
        private readonly Datacontext _datacontext;

        public CourseModuleAndLectureRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        #region
        //ModuleHandle crud

        public void AddModule(CourseModuleAndLectureModelList courseModuleAndLectureModelList)
        {
            var data = new courseModuleDetailsMst(){
                courseModuleId = courseModuleAndLectureModelList.courseModuleId,
                courseId = courseModuleAndLectureModelList.courseId,
                SectionName = courseModuleAndLectureModelList.SectionName
            };
            _datacontext.courseModuleDetailsMsts.Add(data);
            _datacontext.SaveChanges();
        }

        public void EditModule(CourseModuleAndLectureModelList courseModuleAndLecture)
        {
            var data = new courseModuleDetailsMst()
            {
                courseModuleId = courseModuleAndLecture.courseModuleId,
                SectionName = courseModuleAndLecture.SectionName,
                courseId = courseModuleAndLecture.courseId
            };
            _datacontext.courseModuleDetailsMsts.Update(data);
            _datacontext.SaveChanges();
        }

        public void DeleteModuleAndLecture(int id)
        {
            var data = _datacontext.courseModuleDetailsMsts.Find(id);
            var secondTabData = _datacontext.courseLectureDetailsMsts.Find(id);
            var third = _datacontext.courseLectureDetailsMsts.Where(x => x.courseModuleId == id);


            _datacontext.courseLectureDetailsMsts.RemoveRange(third);
            _datacontext.courseModuleDetailsMsts.Remove(data);
            _datacontext.SaveChanges();


        }
        #endregion
        //lecture Crud
        #region
        public void AddDataToLectureFromAdminView(CourseModuleAndLectureModelList courseModuleAndLectureModelList)
        {
            var data = new courseLectureDetailsMst()
            {
                LectureName = courseModuleAndLectureModelList.LectureName,
                LectureLink = courseModuleAndLectureModelList.LectureLink,
                LectureUploadDate = System.DateTime.Now,
                courseModuleId = courseModuleAndLectureModelList.courseModuleId
            };
            _datacontext.courseLectureDetailsMsts.Add(data);
            _datacontext.SaveChanges();

        }

        //public void EditLectureFromAdminView(CourseModuleAndLectureModelList courseModuleAndLectureModel)
        //{
        //    var data = new courseLectureDetailsMst()
        //    {
        //        courseLectureId = courseModuleAndLectureModel.courseLectureId,
        //        LectureName = courseModuleAndLectureModel.LectureName,
        //        LectureLink = courseModuleAndLectureModel.LectureLink,
        //        LectureUploadDate = System.DateTime.Now,
        //        courseModuleId = courseModuleAndLectureModel.courseModuleId
        //    };
        //    _datacontext.courseLectureDetailsMsts.Update(data);
        //    _datacontext.SaveChanges();
        //}

        public void DeleteLectureFromAdminView(int id)
        {
            var findData = _datacontext.courseLectureDetailsMsts.Find(id);
            _datacontext.courseLectureDetailsMsts.Remove(findData);
            _datacontext.SaveChanges();
        }
        #endregion

    }
}
