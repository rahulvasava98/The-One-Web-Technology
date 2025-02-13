using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class courseLectureRepository
    {
        private readonly Datacontext _datacontext;

        public courseLectureRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<courseLectureDetailsModelList> CourseLectureList()
        {
            List<courseLectureDetailsModelList> list = new List<courseLectureDetailsModelList>();
            var data = _datacontext.courseLectureDetailsMsts.ToList();
            foreach (var item in data)
            {
                courseLectureDetailsModelList courseLectureDetailsModelList = new courseLectureDetailsModelList() { 
                        courseLectureId = item.courseLectureId,
                        LectureLink = item.LectureLink,
                        LectureUploadDate = item.LectureUploadDate,
                        LectureName = item.LectureName,

                        courseModuleId = item.courseModuleId,
                
                };
                list.Add(courseLectureDetailsModelList);
            }
            return list;    
        }


        public void AddCourseLecturData(courseLectureDetailsModelList courseLectureDetailsModelList)
        {
            var Data = new courseLectureDetailsMst() { 
                    LectureLink = courseLectureDetailsModelList.LectureLink,
                    LectureUploadDate = courseLectureDetailsModelList.LectureUploadDate,
                    LectureName = courseLectureDetailsModelList.LectureName,
                    courseModuleId = courseLectureDetailsModelList.courseModuleId
            };
            _datacontext.courseLectureDetailsMsts.Add(Data);
            _datacontext.SaveChanges();

        }

        public void EditCourseLectureData(courseLectureDetailsModelList courseLectureDetailsModelList)
        {
            var Data = new courseLectureDetailsMst()
            {
                courseLectureId = courseLectureDetailsModelList.courseLectureId,
                LectureLink = courseLectureDetailsModelList.LectureLink,
                LectureUploadDate = System.DateTime.Now,
                LectureName = courseLectureDetailsModelList.LectureName,
                courseModuleId = courseLectureDetailsModelList.courseModuleId
            };
            _datacontext.courseLectureDetailsMsts.Update(Data);
            _datacontext.SaveChanges();
        }

        public void deleteLectureDetails(int id)
        {
            var data = _datacontext.courseLectureDetailsMsts.Find(id);
            _datacontext.courseLectureDetailsMsts.Remove(data);
            _datacontext.SaveChanges();

        }
    }
}
