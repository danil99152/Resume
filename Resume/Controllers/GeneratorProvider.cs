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
            System.Reflection.ConstructorInfo ci = neededclass.GetConstructor(new Type[] { });
            object Obj = ci.Invoke(new object[] { });
            return new ValueProviderResult(Obj, null, CultureInfo.CurrentCulture);
        }
    }
}