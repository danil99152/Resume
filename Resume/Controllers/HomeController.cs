using Resume.Controllers.Formats;
using Resume.Models;
using System;
using System.Collections.Generic;
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


            //var neededclass = members.GetType();
            //ConstructorInfo ci = neededclass.GetConstructor(new Type[] { });
            //object Obj = ci.Invoke(new object[] { });
            //var property = Obj.GetType().GetProperty(generator.Name);
            ViewBag.List = types;
            return View();
        }

        [HttpPost]
        public ActionResult CreateResume(Person person, Generator generator)
        {
            if (person != null)
            {
                generator.Generate(person);

            }
            return RedirectToAction("Index");
        }
    }
}