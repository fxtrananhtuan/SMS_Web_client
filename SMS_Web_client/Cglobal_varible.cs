using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Web_client
{
    public  class Cglobal_varible
    {
        public static string Account_ID;
        public static string Name;
        public static ICollection<ServiceReference1.DTO_Customer> _customer;
        public static List<ServiceReference1.DTO_Customer> _PhoneNumber = new List<ServiceReference1.DTO_Customer>();
        public static bool Check = false;

    }
}
