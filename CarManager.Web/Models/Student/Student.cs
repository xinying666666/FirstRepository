using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarManager.Web.Models.Student
{
    public class Student
    {
        [DisplayName("学生名")]
        public string Name { get; set; }
        [DisplayName("学生性别")]
        [UIHint("Sex")]
        public bool? Sex { get; set; }
        [DisplayName("生日")]
        [UIHint("Date")]
        public DateTime CreateTime { get;set;}
    }
}