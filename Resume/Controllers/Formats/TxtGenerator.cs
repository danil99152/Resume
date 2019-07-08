using Resume.Models;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Resume.Controllers.Formats
{
    class TxtGenerator : Generator
    {
        public TxtGenerator()
        {
            Name = "txt";
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
            var newDir = "Text\\";
            DirectoryInfo dirInfo = new DirectoryInfo(fileUri);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(newDir);
            using (StreamWriter sw = new StreamWriter(fileUri+newDir+fileName, true))
            {
                sw.WriteLine($"ФИО: {person.FIO}");

                sw.WriteLine($"Дата рождения: {person.Birthday}");

                sw.WriteLine($"Прошлые места работы: {person.PastPlaces}");

                sw.WriteLine($"О себе: {person.About}");

                sw.Close();
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(fileUri + newDir + fileName, "\\Resume.txt");
                File.Delete(fileUri + newDir + fileName);
            }
        }
    }
}