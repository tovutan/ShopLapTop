using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ShopLapTop.Areas.Admin
{
    public class tienVN : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            if (Int32.Parse(value.ToString()) % 500 == 0)
            {
                return true;
            }

            else
                return false;
        }
       
    }
}