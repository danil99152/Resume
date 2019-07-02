using Resume.Models;
using System.IO;

namespace Resume.Controllers
{
    class CsvGenerator : AbstractGenerate
    {
        public override void AbstractGenerator(Person person)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Resume." + person.Type, true))
            {
                var text = $"ФИО: {person.FIO}" + $"Дата рождения: {person.Birthday}" + $"Прошлые места работы: {person.PastPlaces}" + $"О себе: {person.About}";
                string[] csv = text.Split(';');
                sw.WriteLine(csv);
            }
        }
    }
}