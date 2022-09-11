﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string FullName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
