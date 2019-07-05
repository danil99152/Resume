﻿using Resume.Controllers;
using Resume.Models;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Resume.Controllers.Formats
{
    class JsonGenerator : Generator
    {
        public override void Generate(Person person)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Person));
            using (FileStream sw = new FileStream("C:\\Resume.json", FileMode.Create))
            {
                json.WriteObject(sw, $"ФИО: {person.FIO}");
                json.WriteObject(sw, $"Дата рождения: {person.Birthday}");
                json.WriteObject(sw, $"Прошлые места работы: {person.PastPlaces}");
                json.WriteObject(sw, $"О себе: {person.About}");
                sw.Close();
            }
        }
    }
}