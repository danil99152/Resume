using Resume.Models;
using System.IO;
using System.Xml.Serialization;

namespace Resume.Controllers.Formats
{
    class XmlGenerator : Generator
    {
        public XmlGenerator()
        {
            Name = "xml";
        }
        public override string Generate(Person person, string fileUri, string fileName)
        {
           
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
            return fileUri + newDir + fileName;
        }
    }
}