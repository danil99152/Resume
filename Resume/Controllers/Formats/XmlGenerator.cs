using Resume.Models;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace Resume.Controllers.Formats
{
    class XmlGenerator : AbstractGenerator
    {
        public override void AbstractGenerate(Person person)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Person));
            var fileUri = "C:\\Users\\user\\Documents\\Visual Studio 2015\\Projects\\Resume\\Resume\\App_Data\\Files\\";
            var fileName = "Resume.xml";
            var fileType = "application/xml";

            using (FileStream sw = new FileStream(fileUri + fileName, FileMode.Create))
            {
                xml.Serialize(sw, person);
                sw.Close();
            }
        }
    }
}