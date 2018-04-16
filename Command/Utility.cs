using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public static class Utility
    {
        public static string BackDateTime(DateTime date)
        {
            string time = string.Empty;
            var seconds = (DateTime.Now - date).Seconds;
            var minutes = (DateTime.Now - date).Minutes;
            var hours = (DateTime.Now - date).Hours;
            var days = (DateTime.Now - date).Days;

          
            if (seconds > 0)
            {
                time = seconds + " giây trước";
            }
            
            if (minutes > 0)
            {
                time = minutes + " phút trước";
            }
            if (hours > 0)
            {
                time = hours + " giờ trước";
            }
            if (days > 0)
            {
                time = days + " ngày trước";
            }
            if (days > 30)
            {
                time = date.ToString("dd/mm/yyyy");
            }
            return time;
        }
    }
}
