using Resume.Models;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Resume.Controllers.Formats
{
    class XmlGenerator : Generator
    {
        public XmlGenerator()
        {
            Name = "xml";
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
            var newDir = "Xml\\";
            DirectoryInfo dirInfo = new DirectoryInfo(fileUri);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(newDir);

            XmlSerializer xml = new XmlSerializer(typeof(Person));
            using (FileStream sw = new FileStream(fileUri + newDir + fileName, FileMode.Create))
            {
                xml.Serialize(sw, person);
                sw.Close();
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(fileUri + newDir + fileName, "\\Resume.xml");
                File.Delete(fileUri + newDir + fileName);
            }
        }
    }
}