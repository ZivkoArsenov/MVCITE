﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCITE.Repository.DTOs
{
    public class WebMenuTypeDTO
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
