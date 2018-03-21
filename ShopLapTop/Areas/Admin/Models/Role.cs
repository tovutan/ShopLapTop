﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopLapTop.Areas.Admin.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
    }
}