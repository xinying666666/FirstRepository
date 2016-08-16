using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;
using CarManager.Web.Validator;

namespace CarManager.Web.Models.Cars
{
  
    //[FluentValidation.Attributes.Validator(typeof(CarValidator))]
    public class CarViewModel
    {
        [Key]
        public int ID { get; set; }
        //[DisplayName("车名字")]
        //[MaxLength(10)]
        public string Name { get; set; }
        //[DisplayName("车价格")]
        public decimal Price { get; set; }
        //public DateTime CreateDate { get; set; }
        //[DisplayName("电子邮件")]
        public string Email { get; set; }
    }
}