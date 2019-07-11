using Resume.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using System.IO;
using Resume.BaseGenerator;

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
            var assembliesUri = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Plugin";
            string localPath = new Uri(assembliesUri).LocalPath;
            foreach (string file in Directory.EnumerateFiles(localPath, "*.dll"))
            {
                var member = Assembly.LoadFile(file).GetTypes().Where(type => type.BaseType.FullName == generatorType.FullName);

                foreach (var item in member)
                {
                    ConstructorInfo ci = item.GetConstructor(new Type[] { });
                    var Obj = ci.Invoke(new object[] { }) as Generator;
                    if (Obj.Name != null && item.FullName != null)
                    {
                        var selItem = new SelectListItem()
                        {
                            Text = Obj.Name,
                            Value = item.FullName
                        };

                        types.Add(selItem);
                    }

                }
                ViewBag.List = types;
            }
            var name = User.Identity.Name;
            ViewBag.FIO = name;

            var context = new ApplicationDbContext();
            var birthday = from table in context.Users
                           where table.UserName == name
                           select table.Birthday;
            foreach (var item in birthday)
            {
                ViewBag.Birthday = item.ToLongDateString();
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateResume(Person person, Generator generator)
        {
            var fileUri = ConfigurationManager.AppSettings["uri"];
            var fileName = Guid.NewGuid() + $".{generator.Name}";
            string file = "";
            if (person != null)
            {
                file = generator.Generate(person, fileUri, fileName);
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(file, $"\\Resume.{generator.Name}");
            }
            TimerCallback tm = new TimerCallback(Count);
            Timer timer = new Timer(tm, file, 15000, 0);
            return RedirectToAction("Index");
        }
        private static void Count(object obj)
        {
            System.IO.File.Delete(obj as string);
        }
    }
}