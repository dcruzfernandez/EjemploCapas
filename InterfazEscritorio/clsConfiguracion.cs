using System;
using System.Collections.Generic;
using System.Text;


namespace InterfazEscritorio
{
    public static class clsConfiguracion
    {
        public static string getconnectionString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
            }
        }
    }
}
