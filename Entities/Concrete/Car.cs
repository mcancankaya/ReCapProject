﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters;

namespace Entities.Concrete
{
    //Id, BrandId, ColorId, ModelYear, DailyPrice, Description 
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        //public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
