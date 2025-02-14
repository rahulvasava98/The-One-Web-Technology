using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Migrations;
using The_One_Web_Technology.Models;
using The_One_Web_Technology.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace The_One_Web_Technology.Controllers
{
    public class TrainingController : Controller
    {
        //registration start
        private readonly Datacontext _datacontext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly courseDetailsRepository _courseDetailsRepository;
        private readonly trainingRegistrationRepository _trainingRegistrationRepository;
        private readonly courseRequestHandleRepository _courseRequestHandleRepository;
        private readonly courseLikeRepository _courseLikeRepository;
        private readonly cartRepository _cartRepository;

        public TrainingController(Datacontext datacontext,IWebHostEnvironment webHostEnvironment)
        {
            _datacontext = datacontext;
            _webHostEnvironment = webHostEnvironment;
            _courseDetailsRepository = new courseDetailsRepository(datacontext);
            _trainingRegistrationRepository = new trainingRegistrationRepository(datacontext,webHostEnvironment);
            _courseRequestHandleRepository = new courseRequestHandleRepository(datacontext);
            _courseLikeRepository = new courseLikeRepository(datacontext);
            _cartRepository = new cartRepository(datacontext);

        }


        public IActionResult welcomeView()
        {
            //TrainingregistrationDataShow
            return View();
        }
        [HttpGet]
        public IActionResult TrainingregistrationForm(string id)
        {
            trainingRegistrationModel trainingRegistrationModel = new trainingRegistrationModel();

            var data = _datacontext.trainingRegistrationmsts.Where(x => x.referenceCode == id).FirstOrDefault();
            if (data != null)
            {
                trainingRegistrationModel.referenceId = data.id;
            }

            return View(trainingRegistrationModel);
        }

        [HttpPost]
        public IActionResult TrainingregistrationForm(trainingRegistrationModel trainingRegistration)
        {
            if (ModelState.IsValid)
            {
                _trainingRegistrationRepository.AddTrainingRegistrationform(trainingRegistration);
                var data = _datacontext.trainingRegistrationmsts.Where(x => x.firstName == trainingRegistration.firstName && x.lastName == x.lastName && x.Email == trainingRegistration.Email).FirstOrDefault();
                int idS = 0;
                if(data != null)
                {
                    idS = data.id;
                }

                return RedirectToAction("trainingRegistrationOtp", new { id = idS});

            }

            return View("TrainingregistrationForm");
        }

        [HttpGet]
        public IActionResult trainingRegistrationOtp(int id)
        {
            trainingRegistrationModel trainingloginModel = new trainingRegistrationModel()
            {
                id = id
            };
            var data = _datacontext.trainingRegistrationmsts.Find(id);
            if(data != null)
            {
                TempData["sendLoginOtp"] = "Your OTP for The One Web Technology registration is " + data.tOTP;
            }
            return View(trainingloginModel);
        }
        [HttpPost]
        public IActionResult trainingRegistrationOtp(trainingRegistrationModel trainingRegistration)
        {   

            var data = _datacontext.trainingRegistrationmsts.Where(x => x.tOTP == trainingRegistration.tOTP).FirstOrDefault();
            if(data != null)
            {
                return RedirectToAction("welcomeView");
            }
            return View("trainingRegistrationOtp");
        }



        [HttpGet]
        public IActionResult trainingLoginform()
        {

            return View();
        }

        [HttpPost]
        public IActionResult trainingLoginform(trainingloginModel trainingloginModel)
        {
            var data = _datacontext.trainingRegistrationmsts.Where(x => x.Email == trainingloginModel.Email &&
                                                                        x.trainingRegistrationPassword == trainingloginModel.trainingRegistrationPassword).FirstOrDefault();
            if (data == null)
            {
                TempData["loginError"] = "Email Or Password Is Not Correct";                
                return RedirectToAction("trainingLoginform",new {trainingloginModel.Email});
            }
            else
            {
                return RedirectToAction("studentProfile", new { id = data.id });
            }
        }

        [HttpPost]
        public JsonResult forgetPasswordTrainee(string email)
        {
            trainingloginModel traininglogin = new trainingloginModel() { 
                Email = email
            };
            //return Json(new {RedirectToAction = Url.Action("forgettrainingPassword", traininglogin.Email) });
            return Json("forgettrainingPassword", new { email = traininglogin.Email });
        }

        [HttpGet]
        public IActionResult forgettrainingPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult forgettrainingPassword(trainingloginModel traingLogin)
        {
            if (ModelState.IsValid)
            {
            return RedirectToAction("contactUsform");
            }
            return RedirectToAction("forgettrainingPassword");
        }

        [HttpGet]
        public IActionResult contactUsform()
        {
            return View();
        }

        [HttpGet]
        public IActionResult studentProfile(int id)
        {

            trainingRegistrationModelList trainingRegistrationModel = new trainingRegistrationModelList();

            trainingRegistrationModel.trainingRegistrationModelLists = _trainingRegistrationRepository.mytrainingreferenceList(id);
            //trainingRegistrationModel trainingRegistrationModel = new trainingRegistrationModel();

            //var find = _datacontext.trainingRegistrationmsts.Find(id);

            //add where query on 10_feb_25
            var find = _datacontext.trainingRegistrationmsts.Where(x => x.id == id).FirstOrDefault();
            if (find != null)
            {
                trainingRegistrationModel.id = find.id;
                trainingRegistrationModel.firstName = find.firstName;
                trainingRegistrationModel.lastName = find.lastName;
                trainingRegistrationModel.phoneNumber = find.phoneNumber;
                trainingRegistrationModel.Email = find.Email;
                trainingRegistrationModel.educationQualification = find.educationQualification;
                trainingRegistrationModel.location = find.location;
                trainingRegistrationModel.yourMessage = find.yourMessage;
                trainingRegistrationModel.trainingRegistrationPassword = find.trainingRegistrationPassword;
                trainingRegistrationModel.referenceId = find.referenceId;
                trainingRegistrationModel.referenceCode = find.referenceCode;
                trainingRegistrationModel.fileUrl = find.fileUrl;
                trainingRegistrationModel.tOTP = find.tOTP;
                return View(trainingRegistrationModel);
            }
            return Content("Student Data Not Found");


        }

        [HttpPost]
        public IActionResult studentProfile(trainingRegistrationModel trainingRegistration)
        {
            _trainingRegistrationRepository.EditTrainingDetails(trainingRegistration);
            return View("profileEdited");
        
        }

        //registration end
        public IActionResult internship()
        {
            return View();
        }

        public IActionResult payafterplacement()
        {
            return View();
        }


        [HttpGet]
        public IActionResult offlineCourses()
        {
            courseDetailsModelList courseDetails = new courseDetailsModelList();
            courseDetails.courseDetailsModelLists = _courseDetailsRepository.courseDetailsList();
            return View(courseDetails);
        }

        [HttpGet]
        public IActionResult courseCollectionView()
        {
            courseDetailsModelList courseDetails = new courseDetailsModelList();
            courseDetails.courseDetailsModelLists = _courseDetailsRepository.courseDetailsList();
            courseDetails.courseLikeModels = _courseLikeRepository.courseLikeMstList();
            //courseDetails.courseLikeMsts = _datacontext.courseLikeMsts.ToList();
            //courseDetails.courseDetailsModelLists = _courseDetailsRepository.courseDetailsList();
            //courseDetails.courseDetailsModelLists = _courseDetailsRepository.courrseLikeList();
            //courseDetails.courseLikeMsts = _datacontext.courseLikeMsts.ToList();
            //int studentId = 1;
            //var Data = _datacontext.courseLikeMsts.Where(x => x.userIds == studentId).FirstOrDefault();
            //    //.Select(i => i.courseIds).FirstOrDefault();
            //if(Data != null)
            //{
            //courseDetails.courseId = data.courseId;
            //    //courseDetails.courseName = data.courseName;
            //    //courseDetails.courseLevel = data.courseLevel;
            //    //courseDetails.courseInstructor = data.courseInstructor;
            //    //courseDetails.courseActiveStatus = data.courseActiveStatus;
            //    //courseDetails.courseCategories = data.courseCategories;
            //    //courseDetails.videoLink = data.videoLink;

            //    //likeMst                
            //    courseDetails.courselikeID = Data.courselikeID;
            //    courseDetails.courseliked;status = Data.courselikedstatus;
            //    courseDetails.courseIds = Data.courseIds;
            //    courseDetails.userIds = Data.userIds;
            //    courseDetails.courseLikeTime = Data.courseLikeTime;

            //}
            return View(courseDetails);
        }

        [HttpGet]
        public IActionResult courseIntroduction(int id)
        {
            int studentId = 1;
            int courseDetailrow = id;
            var comparedata = _datacontext.courseRequestHandleMsts.Where(x => x.courseDetailsId == id && x.studentRequestedId == studentId).FirstOrDefault();
            var getLikeMstData = _datacontext.courseLikeMsts.Where(x => x.courseIds == id && x.userIds == studentId).FirstOrDefault();
            courseDetailsModelList courseDetails = new courseDetailsModelList();
            var data = _datacontext.courseDetailsMsts.Find(id);
            if (data != null) {

                courseDetails.courseId = data.courseId;
                courseDetails.courseName = data.courseName;
                courseDetails.courseLevel = data.courseLevel;
                courseDetails.courseInstructor = data.courseInstructor;
                courseDetails.courseActiveStatus = data.courseActiveStatus;
                courseDetails.courseCategories = data.courseCategories;
                courseDetails.videoLink = data.videoLink;
                courseDetails.courseWallpaper = data.courseWallpaper;


            }
            if (courseDetailrow == 13)
            {
                courseDetails.courseId = data.courseId;
                courseDetails.courseName = data.courseName;
                courseDetails.courseLevel = data.courseLevel;
                courseDetails.courseInstructor = data.courseInstructor;
                courseDetails.courseActiveStatus = data.courseActiveStatus;
                courseDetails.courseCategories = data.courseCategories;
                courseDetails.videoLink = data.videoLink;
                courseDetails.courseWallpaper = data.courseWallpaper;

                //likeMst                

                //courseDetails.courselikeID = getLikeMstData.courselikeID;
                //courseDetails.courselikedstatus = getLikeMstData.courselikedstatus;
                //courseDetails.courseIds = getLikeMstData.courseIds;
                //courseDetails.userIds = getLikeMstData.userIds;
                //courseDetails.courseLikeTime = getLikeMstData.courseLikeTime;
            }
            if (comparedata != null)
            {

                courseDetails.courseId = data.courseId;
                courseDetails.courseName = data.courseName;
                courseDetails.courseLevel = data.courseLevel;
                courseDetails.courseInstructor = data.courseInstructor;
                courseDetails.courseActiveStatus = data.courseActiveStatus;
                courseDetails.courseCategories = data.courseCategories;
                courseDetails.videoLink = data.videoLink;
                courseDetails.courseWallpaper = data.courseWallpaper;
                courseDetails.cRequestId = comparedata.cRequestId;
                courseDetails.studentRequestedId = comparedata.studentRequestedId;
                courseDetails.courseDetailsId = comparedata.courseDetailsId;
                courseDetails.courseRequestedName = comparedata.courseRequestedName;
                courseDetails.courseAccesstatus = comparedata.courseAccesstatus;
                courseDetails.courseRequestTIme = comparedata.courseRequestTIme;
                //likeMst                
                courseDetails.courselikeID = getLikeMstData.courselikeID;
                courseDetails.courselikedstatus = getLikeMstData.courselikedstatus;
                courseDetails.courseIds = getLikeMstData.courseIds;
                courseDetails.userIds = getLikeMstData.userIds;
                courseDetails.courseLikeTime = getLikeMstData.courseLikeTime;
            }
            return View(courseDetails);

        }

        [HttpGet]
        public IActionResult fullstackcourse()
        {
            return View();
        }

        [HttpGet]
        public IActionResult findIdOfCourseId(int id)
        {
            courseDetailsModel courseDetails = new courseDetailsModel();
            var data = _datacontext.serviceMsts.Find(id);
            return View(courseDetails);

        }
        public IActionResult frontendcourse()
        {
            return View();
        }

        public IActionResult courselanding()
        {
            return View();
        }

        public IActionResult backendcourse()
        {
            return View();
        }

        public IActionResult courseWishlist()
        {
            return View();

        }

        [HttpGet]
        public IActionResult cart()
        {

            cartModelList cartModel = new cartModelList();
            cartModel.cartModelLists = _cartRepository.cartModelList();
            return View(cartModel);
        }

        [HttpPost]
        public IActionResult addToCart(courseDetailsModelList courseDetailsModelLists)
        {
            var AddToCart = new cartMst
            {

                courseName = courseDetailsModelLists.courseName,
                courseInstructor = courseDetailsModelLists.courseInstructor,
                courseWallpaper = courseDetailsModelLists.courseWallpaper,
                courseId = courseDetailsModelLists.courseId,

            };
            _datacontext.cartMsts.Add(AddToCart);
            _datacontext.SaveChanges();

            return RedirectToAction("courseIntroduction", new { id = courseDetailsModelLists.courseId });
        }

        [HttpGet]
        public IActionResult courseCardsLink(int courseId)
        {
            courseDetailsModel courseDetailsModels = new courseDetailsModel();
            var data = _datacontext.courseDetailsMsts.Find(courseId);
            courseDetailsModels.courseId = data.courseId;
            courseDetailsModels.courseName = data.courseName;
            courseDetailsModels.courseInstructor = data.courseInstructor;
            courseDetailsModels.courseLevel = data.courseLevel;
            courseDetailsModels.courseCategories = data.courseCategories;
            courseDetailsModels.courseActiveStatus = data.courseActiveStatus;
            courseDetailsModels.courseWallpaper = data.courseWallpaper;
            courseDetailsModels.videoLink = data.videoLink;
            return View(courseDetailsModels);
        }

        //[HttpGet]
        //public IActionResult GetcoursesBuyerId(int id)
        //{
        //    //_courseRequestHandleRepository.AddcourseRequestHandleModelListofData(coursecollectionModelList);
        //    var studentId = 1;

        //    courseRequestHandleModelList courseRequestHandleModelList = new courseRequestHandleModelList();
        //    courseRequestHandleModelList.courseRequestHandleModelLists = _courseRequestHandleRepository.courseRequestHandleModelListofData();
        //    return RedirectToAction("AddCourseRequestData");
        //}




        public IActionResult liveOnlineCourses()
        {
            return View();
        }


        //addcourseRequestData start 
        [HttpPost]
        public IActionResult AddCourseRequestData(courseDetailsModelList courseDetailsModelLists)
        {
            courseRequestHandleMst courseRequestHandleMst = new courseRequestHandleMst()
            {
                studentRequestedId = courseDetailsModelLists.studentRequestedId,
                courseDetailsId = courseDetailsModelLists.courseDetailsId,
                courseRequestedName = courseDetailsModelLists.courseRequestedName,
                courseAccesstatus = courseDetailsModelLists.courseAccesstatus,
                courseRequestTIme = courseDetailsModelLists.courseRequestTIme
            };
            _datacontext.courseRequestHandleMsts.Add(courseRequestHandleMst);
            _datacontext.SaveChanges();

            return RedirectToAction("SubscrptionBillingPage", new { id = courseDetailsModelLists.courseDetailsId });
        }

        //addcourseRequestData end
        [HttpGet]
        public IActionResult SubscrptionBillingPage(int id)
        {
            //var data = _datacontext.courseDetailsMsts.Where(x => x.courseId == id).FirstOrDefault();
            //courseDetailsModel courseDetailsModel = new courseDetailsModel();
            var data = _datacontext.courseDetailsMsts.Find(id);            
                courseDetailsModel detailsModelList = new courseDetailsModel() { 
                courseId = data.courseId,
                courseName = data.courseName,
                courseInstructor = data.courseInstructor,
                courseCategories = data.courseCategories,
                courseLevel = data.courseLevel,
                courseActiveStatus = data.courseActiveStatus,
                courseWallpaper = data.courseWallpaper,
                videoLink = data.videoLink
            
            };
            
            return View(detailsModelList);

        }

        

        //[HttpPost]
        //public IActionResult AddPaymentDetailsData(courseDetailsModel courseDetails)        
        //{
        //    var studentId = 1; 
        //    var folder = "img/" + courseDetails.filelink.FileName;
        //    var paymentImgFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
        //    courseDetails.filelink.CopyTo(new FileStream(paymentImgFolder, FileMode.Create));

        //    var Data = new coursePaymentRequestMst()
        //    {
        //        courseId = courseDetails.courseId,
        //        courseName = courseDetails.courseName,
        //        cRequestId = courseDetails.cRequestId,
        //        StudentId = studentId,
        //        FileUrl = folder
        //    };
        //    _datacontext.coursePaymentRequestMsts.Add(Data);
        //    _datacontext.SaveChanges();
        //    return View(courseDetails);

        //}
        [HttpPost]
        public IActionResult AddPaymentData(courseDetailsModel courseDetails)
        {
            var studentId = 1;

            //var ImgData = courseDetails.filelink;
            var FindstudentIdRequest = _datacontext.courseRequestHandleMsts.Where(x => x.studentRequestedId == studentId).FirstOrDefault();
            var getList = _datacontext.courseRequestHandleMsts.Where(x => x.studentRequestedId == studentId).ToList();
            var folder = "uploadedimg/" + courseDetails.imglink.FileName;
            var paymentImgFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            courseDetails.imglink.CopyTo(new FileStream(paymentImgFolder, FileMode.Create));
           
            var Data = new coursePaymentRequestMst()
            {
                courseId = courseDetails.courseId,
                courseName = courseDetails.courseName,
                cRequestId = FindstudentIdRequest.cRequestId,
                StudentId = studentId,
                FileUrl = folder
            };
            _datacontext.coursePaymentRequestMsts.Add(Data);
            _datacontext.SaveChanges();

            TempData["RequesSent"] = "Request Sent Successfully";

            return RedirectToAction("SubscrptionBillingPage", new { id = courseDetails.courseId });

        }

        
        //courseLikeMst 

        [HttpPost]
        public JsonResult courseLikeWithDb(int id, bool likestatus, int likeId)
        {
            var likestatusData = likestatus;
            var studId = 1;
            var Data = _datacontext.courseLikeMsts.Where(x => x.courseIds == id && x.userIds == studId).FirstOrDefault();

            if (Data != null)
            {
                courseLikeMst courseLikeMsts = new courseLikeMst();
                var datatemp = _datacontext.courseLikeMsts.Find(likeId);
                {
                    Data.courselikeID = likeId;
                    Data.courseLikeTime = System.DateTime.Now;
                    Data.courselikedstatus = likestatusData;
                };

                _datacontext.courseLikeMsts.Update(datatemp);
                _datacontext.SaveChanges();
                return Json(datatemp);
            }
            else
            {
                courseLikeMst courseLikeMsts = new courseLikeMst()
                {
                    courseIds = id,
                    userIds = studId,
                    courseLikeTime = System.DateTime.Now,
                    //courselikedstatus = likestatusData
                };
                _datacontext.courseLikeMsts.Add(courseLikeMsts);
                _datacontext.SaveChanges();
                return Json(courseLikeMsts);
            }


        }

        //public IActionResult on

        [HttpPost]
        public JsonResult UpdateStatusLike(bool likeStatus, int id)
        {
            var CourselikeStatus = likeStatus;
            var courseId = id;
            var Data = _datacontext.courseLikeMsts.Where(x => x.courseIds == id).FirstOrDefault();
            courseDetailsModelList courseDetailsModel = new courseDetailsModelList();
            if (Data != null)
            {
                courseLikeMst courseLikeMst = new courseLikeMst()
                {
                    courselikedstatus = CourselikeStatus

                };
                _datacontext.courseLikeMsts.Update(courseLikeMst);
                _datacontext.SaveChanges();
                return Json(courseLikeMst);

            }
            return Json(courseDetailsModel);


        }


        public IActionResult selfPaceCourses()
        {
            return View();
        }
        public IActionResult C_plush()
        {
            return View();
        }

        public IActionResult C_shap()
        {
            return View();
        }
        public IActionResult JavaScript()
        {
            return View();
        }


        [HttpGet]
        public IActionResult playvideo(int id,int chid = 6 )
        {

            var Data = _datacontext.courseDetailsMsts.Join(_datacontext.courseModuleDetailsMsts, x => x.courseId, y => y.courseId, (x, y) => new
            {

                courseId = x.courseId,
                courseName = x.courseName,
                courseinstuctor = x.courseInstructor,
                courseCategories = x.courseCategories,
                courseLevel = x.courseLevel,
                courseActivestatus = x.courseActiveStatus,
                courseWallpaper = x.courseWallpaper,
                videoLink = x.videoLink,
                courseModuleId = y.courseModuleId,
                SectionNAme = y.SectionName
                
            }).Where(x=>x.courseId==id).FirstOrDefault();


            //var findData = Data.Where(x => x.courseId == id).FirstOrDefault();
            if (Data != null)
            {
                courseLandingPageModelList list = new courseLandingPageModelList()
                {

                    courseId = Data.courseId,
                    courseName = Data.courseName,
                    courseInstructor = Data.courseinstuctor,
                    courseCategories = Data.courseCategories,
                    courseLevel = Data.courseLevel,
                    courseActiveStatus = Data.courseActivestatus,
                    courseWallpaper = Data.courseWallpaper,
                    videoLink = Data.videoLink,
                    courseModuleId = Data.courseModuleId,
                    SectionName = Data.SectionNAme,                                      

                };
                list.CourseModuleDetailsmstList = _datacontext.courseModuleDetailsMsts.Where(x => x.courseId == id).ToList();
                
                list.courseLectureDetailsMstList = _datacontext.courseLectureDetailsMsts.ToList();
                var datalcid = list.courseLectureDetailsMstList.Where(x => x.courseLectureId == chid).Select(x =>new{x.LectureLink }).FirstOrDefault();

                if (datalcid !=null)
                {
                    string Lecture = datalcid.LectureLink;
                    list.LectureLink = (Lecture);                   
                }
                return View(list);


            }            
            return View("playvideo", new {id = id});

           }

        //[HttpPost]
        //public IActionResult GetcourseandLectureId(int id , int Lecid)
        //{

        //        return RedirectToAction("playvideo", new {id = id , chid = Lecid });
        //}

        [HttpPost]
        public JsonResult returnLetureLinkAction(int Id)
        {
            var Data = _datacontext.courseLectureDetailsMsts.Where(x => x.courseLectureId == Id).FirstOrDefault();            
            return Json(new { Data.LectureLink ,Id, Data.courseModuleId});
        }



    

       
        


    }
}

