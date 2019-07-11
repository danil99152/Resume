﻿using Resume.Models;

namespace Resume.BaseGenerator
{
    public class Generator
    {
        public string Name { get; set; }
        /// <summary>
        /// Abstract method to realise methods for generating formats
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public virtual string Generate(Person person, string fileUri, string fileName)
        {
            return null;
        }
    }
}