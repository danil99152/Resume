using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public abstract class AbstractGenerator
    {
        /// <summary>
        /// Abstract method to realise methods for generating formats
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public abstract void AbstractGenerate(Person person);
    }
}