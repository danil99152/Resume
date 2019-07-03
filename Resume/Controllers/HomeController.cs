using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Resume.Models;
using Resume.Views.Home;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml.Serialization;

namespace Resume.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateResume()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult CreateResume(Person person, AbstractGenerator generator)
        {
            if (person != null)
            {
                generator.AbstractGenerate(person);
               
            }
            return RedirectToAction("Index");
        }
        public string Resume(string person)
        {
            return person;
        }
    }
}