using System.Web.Mvc;

namespace Resume.GeneratorProviders
{
    public class GeneratorProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            return new GeneratorProvider();
        }
    }
}