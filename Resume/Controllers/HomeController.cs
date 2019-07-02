using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Resume.Models;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Web.Mvc;
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
        public ActionResult MyMethod()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MyMethod(Person person)
        {
            var generator = new AbstractGenerate();
            generator.AbstractGenerator(person);
            return RedirectToAction("Index");
        }
    }
}