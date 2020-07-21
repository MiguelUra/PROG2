using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.IO;
using System.Linq;

namespace Final_C_tarto
{
    class Climate
    {
        public string MaxTemp;
        public string MinTemp;
        public string Precipitation;
       

        public Climate(string maxtemp, string mintemp, string precipitation)
        {
            MaxTemp = maxtemp;
            MinTemp = mintemp;
            Precipitation = precipitation;
        }
        public static string vToBinary(Climate a)
        {
            int[] Array = new int[3];
            string mintempCoded;
            string maxtempCoded;
            string precipitationCoded;
            string AllCoded;
            Array[0] = int.Parse(a.MinTemp);
            Array[1] = int.Parse(a.MaxTemp);
            Array[2] = int.Parse(a.Precipitation);



            mintempCoded = Convert.ToString(Array[0], 2).PadLeft(7, '0');

            maxtempCoded = Convert.ToString(Array[1], 2).PadLeft(7, '0');

            precipitationCoded = Convert.ToString(Array[2], 2).PadRight(7, '0');

            AllCoded = mintempCoded.Replace(" ","") + maxtempCoded.Replace(" ", "") + precipitationCoded.Replace(" ", "");
            return AllCoded;
        }
    }
}
