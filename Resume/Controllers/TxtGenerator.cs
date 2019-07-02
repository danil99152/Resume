using Resume.Models;
using System.IO;

namespace Resume.Controllers
{
    class TxtGenerator : AbstractGenerator
    {
        public override void AbstractGenerate(Person person)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Resume.txt", true))
            {
                sw.WriteLine($"ФИО: {person.FIO}");

                sw.WriteLine($"Дата рождения: {person.Birthday}");

                sw.WriteLine($"Прошлые места работы: {person.PastPlaces}");

                sw.WriteLine($"О себе: {person.About}");

                sw.Close();
            }
        }
    }
}