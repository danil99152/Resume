﻿using Resume.Models;
using System.IO;

namespace Resume.Controllers.Formats
{
    class CsvGenerator : Generator
    {
        public CsvGenerator()
        {
            Name = "csv";
        }
        public override string Generate(Person person, string fileUri, string fileName)
        {
            var newDir = "CSV\\";
            DirectoryInfo dirInfo = new DirectoryInfo(fileUri);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(newDir);
            using (StreamWriter sw = new StreamWriter(fileUri + newDir + fileName, true))
            {
                var text = $"ФИО: {person.FIO}" + $"Дата рождения: {person.Birthday}" + $"Прошлые места работы: {person.PastPlaces}" + $"О себе: {person.About}";
                var csv = text.Split(';');
                sw.WriteLine(csv);
                sw.Close();
            }
            return fileUri + newDir + fileName;
        }
    }
}