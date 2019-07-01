using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Resume.Models
{
    public enum Type
    {
        txt,
        json,
        xml
    }
    public class Person
    {
        public int Id { get; set; }
        [DisplayName("Ваше Фамилия, Имя и Отчество(если имеется)")]
        public string FIO { get; set; }
        [DisplayName("Ваша дата рождения")]
        public DateTime Birthday { get; set; }
        [DisplayName("Напишите прошлые места работы")]
        public string PastPlaces { get; set; }
        [DisplayName("Расскажите о себе")]
        public string About { get; set; }
        [DisplayName("В каком формате вы хотите файл")]
        public Type Type { get; set; }
    }
}