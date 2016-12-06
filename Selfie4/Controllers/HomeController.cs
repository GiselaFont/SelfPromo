using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Data;
using Selfie4.Data;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ActionResult Experience()
        {
            ViewBag.Title = "Experience";
            var vm = new ExperienceViewModel();

            using (DataModel dm = new DataModel())
            {
                foreach (var j in dm.Job.Include("Jobhighlight").OrderByDescending(s => s.StartDate))
                {
                    if (j.IsProfessional)
                    {
                        vm.ProfessionalJob.Add(j);
                    }
                    else
                    {
                        vm.Activities.Add(j);
                    }
                    
                }
                
            }
                return View(vm);
        }

        public ActionResult Education()
        {
            ViewBag.Title = "Education";
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModels m)
        {
            ViewBag.Title = "Contact";
            int count = 0;
            if (!String.IsNullOrEmpty(m.contact_phone))
            {


                for (int i = 0; i < m.contact_phone.Length; i++)
                {
                    if (Char.IsNumber(m.contact_phone[i]))
                    {
                        count++;
                    }

                }
            }
           
            String name = m.contact_name.Trim();
            if((count == 10 && (name.Contains(" ")) || String.IsNullOrEmpty(m.contact_phone) && name.Contains(" ")))
            {
                return RedirectToAction("ContactAcknowledgement");
            }
            if(count < 10 && !name.Contains(" "))
            {
                ModelState.AddModelError("contact_phone", "The phone number entered is not valid");
                ModelState.AddModelError("contact_name", "Please enter a first name and last name");
            }
            else if (!name.Contains(" "))
            {
                ModelState.AddModelError("contact_name", "Please enter a first name and last name");
            }
            else
            {
                ModelState.AddModelError("contact_phone", "The phone number entered is not valid");
            }
            return View(m);
        }

        public ActionResult ContactAcknowledgement()
        {
            ViewBag.Title = "Contact";
            return View();
        }

    }
}