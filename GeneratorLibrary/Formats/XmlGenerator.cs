using Resume.BaseGenerator;
using Resume.Models;
using System.IO;
using System.Xml.Serialization;

namespace Resume.GeneratorLibrary.Formats
{
    public class XmlGenerator : Generator
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
            string[] path = { fileUri, newDir, fileName };
            string file = Path.Combine(path);
            XmlSerializer xml = new XmlSerializer(typeof(Person));
            using (FileStream sw = new FileStream(file, FileMode.Create))
            {
                xml.Serialize(sw, person);
                sw.Close();
            }
            return file;
        }
    }
}