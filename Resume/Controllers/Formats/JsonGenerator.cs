using Resume.Controllers;
using Resume.Models;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Resume.Controllers.Formats
{
    class JsonGenerator : Generator
    {
        public JsonGenerator()
        {
            Name = "json";
        }
        public override void Generate(Person person)
        {
            string fileUri = ConfigurationManager.AppSettings["uri"];
            var fileName = person.FIO.GetHashCode().ToString()
               + person.Birthday.GetHashCode().ToString()
               + person.PastPlaces.GetHashCode().ToString()
               + person.About.GetHashCode().ToString()
               + DateTime.Now.Millisecond.GetHashCode().ToString()
               + $".{person.Type}";
            var newDir = "Json\\";
            DirectoryInfo dirInfo = new DirectoryInfo(fileUri);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(newDir);
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Person));
            using (FileStream sw = new FileStream(fileUri + newDir + fileName, FileMode.Create))
            {
                json.WriteObject(sw, $"ФИО: {person.FIO}");
                json.WriteObject(sw, $"Дата рождения: {person.Birthday}");
                json.WriteObject(sw, $"Прошлые места работы: {person.PastPlaces}");
                json.WriteObject(sw, $"О себе: {person.About}");
                sw.Close();
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(fileUri + newDir + fileName, "\\Resume.json");
                File.Delete(fileUri + newDir + fileName);
            }
        }
    }
}