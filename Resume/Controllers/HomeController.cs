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

        class Xml : AbstractHome
        {
            [HttpPost]
            public override ActionResult MyMethod(Person person)
            {
                XmlSerializer xml = new XmlSerializer(typeof(Person));
                using (FileStream sw = new FileStream("C:\\Resume." + person.Type, FileMode.Create))
                {
                    xml.Serialize(sw, person);
                }
                return null;
            }
        }

        class Json : AbstractHome
        {
            [HttpPost]
            public override ActionResult MyMethod(Person person)
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Person));
                using (FileStream sw = new FileStream("C:\\Resume." + person.Type, FileMode.Create))
                {
                    json.WriteObject(sw, $"ФИО: {person.FIO}");
                    json.WriteObject(sw, $"Дата рождения: {person.Birthday}");
                    json.WriteObject(sw, $"Прошлые места работы: {person.PastPlaces}");
                    json.WriteObject(sw, $"О себе: {person.About}");
                }
                return null;
            }
        }

        class Txt : AbstractHome
        {
            [HttpPost]
            public override ActionResult MyMethod(Person person)
            {
                using (StreamWriter sw = new StreamWriter("C:\\Resume." + person.Type, true))
                {
                    sw.WriteLine($"ФИО: {person.FIO}");

                    sw.WriteLine($"Дата рождения: {person.Birthday}");

                    sw.WriteLine($"Прошлые места работы: {person.PastPlaces}");

                    sw.WriteLine($"О себе: {person.About}");

                    sw.Close();
                }
                return null;
            }
        }
    }
}