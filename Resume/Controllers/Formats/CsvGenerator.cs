using Resume.Models;
using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace Resume.Controllers.Formats
{
    class CsvGenerator : Generator
    {
        public CsvGenerator()
        {
            Name = "csv";
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
            var newDir = "CSV\\";
            DirectoryInfo dirInfo = new DirectoryInfo(fileUri);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(newDir);
            using (StreamWriter sw = new StreamWriter(fileUri + newDir + fileName, true))
            {
                var text = $"ФИО: {person.FIO}" + $"Дата рождения: {person.Birthday}" + $"Прошлые места работы: {person.PastPlaces}" + $"О себе: {person.About}";
                var csv = text.Split(';');
                sw.WriteLine(csv);
                sw.Close();
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(fileUri + newDir + fileName, "\\Resume.csv");
                File.Delete(fileUri + newDir + fileName);
            }
        }
    }
}