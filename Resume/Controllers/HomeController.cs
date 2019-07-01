using Resume.Models;
using System.IO;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public class HomeController : Controller, IResume
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
            using (StreamWriter sw = new StreamWriter("C:\\Resume."+person.Type, true)) {

                sw.WriteLine($"ФИО: {person.FIO}");

                sw.WriteLine($"Дата рождения: {person.Birthday}");

                sw.WriteLine($"Прошлые места работы: {person.PastPlaces}");

                sw.WriteLine($"О себе: {person.About}");

                sw.Close();

            }

            return RedirectToAction("Index");
        }
    }
}