using Resume.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Mvc;

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
            var types = new List<SelectListItem>();

            Type generatorType = typeof(Generator);
            var generator = new Generator();

            var members = Assembly.GetAssembly(generatorType).GetTypes().Where(type => type.IsSubclassOf(generatorType));
            foreach (var item in members)
            {
                ConstructorInfo ci = item.GetConstructor(new Type[] { });
                var Obj = ci.Invoke(new object[] { }) as Generator;


                var selItem = new SelectListItem()
                {
                    Text = Obj.Name,
                    Value = item.FullName
                };

                types.Add(selItem);

            }
            ViewBag.List = types;
            return View();
        }

        [HttpPost]
        public ActionResult CreateResume(Person person, Generator generator)
        {
            var fileUri = ConfigurationManager.AppSettings["uri"];
            var fileName = person.FIO.GetHashCode().ToString()
               + person.Birthday.GetHashCode().ToString()
               + person.PastPlaces.GetHashCode().ToString()
               + person.About.GetHashCode().ToString()
               + DateTime.Now.Millisecond.GetHashCode().ToString()
               + $".{person.Type}";
            string file = "";
            if (person != null)
            {
                file = generator.Generate(person, fileUri, fileName);
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(file, $"\\Resume.{person.Type}");
                System.IO.File.Delete(file);
            }
                return RedirectToAction("Index");
        }
    }
}