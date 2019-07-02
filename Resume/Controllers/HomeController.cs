using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Resume.Models;
using Resume.Views.Home;
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
        public ActionResult MyMethod(Person person, AbstractGenerator generator)
        {
            var xml = new XmlGenerator();
            var txt = new TxtGenerator();
            var json = new JsonGenerator();
            var csv = new CsvGenerator();
            switch (person.Type)
            {
                case "xml":
                    xml.AbstractGenerate(person);
                    break;
                case "txt":
                    txt.AbstractGenerate(person);
                    break;
                case "csv":
                    csv.AbstractGenerate(person);
                    break;
                case "json":
                    json.AbstractGenerate(person);
                    break;
            }
            return RedirectToAction("Index");
        }
    }
}