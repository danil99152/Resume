using Resume.Controllers;
using Resume.Models;
using System.IO;
using System.Xml.Serialization;

namespace Resume.Views.Home
{
    class XmlGenerator : AbstractGenerator
    {
        public override void AbstractGenerate(Person person)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Person));
            using (FileStream sw = new FileStream("C:\\Resume.xml", FileMode.Create))
            {
                xml.Serialize(sw, person);
            }
        }
    }
}