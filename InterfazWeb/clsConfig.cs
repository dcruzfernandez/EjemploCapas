using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace InterfazWeb
{
    public static class clsConfig
    {
      
       
        public static string getconnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];

            }
        }
    }
}