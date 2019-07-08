using Resume.Models;
using System.IO;

namespace Resume.Controllers.Formats
{
    class TxtGenerator : Generator
    {
        public TxtGenerator()
        {
            Name = "txt";
        }
        public override string Generate(Person person, string fileUri, string fileName)
        { 
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
            return fileUri + newDir + fileName;
        }
    }
}