using Resume.Controllers;
using Resume.Models;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Resume.Views.Home
{
    class XmlGenerator : AbstractGenerator
    {
        public override void AbstractGenerate(Person person)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Person));
            var fileUri = "C:\\Users\\user\\Documents\\Visual Studio 2015\\Projects\\Resume\\Resume\\App_Data\\Files\\";
            using (FileStream sw = new FileStream(fileUri+"Resume.xml", FileMode.Create))
            {
                xml.Serialize(sw, person);
                sw.Close();
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile(fileUri+"Resume.xml", "C:\\Users\\user\\Downloads\\Resume.xml");
            }
        }
    }
}