using Resume.Models;
using System.IO;

namespace GeneratorLibrary.Formats
{
    public class TxtGenerator : Generator
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
            string[] path = { fileUri, newDir, fileName };
            string file = Path.Combine(path);
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine($"ФИО: {person.FIO}");

                sw.WriteLine($"Дата рождения: {person.Birthday}");

                sw.WriteLine($"Прошлые места работы: {person.PastPlaces}");

                sw.WriteLine($"О себе: {person.About}");

                sw.Close();
            }
            return file;
        }
    }
}