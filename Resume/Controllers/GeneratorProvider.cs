using Resume.Controllers.Formats;
using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public class GeneratorProvider : IValueProvider
    {
        public bool ContainsPrefix(string prefix)
        {
            return string.Compare("generator", prefix, true) == 0;
        }

        public ValueProviderResult GetValue(string key)
        {
            var type = HttpContext.Current.Request.Params["Type"];
            var neededclass = Type.GetType(type);
            return new ValueProviderResult(neededclass, null, CultureInfo.CurrentCulture);

            /*    switch (type)
                {
                    case "xml":
                        return new ValueProviderResult(new XmlGenerator(), null, CultureInfo.CurrentCulture);

                    case "txt":
                        return new ValueProviderResult(new TxtGenerator(), null, CultureInfo.CurrentCulture);

                    case "csv":
                        return new ValueProviderResult(new CsvGenerator(), null, CultureInfo.CurrentCulture);

                    case "json":
                        return new ValueProviderResult(new JsonGenerator(), null, CultureInfo.CurrentCulture);

                }
                */
            return null;
        }
    }
}