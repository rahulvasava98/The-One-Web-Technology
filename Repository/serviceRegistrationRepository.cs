using System;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;

namespace The_One_Web_Technology.Repository
{
    public class serviceRegistrationRepository
    {
        private readonly Datacontext _datacontext;

        public serviceRegistrationRepository(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }


        public List<serviceRegistrationModel> serviceRegistrationList()
        {
            List<serviceRegistrationModel> list = new List<serviceRegistrationModel>();
            var data = _datacontext.serviceRegistrationMasters.ToList();
            {
                foreach (var item in data)
                {
                    serviceRegistrationModel serviceRegistrationList = new serviceRegistrationModel();
                    serviceRegistrationList.clientId = item.clientId;
                    serviceRegistrationList.clientfirstName = item.clientfirstName;
                    serviceRegistrationList.clientlastName = item.clientlastName;
                    serviceRegistrationList.clientemail = item.clientemail;
                    serviceRegistrationList.clientlocation = item.clientlocation;
                    serviceRegistrationList.clientservice = item.clientservice;
                    serviceRegistrationList.clientmessage = item.clientmessage;
                    serviceRegistrationList.clientPassword = item.clientPassword;
                    serviceRegistrationList.clientReferenceId = item.clientReferenceId;
                    serviceRegistrationList.clientReferenceCode = item.clientReferenceCode;
                    serviceRegistrationList.serviceOtp = item.serviceOtp;
                    serviceRegistrationList.registrationStatus = item.registrationStatus;

                    list.Add(serviceRegistrationList);

                }
            }
            return list;
        }

        //serviceReferenceList
   
        public List<serviceRegistrationModel> serviceReferenceList()
        {
            int cId = 3; 
            List<serviceRegistrationModel> list = new List<serviceRegistrationModel>();
            var data = _datacontext.serviceRegistrationMasters.Where(x => x.clientReferenceId == cId).ToList();
            {
                foreach (var item in data)
                {
                    serviceRegistrationModel serviceRegistrationList = new serviceRegistrationModel();
                    serviceRegistrationList.clientId = item.clientId;
                    serviceRegistrationList.clientfirstName = item.clientfirstName;
                    serviceRegistrationList.clientlastName = item.clientlastName;
                    serviceRegistrationList.clientemail = item.clientemail;
                    serviceRegistrationList.clientlocation = item.clientlocation;
                    serviceRegistrationList.clientservice = item.clientservice;
                    serviceRegistrationList.clientmessage = item.clientmessage;
                    serviceRegistrationList.clientPassword = item.clientPassword;
                    serviceRegistrationList.clientReferenceId = item.clientReferenceId;
                    serviceRegistrationList.clientReferenceCode = item.clientReferenceCode;
                    serviceRegistrationList.serviceOtp = item.serviceOtp;
                    serviceRegistrationList.registrationStatus = item.registrationStatus;
                    list.Add(serviceRegistrationList);

                }
            }
            return list;
        }





        #region addRegistrationData
        public void serviceRegistrationAdd(serviceRegistrationModel serviceRegistrationModel)
        {
            //serviceRegistrationMaster serviceRegistrationData;

            string serviceRefCodeinstring;
            do
            {

                //new added alphanumeric code 
               
                int length = 6;
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
                var random = new Random();
                serviceRefCodeinstring = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (serviceRefCodeinstring == null);

            string generateotp;
            do
            {
                int lenghtOtp = 4;
                string otpChar = "0123456789";
                var random = new Random();
                generateotp = new string(Enumerable.Repeat(otpChar, lenghtOtp).Select(x => x[random.Next(x.Length)]).ToArray());

            } while (generateotp == null && generateotp.Length == 4 );


            serviceRegistrationMaster serviceRegistrationMaster = new serviceRegistrationMaster()
            {
                //clientId = serviceRegistrationModel.clientId,
                clientfirstName = serviceRegistrationModel.clientfirstName,
                clientlastName = serviceRegistrationModel.clientlastName,
                clientemail = serviceRegistrationModel.clientemail,
                clientlocation = serviceRegistrationModel.clientlocation,
                clientservice = serviceRegistrationModel.clientservice,
                clientmessage = serviceRegistrationModel.clientmessage,
                clientPassword = serviceRegistrationModel.clientPassword,
                clientReferenceId = serviceRegistrationModel.clientReferenceId,
                clientReferenceCode = serviceRefCodeinstring,
                serviceOtp = Convert.ToInt32(generateotp)
                //refCodeinstring
            }; 
            _datacontext.serviceRegistrationMasters.Add(serviceRegistrationMaster);
            _datacontext.SaveChanges();
        }

        #endregion
        public List<serviceRegistrationModelList> clientReferralUserList(int id)
        {
            List<serviceRegistrationModelList> list = new List<serviceRegistrationModelList>();
            var Data = _datacontext.serviceRegistrationMasters.Where(s => s.clientReferenceId == id).ToList();
            {
                foreach (var item in Data)
                {
                    serviceRegistrationModelList serviceRegistrationModelList = new serviceRegistrationModelList()
                    {
                         clientId = item.clientId,
                         clientfirstName = item.clientfirstName,
                         clientlastName = item.clientlastName,
                         clientemail = item.clientemail,
                         clientlocation = item.clientlocation,
                         clientservice = item.clientservice,
                         clientmessage = item.clientmessage,
                         clientPassword = item.clientPassword,
                         clientReferenceId = item.clientReferenceId,
                         clientReferenceCode = item.clientReferenceCode,
                         serviceOtp = item.serviceOtp

                    };
                    list.Add(serviceRegistrationModelList);
                }
                return list;

            }
        }

        public void serviceRegistrationEdit(serviceRegistrationModel serviceRegistrationModel)
        {
            serviceRegistrationMaster serviceRegistrationMaster = new serviceRegistrationMaster() { 
                clientId = serviceRegistrationModel.clientId,
                clientfirstName= serviceRegistrationModel.clientfirstName,
                clientlastName= serviceRegistrationModel.clientlastName,
                clientemail= serviceRegistrationModel.clientemail,
                clientlocation = serviceRegistrationModel.clientlocation,
                clientservice = serviceRegistrationModel.clientservice,
                clientmessage = serviceRegistrationModel.clientmessage,
                clientPassword = serviceRegistrationModel.clientPassword,
                clientReferenceId= serviceRegistrationModel.clientReferenceId,
                clientReferenceCode= serviceRegistrationModel.clientReferenceCode,
                serviceOtp = serviceRegistrationModel.serviceOtp
            };
            _datacontext.serviceRegistrationMasters.Update(serviceRegistrationMaster);
            _datacontext.SaveChanges();
        }
        



    }
}
