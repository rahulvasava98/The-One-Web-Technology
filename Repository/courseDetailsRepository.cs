using Microsoft.AspNetCore.Mvc;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class courseDetailsRepository
    {
        private readonly Datacontext _datacontext;

        public courseDetailsRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        public List<courseDetailsModelList> courseDetailsList()
        {
            List<courseDetailsModelList> list = new List<courseDetailsModelList>();
            var data = _datacontext.courseDetailsMsts.ToList();
            {
                foreach (var item in data)
                {
                    courseDetailsModelList courseDetailsModelList = new courseDetailsModelList();
                    courseDetailsModelList.courseId = item.courseId;
                    courseDetailsModelList.courseName = item.courseName;
                    courseDetailsModelList.courseInstructor = item.courseInstructor;
                    courseDetailsModelList.courseCategories = item.courseCategories;
                    courseDetailsModelList.courseLevel = item.courseLevel;
                    courseDetailsModelList.courseActiveStatus = item.courseActiveStatus;
                    courseDetailsModelList.courseWallpaper = item.courseWallpaper;
                    courseDetailsModelList.videoLink = item.videoLink;
                                                            
                    list.Add(courseDetailsModelList);
                }
            }
            return list;
        }

        [HttpPost]
        public void courseDetailsAdd(courseDetailsModelList courseDetailsModelLists)
        {

            courseDetailsMst courseDetailsMst = new courseDetailsMst()
            {
                courseName = courseDetailsModelLists.courseName,
                courseInstructor = courseDetailsModelLists.courseInstructor,
                courseCategories = courseDetailsModelLists.courseCategories,
                courseLevel = courseDetailsModelLists.courseLevel,
                courseActiveStatus = courseDetailsModelLists.courseActiveStatus,
                courseWallpaper = courseDetailsModelLists.courseWallpaper,
                videoLink = courseDetailsModelLists.videoLink

               
            };
            _datacontext.courseDetailsMsts.Add(courseDetailsMst);
            _datacontext.SaveChanges();

        }

        public void courseDetailsEdit(courseDetailsModelList courseDetailsModelList)
        {
            courseDetailsMst courseDetailsMst = new courseDetailsMst()
            {
                courseId = courseDetailsModelList.courseId,
                courseName = courseDetailsModelList.courseName,
                courseInstructor = courseDetailsModelList.courseInstructor,
                courseCategories = courseDetailsModelList.courseCategories,
                courseLevel = courseDetailsModelList.courseLevel,
                courseActiveStatus = courseDetailsModelList.courseActiveStatus,
                courseWallpaper = courseDetailsModelList.courseWallpaper,
                videoLink = courseDetailsModelList.videoLink
            };
            _datacontext.courseDetailsMsts.Update(courseDetailsMst);
            _datacontext.SaveChanges();
        }

        public void FindCourseDetails(int id)
        {
            courseDetailsModel courseDetails = new courseDetailsModel();
            var data = _datacontext.courseDetailsMsts.Find(id);
            courseDetails.courseId = data.courseId;
            courseDetails.courseName = data.courseName;
            courseDetails.courseLevel = data.courseLevel;
            courseDetails.courseInstructor = data.courseInstructor;
            courseDetails.courseActiveStatus = data.courseActiveStatus;
            courseDetails.courseCategories = data.courseCategories;
            courseDetails.courseWallpaper = data.courseWallpaper;
            courseDetails.videoLink = data.videoLink;

        }

        public void deleteCourseDetails(int id)
        {
            var data = _datacontext.courseDetailsMsts.Find(id);
            _datacontext.courseDetailsMsts.Remove(data);
            _datacontext.SaveChanges();
        }

        
        //coureseLike List

       




    }
}
