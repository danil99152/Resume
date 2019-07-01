using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Resume.Controllers
{
    interface IResume
    {
        [HttpGet]
        ActionResult MyMethod();

        [HttpPost]
        ActionResult MyMethod(Person person);
    }
}
