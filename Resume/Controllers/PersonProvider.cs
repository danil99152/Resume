using Resume.Models;
using Resume.Views.Home;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public class PersonProvider : IValueProvider
    {
        private Person person = new Person();
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare(person.Type, prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {  
            if (ContainsPrefix(key))
            {
                var xml = new XmlGenerator();
                var txt = new TxtGenerator();
                var json = new JsonGenerator();
                var csv = new CsvGenerator();
                switch (person.Type)
                {
                    case "xml":
                        xml.AbstractGenerate(person);
                        break;
                    case "txt":
                        txt.AbstractGenerate(person);
                        break;
                    case "csv":
                        csv.AbstractGenerate(person);
                        break;
                    case "json":
                        json.AbstractGenerate(person);
                        break;
                }
            }
            return null;
        }
    }
}