using Microsoft.AspNetCore.Mvc;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;
using The_One_Web_Technology.Repository;

namespace The_One_Web_Technology.Controllers
{
    public class ServicesController : Controller
    {
        private readonly Datacontext _datacontext;
        private readonly serviceRegistrationRepository _serviceRegistrationRepository;

        public ServicesController(Datacontext datacontext)
        {
            _datacontext = datacontext;
            _serviceRegistrationRepository = new serviceRegistrationRepository(datacontext);

        }

                
        [HttpGet]
        public IActionResult serviceRegistrationForm(string id)
        {
            //parameter of this method 
            serviceRegistrationModel serviceRegistrationModel = new serviceRegistrationModel();
            var data = _datacontext.serviceRegistrationMasters.Where(x => x.clientReferenceCode == id).FirstOrDefault();
            if (data != null)
            {
                serviceRegistrationModel.clientReferenceId = data.clientId;

            }
            return View(serviceRegistrationModel);

        }       
        [HttpPost]
        public IActionResult serviceRegistrationForm(serviceRegistrationModel serviceRegistration) {
            
            if(ModelState.IsValid){

                _serviceRegistrationRepository.serviceRegistrationAdd(serviceRegistration);
                return RedirectToAction("servcieOtpVarification");

            }
            else
            {
                return View("serviceRegistrationForm");
            }
        }

        [HttpGet]
        public IActionResult DemoRegistration()
        {
            serviceRegistrationModel serviceRegistrationModel = new serviceRegistrationModel();
            return View(serviceRegistrationModel);
        }

        [HttpPost]

        public IActionResult DemoRegistration(serviceRegistrationModel serviceRegistration)
        {
            if (ModelState.IsValid)
            {

                _serviceRegistrationRepository.serviceRegistrationAdd(serviceRegistration);
                return RedirectToAction("servcieOtpVarification");

            }
            return RedirectToAction("DemoRegistration");
        }


       
        [HttpGet]
        public IActionResult servcieOtpVarification()
        {
            return View();
        }

        [HttpPost]
        public IActionResult servcieOtpVarification(serviceRegistrationModel serviceRegistration)
        {
            var data = _datacontext.serviceRegistrationMasters.Where(x => x.serviceOtp == serviceRegistration.getotp).FirstOrDefault();
            if(data != null)
            {
                var filed = _datacontext.serviceRegistrationMasters.Find(data.clientId);
                {
                    filed.clientId = data.clientId;
                    filed.registrationStatus = true;
                }
                _datacontext.serviceRegistrationMasters.Update(filed);
                _datacontext.SaveChanges();

                return View("registrationCompleted"); 

            }
            else
            {
                TempData["otpNotMatched"] = "OTP IS NOT Matched";
                return View("servcieOtpVarification");
            }

        }

        [HttpGet]
        public IActionResult registrationCompleted()
        {
            return View();
        }


        [HttpGet]
        public IActionResult clientProfile(int id)
        {
            serviceRegistrationModelList serviceRegistrationModelLists = new serviceRegistrationModelList();
            serviceRegistrationModelLists.serviceRegistrationModelLists = _serviceRegistrationRepository.clientReferralUserList(id);
            var find = _datacontext.serviceRegistrationMasters.Find(id);
            serviceRegistrationModelLists.clientId = find.clientId;
            serviceRegistrationModelLists.clientfirstName = find.clientfirstName;
            serviceRegistrationModelLists.clientlastName = find.clientlastName;
            serviceRegistrationModelLists.clientemail = find.clientemail;
            serviceRegistrationModelLists.clientlocation = find.clientlocation;
            serviceRegistrationModelLists.clientservice = find.clientservice;
            serviceRegistrationModelLists.clientmessage = find.clientmessage;
            serviceRegistrationModelLists.clientPassword = find.clientPassword;
            serviceRegistrationModelLists.clientReferenceCode = find.clientReferenceCode;
            serviceRegistrationModelLists.clientReferenceId = find.clientReferenceId;
            serviceRegistrationModelLists.serviceOtp = find.serviceOtp;
            return View(serviceRegistrationModelLists);
        }

        [HttpPost]
        public IActionResult clientProfile(serviceRegistrationModelList serviceRegistrationModel)
        {
            _serviceRegistrationRepository.serviceRegistrationEdit(serviceRegistrationModel);
            return View("profileEdited");
        }

        [HttpGet]
        public IActionResult serviceUserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult serviceUserLogin(serviceRegistrationModel serviceRegistrationModel) 
        {

            var data = _datacontext.serviceRegistrationMasters.Where(x => x.clientemail == serviceRegistrationModel.clientemail &&
                                                                          x.clientPassword == serviceRegistrationModel.clientPassword).FirstOrDefault();
            if(data != null)
            {
                return View("loginSuccessfull");
            }
            else
            {
                return View("loginFailed");
            }
        }


        //[HttpPost]
        //public IActionResult matchEmail() { 
            
        //}

        
        public IActionResult webdevelopment()
        {
            return View();
        }

        public IActionResult softwaredevelopment()
        {
            return View();
        }

        public IActionResult mobileapp()
        {
            return View();
        }

        public IActionResult embededsystem()
        {
            return View();
        }

        public IActionResult graphicdesign()
        {
            return View();
        }
        public IActionResult azure()
        {
            return View();
        }
        public IActionResult webdomainmaintenance()
        {
            return View();
        }

        public IActionResult seooptimazation()
        {
            return View();
        }

        public IActionResult bulksmsandemail()
        {
            return View();
        }

        public IActionResult business()
        {
            return View();
        }

        public IActionResult businessconsultant()
        {
            return View();
        }

    }
}
