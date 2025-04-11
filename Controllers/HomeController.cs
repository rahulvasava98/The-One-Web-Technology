using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using The_One_Web_Technology.Data;
using The_One_Web_Technology.Models;
using The_One_Web_Technology.Repository;

namespace The_One_Web_Technology.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly Datacontext _datacontext;
        private readonly contactRepository _contactRepository;
        public HomeController(Datacontext datacontext)
        {
            _datacontext = datacontext;
            _contactRepository = new contactRepository(datacontext);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult about()
        {
            return View();
        }


        public IActionResult services()
        {
            return View();
        }

        public IActionResult training()
        {
            return View();
        }


        public IActionResult digitalmarketing()
        {
            return View();
        }

        public IActionResult franfranchise()
        {
            return View();
        }

        public IActionResult carrer()
        {
            return View();
        }

        public IActionResult contactus()
        {
            return View();
        }

        // inquari form
        [HttpGet]
        public IActionResult inquiry()
        {
            return View();
        }
        [HttpPost]    
        public IActionResult inquiryform(contactModel contactModel)
        {
            _contactRepository.AddContact(contactModel);
            return RedirectToAction("ContactUsReplay");
        }


        public IActionResult ContactUsReplay()
        {
            return View();
        }

        //traning form
        public IActionResult trainingInqurieForm()
        {
            return View();
        }

        public IActionResult temp()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Brand360()
        {
            return View();
        }

        public IActionResult DemoBanner()
        {
            return View();
        }


    }
}
