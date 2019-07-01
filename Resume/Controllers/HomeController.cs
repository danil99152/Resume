using Resume.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
        public ActionResult MyMethod()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyMethod(Person person)
        {
            StreamWriter sw = new StreamWriter("C:\\Resume.txt", true);

            sw.WriteLine($"ФИО: {person.FIO}");

            sw.WriteLine($"Дата рождения: {person.Birthday}");

            sw.WriteLine($"Прошлые места работы: {person.PastPlaces}");

            sw.WriteLine($"О себе: {person.About}");

            sw.Close();

            return RedirectToAction("Index");
        }
    }
}