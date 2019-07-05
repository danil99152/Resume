using Resume.Controllers.Formats;
using Resume.Models;
using System;
using System.Linq;
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
            Type generatorType = typeof(AbstractGenerator);
            var members = Assembly.GetAssembly(generatorType).GetTypes().Where(type => type.IsSubclassOf(generatorType));
            ViewBag.List = new SelectList(members);
            return View();
        }

        [HttpPost]
        public ActionResult CreateResume(Person person, AbstractGenerator generator)
        {
            generator.AbstractGenerate(person);
            return RedirectToAction("Index");
        }
    }
}