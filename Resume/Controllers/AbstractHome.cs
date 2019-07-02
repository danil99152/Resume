using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public abstract class AbstractHome
    {
        [HttpPost]
        public abstract ActionResult MyMethod(Person person);
    }
}