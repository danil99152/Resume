using Resume.Models;
using System.IO;

namespace Resume.Controllers.Formats
{
    class CsvGenerator : AbstractGenerator
    {
        public override void AbstractGenerate(Person person)
        {
            using (StreamWriter sw = new StreamWriter("C:\\Resume.csv", true))
            {
                var text = $"ФИО: {person.FIO}" + $"Дата рождения: {person.Birthday}" + $"Прошлые места работы: {person.PastPlaces}" + $"О себе: {person.About}";
                var csv = text.Split(';');
                sw.WriteLine(csv);
                sw.Close();
            }
        }
    }
}