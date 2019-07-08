﻿using Resume.Models;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Resume.Controllers.Formats
{
    class JsonGenerator : Generator
    {
        public JsonGenerator()
        {
            Name = "json";
        }
        public override string Generate(Person person, string fileUri, string fileName)
        {
            var newDir = "Json\\";
            DirectoryInfo dirInfo = new DirectoryInfo(fileUri);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(newDir);
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Person));
            using (FileStream sw = new FileStream(fileUri + newDir + fileName, FileMode.Create))
            {
                json.WriteObject(sw, $"ФИО: {person.FIO}");
                json.WriteObject(sw, $"Дата рождения: {person.Birthday}");
                json.WriteObject(sw, $"Прошлые места работы: {person.PastPlaces}");
                json.WriteObject(sw, $"О себе: {person.About}");
                sw.Close();
            }
            return fileUri + newDir + fileName;
        }
    }
}