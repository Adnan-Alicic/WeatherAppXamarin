using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    public class koordinate
    {
        public string lokacija { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
 


        public override string ToString()
        {
            return lokacija;
        }

        internal static double Equals(object longitude)
        {
            throw new NotImplementedException();
        }
    }
}
