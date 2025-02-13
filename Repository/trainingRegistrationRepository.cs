using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class trainingRegistrationRepository
    {
        private readonly Datacontext _datacontext;
        private readonly IWebHostEnvironment _webHost;

        public trainingRegistrationRepository(Datacontext datacontext, IWebHostEnvironment webHostEnvironment)
        {
            _datacontext = datacontext;
            _webHost = webHostEnvironment;
        }

        public List<trainingRegistrationModelList> GetTrainingRegistrationList()
        {
            List<trainingRegistrationModelList> list = new List<trainingRegistrationModelList>();
            var data = _datacontext.trainingRegistrationmsts.ToList();
            {
                foreach (var item in data)
                {
                    trainingRegistrationModelList trainingRegistrationModel = new trainingRegistrationModelList();
                    {
                        trainingRegistrationModel.id = item.id;
                        trainingRegistrationModel.firstName = item.firstName;
                        trainingRegistrationModel.lastName = item.lastName;
                        trainingRegistrationModel.phoneNumber = item.phoneNumber;
                        trainingRegistrationModel.Email = item.Email;
                        trainingRegistrationModel.educationQualification = item.educationQualification;
                        trainingRegistrationModel.location = item.location;
                        trainingRegistrationModel.yourMessage = item.yourMessage;
                        trainingRegistrationModel.trainingRegistrationPassword = item.trainingRegistrationPassword;
                        trainingRegistrationModel.referenceId = item.referenceId;
                        trainingRegistrationModel.referenceCode = item.referenceCode;
                        //new Added
                        trainingRegistrationModel.fileUrl = item.fileUrl;
                        trainingRegistrationModel.tOTP = item.tOTP;
                        list.Add(trainingRegistrationModel);
                    }

                }
                return list;
            }
        }

        //myreference list
        public List<trainingRegistrationModelList> mytrainingreferenceList(int id)
        {
            List<trainingRegistrationModelList> list = new List<trainingRegistrationModelList>();
            var data = _datacontext.trainingRegistrationmsts.Where(x => x.referenceId == id).ToList();
            {
                foreach (var item in data)
                {
                    trainingRegistrationModelList trainingRegistrationModelList = new trainingRegistrationModelList()
                    {
                        id = item.id,
                        firstName = item.firstName,
                        lastName = item.lastName,
                        Email = item.Email,
                        educationQualification = item.educationQualification,
                        location = item.location,
                        yourMessage = item.yourMessage,
                        trainingRegistrationPassword = item.trainingRegistrationPassword,
                        referenceId = item.referenceId,
                        referenceCode = item.referenceCode,
                        phoneNumber = item.phoneNumber,
                        //new Added
                        fileUrl = item.fileUrl,
                        tOTP = item.tOTP
                    };
                    list.Add(trainingRegistrationModelList);
                }
            }
            return list;
        }

        public void AddTrainingRegistrationform(trainingRegistrationModel trainingRegistration)
        {
            var random = new Random();

            string GenerateOtp;
            do
            {
                int otpLength = 4;
                string numbers = "0123456789";
                GenerateOtp = new string(Enumerable.Repeat(numbers, otpLength).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (GenerateOtp == null);

            string trainingReferalCode;
            do
            {

                int legnth = 6;
                string character = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                //var random = new Random();
                trainingReferalCode = new string(Enumerable.Repeat(character, legnth).Select(s => s[random.Next(s.Length)]).ToArray());

            } while (trainingReferalCode == null);

            var folder = "";

            if (trainingRegistration.formFile != null)
            {
                folder = "uploadedResume/" + Guid.NewGuid() + trainingRegistration.formFile.FileName;
                var pathResumeFolder = Path.Combine(_webHost.WebRootPath, folder);
                trainingRegistration.formFile.CopyTo(new FileStream(pathResumeFolder, FileMode.Create));

            }



            trainingRegistrationmst trainingRegistrationmsts = new trainingRegistrationmst()
            {
                firstName = trainingRegistration.firstName,
                lastName = trainingRegistration.lastName,
                phoneNumber = trainingRegistration.phoneNumber,
                Email = trainingRegistration.Email,
                educationQualification = trainingRegistration.educationQualification,
                location = trainingRegistration.location,
                yourMessage = trainingRegistration.yourMessage,
                trainingRegistrationPassword = trainingRegistration.trainingRegistrationPassword,
                referenceId = Convert.ToInt32(trainingRegistration.referenceId),
                referenceCode = trainingReferalCode,

                //new Added

                tOTP = Convert.ToInt32(GenerateOtp),
                fileUrl = folder,


            };
            _datacontext.trainingRegistrationmsts.Add(trainingRegistrationmsts);
            _datacontext.SaveChanges();
        }

        //don't uncomment below function 
        //public void DetailsTrainingRegistration(trainingRegistrationModel trainingRegistrationModel )
        //{
        //	var data = _datacontext.trainingRegistrationmsts.FirstOrDefault();
        //	{
        //              trainingRegistrationModel.id = data.id;
        //              trainingRegistrationModel.firstName = data.firstName;
        //              trainingRegistrationModel.lastName = data.lastName;
        //              trainingRegistrationModel.phoneNumber = data.phoneNumber;
        //              trainingRegistrationModel.Email = data.Email;
        //              trainingRegistrationModel.educationQualification = data.educationQualification;
        //              trainingRegistrationModel.location = data.location;
        //              trainingRegistrationModel.yourMessage = data.yourMessage;
        //              trainingRegistrationModel.trainingRegistrationPassword = data.trainingRegistrationPassword;
        //              trainingRegistrationModel.referenceId = data.referenceId;
        //              trainingRegistrationModel.referenceCode = data.referenceCode;
        //          }	
        //      }
        //don't uncomment upper function 


        public void EditTrainingDetails(trainingRegistrationModel trainingRegistrationModel)
        {
            var pathToUpdate = Path.Combine(_webHost.WebRootPath, "uploadedResume");

   
            if ((trainingRegistrationModel.fileUrl != null) && trainingRegistrationModel.formFile != null)
            {
                var existingResume = (trainingRegistrationModel.fileUrl).Split("/");
                var exitingFilePath = Path.Combine(_webHost.WebRootPath, pathToUpdate, existingResume[1]);

                if (existingResume != null)
                {
                    if (System.IO.File.Exists(exitingFilePath))
                    {
                        System.IO.File.Delete(exitingFilePath);
                    }

                }
            }

            if (trainingRegistrationModel.formFile != null)
            {

                var updatedResume = Guid.NewGuid() + trainingRegistrationModel.formFile.FileName;

                var updatedresumepath = Path.Combine(_webHost.WebRootPath, pathToUpdate, updatedResume);

                using (var stream = new FileStream(updatedresumepath, FileMode.Create))
                {
                    trainingRegistrationModel.formFile.CopyTo(stream);
                }


                var data = _datacontext.trainingRegistrationmsts.Find(trainingRegistrationModel.id);
                var trainingRegistration = new trainingRegistrationmst(){
                    id  = data.id,
                    fileUrl = "uploadedResume/" + updatedResume
                };
                var existData = _datacontext.trainingRegistrationmsts.Find(trainingRegistration.id);
                if (existData != null) { 
                    existData.fileUrl = trainingRegistration.fileUrl;
                    _datacontext.SaveChanges();
                }

            }
            //update individual field

            if (trainingRegistrationModel.id != null ) {

                var data = _datacontext.trainingRegistrationmsts.Find(trainingRegistrationModel.id);
                var trainingRegistration = new trainingRegistrationmst()
                { 
                        id = data.id,
                        firstName = trainingRegistrationModel.firstName,
                        lastName = trainingRegistrationModel.lastName,
                        phoneNumber = trainingRegistrationModel.phoneNumber,
                        Email = trainingRegistrationModel.Email,
                        educationQualification = trainingRegistrationModel.educationQualification,  
                        location = trainingRegistrationModel.location,  
                        yourMessage = trainingRegistrationModel.yourMessage,
                        trainingRegistrationPassword = trainingRegistrationModel.trainingRegistrationPassword,
                        referenceId = Convert.ToInt32(trainingRegistrationModel.referenceId)
                };
                var existData = _datacontext.trainingRegistrationmsts.Find(trainingRegistration.id);
                if (existData != null) {
                    existData.firstName = trainingRegistration.firstName;
                    existData.lastName = trainingRegistration.lastName;
                    existData.phoneNumber = trainingRegistration.phoneNumber;
                    existData.Email = trainingRegistration.Email;
                    existData.educationQualification = trainingRegistration.educationQualification;
                    existData.location = trainingRegistration.location;
                    existData.yourMessage = trainingRegistration.yourMessage;
                    existData.trainingRegistrationPassword = trainingRegistration.trainingRegistrationPassword;
                    existData.referenceId = trainingRegistration.referenceId;
                    //_datacontext.trainingRegistrationmsts.Update(existData);
                    _datacontext.SaveChanges();

                }
                
            }

        }

}
}
