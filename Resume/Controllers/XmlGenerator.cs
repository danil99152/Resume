using Resume.Controllers;
using Resume.Models;
using System.IO;
using System.Xml.Serialization;

namespace Resume.Views.Home
{
    class XmlGenerator : AbstractGenerate
    {
        public override void AbstractGenerator(Person person)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Person));
            using (FileStream sw = new FileStream("C:\\Resume." + person.Type, FileMode.Create))
            {
                xml.Serialize(sw, person);
            }
        }
    }
}