using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata.Ecma335;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;
using The_One_Web_Technology.Repository;

namespace The_One_Web_Technology.Controllers
{
    public class adminController : Controller
    {
        private readonly Datacontext _datacontext;
        private readonly contactRepository _contactRepository;
        private readonly serviceRepository _serviceRepository;
        private readonly serviceRegistrationRepository _serviceRegistrationRepository;
        private readonly trainingRegistrationRepository _trainingRegistrationRepository;
        private readonly coursecollectionRepository _coursecollectionRepository;
        private readonly categoriesRepository _categoriesRepository;
        private readonly courseDetailsRepository _courseDetailsRepository;
        private readonly courseRequestHandleRepository _courseRequestHandleRepository;
        private readonly courseModuleRepository _courseModuleRepository;
        private readonly courseLectureRepository _courseLectureRepository;
        private readonly CourseModuleAndLectureRepository _courseModuleAndLectureRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public adminController(Datacontext datacontext, IWebHostEnvironment webHostEnvironment)
        {
            _datacontext = datacontext;
            _webHostEnvironment = webHostEnvironment;

            _contactRepository = new contactRepository(datacontext);
            _serviceRepository = new serviceRepository(datacontext);
            _serviceRegistrationRepository = new serviceRegistrationRepository(datacontext);
            _trainingRegistrationRepository = new trainingRegistrationRepository(datacontext, webHostEnvironment);

            _coursecollectionRepository = new coursecollectionRepository(datacontext);
            _categoriesRepository = new categoriesRepository(datacontext);
            _courseDetailsRepository = new courseDetailsRepository(datacontext);
            _courseRequestHandleRepository = new courseRequestHandleRepository(datacontext);
            _courseModuleRepository = new courseModuleRepository(datacontext);
            _courseLectureRepository = new courseLectureRepository(datacontext);
            _courseModuleAndLectureRepository = new CourseModuleAndLectureRepository(datacontext);

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult login()
        {
            return View();
        }
        public IActionResult RegistrationAdmin()
        {
            return View();
        }

        public IActionResult forgot_password()
        {
            return View();
        }
        public IActionResult _admin_Layout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult trainingRegistrationList()
        {
            trainingRegistrationModelList trainingRegistrationModelList = new trainingRegistrationModelList();
            trainingRegistrationModelList.trainingRegistrationModelLists = _trainingRegistrationRepository.GetTrainingRegistrationList();
            return View(trainingRegistrationModelList);
        }
        [HttpGet]
        public IActionResult traineeReferenceList(int id)
        {
            trainingRegistrationModelList taineerefeList = new trainingRegistrationModelList();
            taineerefeList.trainingRegistrationModelLists = _trainingRegistrationRepository.mytrainingreferenceList(id);
            return View(taineerefeList);
        }

        //course RequestHandle list start

        [HttpGet]
        public IActionResult courseRequestHandleModelList()
        {
            courseRequestHandleModelList courseRequestModel = new courseRequestHandleModelList();
            courseRequestModel.courseRequestHandleModelLists = _courseRequestHandleRepository.courseRequestHandleModelListofData();
            courseRequestModel.coursePaymentLists = _datacontext.coursePaymentRequestMsts.ToList();
            return View(courseRequestModel);
        }

        //course RequestHandle list end
        [HttpGet]
        public IActionResult ContactUsListView()
        {

            return View(_contactRepository.contactModelList());
        }

        [HttpGet]
        public IActionResult serviceRegistrationList()
        {
            //return View();
            return View(_serviceRegistrationRepository.serviceRegistrationList());
        }

        [HttpGet]
        public IActionResult serviceReferenceList()
        {
            return View(_serviceRegistrationRepository.serviceReferenceList());
        }


        [HttpGet]
        public IActionResult ServiceListView()
        {
            serviceModelList serviceModelList = new serviceModelList();
            serviceModelList.serviceList = _serviceRepository.serviceModelList();

            return View(serviceModelList);
        }
        #region serviceAdd
        [HttpPost]
        public IActionResult serviceAdd(serviceModelList servicemodellist)
        {
            _serviceRepository.serviceAdd(servicemodellist);
            return RedirectToAction("ServiceListView");
        }
        #endregion serviceAdd
        [HttpPost]
        public IActionResult ServiceEdit(serviceModelList serviceModelList)
        {
            _serviceRepository.serviceEdit(serviceModelList);
            return RedirectToAction("ServiceListView");
        }

        [HttpPost]
        public JsonResult serviceDetails(int id)
        {
            var data = _datacontext.serviceMsts.Find(id);
            return Json(data);
        }

        [HttpPost]
        public JsonResult serviceStatus(int id, bool serviceStatusData)
        {
            var data = _datacontext.serviceMsts.Where(s => s.Id == id).FirstOrDefault();
            if (data != null)
            {
                data.serviceStatus = serviceStatusData;
                _datacontext.serviceMsts.Update(data);
                _datacontext.SaveChanges();
            }
            return Json(data);
        }

        public IActionResult serviceDelete(int id)
        {
            _serviceRepository.serviceDelete(id);
            return RedirectToAction("ServiceListView");
        }


        //coursecollectionMst   
        [HttpGet]
        public IActionResult coursecollectionlist()
        {

            coursecollectionModelList coursecollectionModelList = new coursecollectionModelList();
            coursecollectionModelList.coursecollectionlist = _coursecollectionRepository.coursecollectionList();
            return View(coursecollectionModelList);

        }

        [HttpPost]
        public IActionResult coursecollectionAdd(coursecollectionModelList coursecollectionmodellist)
        {
            _coursecollectionRepository.coursecollectionAdd(coursecollectionmodellist);
            return RedirectToAction("courseCollectionList");
        }
        [HttpPost]
        public IActionResult coursecollectionEdit(coursecollectionModelList coursecollectionmodellist)
        {
            _coursecollectionRepository.coursecollectionEdit(coursecollectionmodellist);
            return RedirectToAction("courseCollectionList");
        }

        [HttpPost]
        public JsonResult courseCollectionDetails(int id)
        {

            var data = _datacontext.coursecollectionMsts.Find(id);
            return Json(data);

        }
        [HttpPost]
        public JsonResult courseCollectionStatusUpdate(int id, bool findStatus)
        {
            var Data = _datacontext.coursecollectionMsts.Where(s => s.id == id).FirstOrDefault();
            if (Data != null)
            {
                Data.courseStatus = findStatus;
                _datacontext.coursecollectionMsts.Update(Data);
                _datacontext.SaveChanges();
            }
            return Json(Data);
        }
        public IActionResult coursecollectionDelete(int id)
        {
            _coursecollectionRepository.coursecollectionDelete(id);
            return RedirectToAction("courseCollectionList");
        }

        [HttpGet]


        public IActionResult categoriesList()
        {
            categoriesModelList categoriesModelList = new categoriesModelList();
            categoriesModelList.categoriesList = _categoriesRepository.categoriesList();

            return View(categoriesModelList);
        }

        [HttpPost]
        public IActionResult categorieAdd(categoriesModelList categoriesModelList)
        {
            _categoriesRepository.AddCategories(categoriesModelList);
            return RedirectToAction("categoriesList");
        }

        [HttpPost]
        public IActionResult categoriesEdit(categoriesModelList categoriesModelList)
        {
            _categoriesRepository.EditCategories(categoriesModelList);
            return RedirectToAction("categoriesList");
        }

        [HttpPost]
        public JsonResult categoriesDetails(int id)
        {
            var data = _datacontext.categoriesMsts.Find(id);
            return Json(data);
        }

        [HttpPost]
        public JsonResult categoriesStatus(int id, bool findStatus)
        {
            var data = _datacontext.categoriesMsts.Where(s => s.categoriesId == id).FirstOrDefault();
            if (data != null)
            {
                data.categoriestatus = findStatus;
                _datacontext.categoriesMsts.Update(data);
                _datacontext.SaveChanges();
            }
            return Json(data);
        }

        [HttpPost]
        public IActionResult categoriesDeleteData(int id)
        {
            _categoriesRepository.DeleteCategories(id);
            return View("categoriesList");
        }

        [HttpPost]
        //public IActionResult categoriesDelete(categoriesModelList categoriesModelList)
        //{
        //    _categoriesRepository.DeleteCategories(categoriesModelList);
        //    return RedirectToAction("categoriesList");
        //}


        [HttpGet]
        public IActionResult courseDetailslist()
        {
            courseDetailsModelList courseDetailsModelList = new courseDetailsModelList();
            courseDetailsModelList.courseDetailsModelLists = _courseDetailsRepository.courseDetailsList();
            return View(courseDetailsModelList);
        }

        [HttpPost]
        public IActionResult courseDetailsAdd(courseDetailsModelList courseDetailsModelList)
        {
            _courseDetailsRepository.courseDetailsAdd(courseDetailsModelList);
            return RedirectToAction("courseDetailslist");
        }
        [HttpPost]
        public IActionResult courseDetailsEdit(courseDetailsModelList courseDetailsModelList)
        {
            _courseDetailsRepository.courseDetailsEdit(courseDetailsModelList);
            return RedirectToAction("courseDetailslist");
        }

        [HttpPost]
        public JsonResult courseDetailsgetDetails(int id)
        {
            var data = _datacontext.courseDetailsMsts.Find(id);
            return Json(data);
        }

        [HttpPost]
        public IActionResult courseDetailsDelete(int id)
        {

            _courseDetailsRepository.deleteCourseDetails(id);
            return RedirectToAction("courseDetailslist");

        }
        //[HttpPost]
        //public JsonResult UpdateCourseAccessStatusData(Boolean cvalue,int id)
        //{

        //   var data = _datacontext.courseRequestHandleMsts.Where(r => r.cRequestId == id).FirstOrDefault();
        //    if(data != null)
        //    {
        //        data.courseAccesstatus = cvalue;
        //        _datacontext.courseRequestHandleMsts.Update(data);
        //        _datacontext.SaveChanges();
        //    }
        //    return Json(data);
        //}


        [HttpGet]
        public IActionResult CourseModuleDetails()
        {
            courseModuleModelList courseModuleModel = new courseModuleModelList();
            courseModuleModel.courseDetailsMstsList = _datacontext.courseDetailsMsts.ToList();
            courseModuleModel.courseModuleList = _courseModuleRepository.courseModuleMstList();



            return View(courseModuleModel);
        }
        [HttpPost]
        public IActionResult AddCourseModule(courseModuleModelList courseModuleModel)
        {
            _courseModuleRepository.AddCourseModuleData(courseModuleModel);
            TempData["AddSection"] = "New Section Added ";
            return RedirectToAction("CourseModuleDetails");
        }

        [HttpPost]
        public JsonResult GetModuleDetails(int id)
        {
            var data = _datacontext.courseModuleDetailsMsts.Find(id);
            return Json(data);
        }

        [HttpPost]
        public IActionResult EditDetails(courseModuleModelList courseModuleModelList)
        {

            _courseModuleRepository.EditCourseModuleData(courseModuleModelList);
            TempData["ModuleEdited"] = "Section Data Updated ";

            return RedirectToAction("CourseModuleDetails");

        }

        public IActionResult DeleteModuleData(int id)
        {
            _courseModuleRepository.DeleteModuleDataRe(id);

            TempData["SectionDeleted"] = "Section Deleted !";

            return RedirectToAction("CourseModuleDetails");
        }





        [HttpGet]
        public IActionResult CourseLectureDetails()
        {

            courseLectureDetailsModelList courseLectureDetailsModelList = new courseLectureDetailsModelList();
            courseLectureDetailsModelList.courseModuleDetailsMstsList = _datacontext.courseModuleDetailsMsts.ToList();
            courseLectureDetailsModelList.courseLectureDetailsLists = _courseLectureRepository.CourseLectureList();
            return View(courseLectureDetailsModelList);
        }

        [HttpPost]
        public IActionResult AddLectureDetail(courseLectureDetailsModelList courseLectureDetailsList)
        {
            courseLectureDetailsList.LectureUploadDate = System.DateTime.Now;
            _courseLectureRepository.AddCourseLecturData(courseLectureDetailsList);
            return RedirectToAction("CourseLectureDetails");
        }

        [HttpPost]
        public JsonResult GetLectureDetails(int id)
        {
            var Data = _datacontext.courseLectureDetailsMsts.Find(id);
            return Json(Data);
        }

        [HttpPost]
        public IActionResult EditCourseLectureData(courseLectureDetailsModelList courseLectureDetailsModelLists)
        {
            _courseLectureRepository.EditCourseLectureData(courseLectureDetailsModelLists);
            return RedirectToAction("CourseLectureDetails");
        }


        public IActionResult deleteLectureDetails(int id)
        {

            _courseLectureRepository.deleteLectureDetails(id);
            return RedirectToAction("CourseLectureDetails");

        }


        [HttpGet]
        public IActionResult AddCourseModuleAndLecture()
        {
            CourseModuleAndLectureModelList courseModuleLecture = new CourseModuleAndLectureModelList();
            courseModuleLecture.courseModuleList = _datacontext.courseModuleDetailsMsts.ToList();
            courseModuleLecture.courseLectureList = _datacontext.courseLectureDetailsMsts.ToList();
            courseModuleLecture.courseDetailsList = _datacontext.courseDetailsMsts.ToList();
            return View(courseModuleLecture);
        }



        [HttpPost]
        public IActionResult AddLectureDataFromAddCourseModuleAndLecture(CourseModuleAndLectureModelList courseModuleAndLectureModel)
        {
            _courseModuleAndLectureRepository.AddDataToLectureFromAdminView(courseModuleAndLectureModel);
            TempData["AddLectureMessage"] = "New Lecture Added";
            return RedirectToAction("AddCourseModuleAndLecture");
        }

        [HttpPost]
        public JsonResult GetLectureDetailsFromModuleAndLectureV(int id)
        {
            var Data = _datacontext.courseLectureDetailsMsts.Where(x => x.courseLectureId == id).FirstOrDefault();
            return Json(Data);
        }

        //[HttpPost]
        //public IActionResult EditLectureDataFromAddCourseModuleAndLecture(CourseModuleAndLectureModelList courseModuleAndLectureModel)
        //{
        //    _courseModuleAndLectureRepository.EditLectureFromAdminView(courseModuleAndLectureModel);
        //    TempData["getModuleId"] = courseModuleAndLectureModel.courseModuleId;
        //    return RedirectToAction("AddCourseModuleAndLecture");
        //}

        public IActionResult DeleteLectureDataFromAddCourseModuleAndLecture(int id)
        {
            _courseModuleAndLectureRepository.DeleteLectureFromAdminView(id);
            TempData["DeleteLecture"] = "Lecture Deleted !";
            return RedirectToAction("AddCourseModuleAndLecture");
        }

        [HttpPost]
        public IActionResult addNewModule(CourseModuleAndLectureModelList courseModuleAndLecture)
        {
            _courseModuleAndLectureRepository.AddModule(courseModuleAndLecture);
            TempData["AddModule"] = " Section Added ";
            return RedirectToAction("AddCourseModuleAndLecture");
        }

        [HttpPost]
        public IActionResult editExitingModule(CourseModuleAndLectureModelList courseModuleAndLecture)
        {
            _courseModuleAndLectureRepository.EditModule(courseModuleAndLecture);
            TempData["EditModule"] = "Section Edited ";
            return RedirectToAction("AddCourseModuleAndLecture");
        }

        public IActionResult deleteModuleAndrelatedLecture(int id)
        {
            _courseModuleAndLectureRepository.DeleteModuleAndLecture(id);
            TempData["ModuleDelete"] = "Section Deleted !";
            return RedirectToAction("AddCourseModuleAndLecture");
        }

        [HttpPost]
        public JsonResult updateUsingAjax(CourseModuleAndLectureModel modal)
        {
            var courselectureMst = new courseLectureDetailsMst()
            {
                courseLectureId = modal.courseLectureId,
                LectureName = modal.LectureName,
                LectureLink = modal.LectureLink,
                LectureUploadDate = System.DateTime.Now,
                courseModuleId = modal.courseModuleId
            };
            _datacontext.courseLectureDetailsMsts.Update(courselectureMst);
            _datacontext.SaveChanges();
            TempData["EditLectureMessage"] = "Lecture Edited !";


            return Json(courselectureMst);
        }
        [HttpPost]
        public JsonResult AddLectureUsingAjaxMe(CourseModuleAndLectureModel modal)
        {
            var lectureMst = new courseLectureDetailsMst()
            {
                //courseLectureId=modal.courseLectureId,
                LectureName = modal.LectureName,
                LectureLink = modal.LectureLink,
                LectureUploadDate = System.DateTime.Now,
                courseModuleId = modal.courseModuleId
            };
            _datacontext.courseLectureDetailsMsts.Add(lectureMst);
            _datacontext.SaveChanges();
            return Json(lectureMst);
        }

        [HttpGet]
        public JsonResult CreateListUsingAjax(CourseModuleAndLectureModelList listLectureModel)
        {

            CourseModuleAndLectureModelList courseModuleAndLectureModelList = new CourseModuleAndLectureModelList();
            courseModuleAndLectureModelList.courseLectureList = _datacontext.courseLectureDetailsMsts.ToList();
            courseModuleAndLectureModelList.courseModuleList = _datacontext.courseModuleDetailsMsts.ToList();

            return Json(courseModuleAndLectureModelList);
        }

        [HttpGet]
        public IActionResult coursePayment()
        {

            paymentRequestModelList paymentRequestModelList = new paymentRequestModelList();
            paymentRequestModelList.coursePaymentRequestList = _datacontext.coursePaymentRequestMsts.ToList();
            return View(paymentRequestModelList);
        }

        [HttpPost]
        public JsonResult UpdateCourseStatus(bool status, int payId)
        {
            var data = _datacontext.coursePaymentRequestMsts.Find(payId);
            var paymentData = new coursePaymentRequestMst()
            {

                paymentId = payId,
                PaymentStatus = status

            };
            var exitingData = _datacontext.coursePaymentRequestMsts.Find(paymentData.paymentId);
            if (exitingData != null)
            {
                exitingData.PaymentStatus = paymentData.PaymentStatus;
                _datacontext.SaveChanges();
            }

            return Json(paymentData);

        }

        public IActionResult DeleteCoursePaymentDetails(int id)
        {
            var findData = _datacontext.coursePaymentRequestMsts.Find(id);

            _datacontext.coursePaymentRequestMsts.Remove(findData);
            _datacontext.SaveChanges();
            TempData["coursePaymentDetails"] = "Course Payment Details Deleted";
            return RedirectToAction("coursePayment");
        }

        [HttpGet]
        public IActionResult courserefreallform()
        {
            CourseReffrealModelList courseReffrealModelList = new CourseReffrealModelList();
            courseReffrealModelList.courseDetailsMsts = _datacontext.courseDetailsMsts.ToList();
            courseReffrealModelList.CourseReffrealModelLists = _courseModuleRepository.courserefrealllist();
            return View(courseReffrealModelList);
        }

        [HttpPost]
        public IActionResult courserefreallform(CourseReffrealModelList refrealladd)
        {
            CourseReffrealMst courseReffrealMst = new CourseReffrealMst()
            {
                courseid = refrealladd.courseid,
                creffrealpoint = refrealladd.creffrealpoint,
                startingdate = refrealladd.startingdate,
                endingdate = refrealladd.endingdate,
                status = refrealladd.status
            };
            _datacontext.courseReffrealMsts.Add(courseReffrealMst);
            _datacontext.SaveChanges();

            return RedirectToAction("courserefreallform");

        }

        [HttpPost]
        public JsonResult UpdateCourseRefreallStatus(Boolean status, int cid)
        {
            var data = _datacontext.courseReffrealMsts.Where(r => r.id == cid).FirstOrDefault();
            if (data != null)
            {
                data.status = status;
                _datacontext.courseReffrealMsts.Update(data);
                _datacontext.SaveChanges();
            }
            return Json(data);

        }

    }
}
