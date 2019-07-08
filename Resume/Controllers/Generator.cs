﻿using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.Controllers
{
    public class Generator
    {
        public string Name { get; set; }
        /// <summary>
        /// Abstract method to realise methods for generating formats
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public virtual void Generate(Person person) { }
    }
}