using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.IO;
using System.Linq;

namespace Final_C_tarto
{
    class DateAndTime
    {
        public string Year;
        public string Month;
        public string Day;
        public string Hour;
        public string Minutes;
        public string Seconds;
        public string MiliSeconds;
        public string tzHour;
        public string tzMinutes;
        

        public DateAndTime(string year, string month, string day, string hour, string minutes, string seconds, string miliseconds, string tzhour, string tzminutes)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Hour = hour;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.MiliSeconds = miliseconds;
            this.tzHour = tzhour;
            this.tzMinutes = tzminutes;
        }

        public static string vToBinary(DateAndTime a)
        {
            int[] Array = new int[9];
            string yearCoded;
            string monthCoded;
            string dayCoded;
            string hourCoded;
            string minutesCoded;
            string secondsCoded;
            string milisecondsCoded;
            string tzhourCoded;
            string tzminutesCoded;
            string AllCoded;

            Array[0] = int.Parse(a.Year);
            Array[1] = int.Parse(a.Month);
            Array[2] = int.Parse(a.Day);
            Array[3] = int.Parse(a.Hour);
            Array[4] = int.Parse(a.Minutes);
            Array[5] = int.Parse(a.Seconds);
            Array[6] = int.Parse(a.MiliSeconds);
            Array[7] = int.Parse(a.tzHour);
            Array[8] = int.Parse(a.tzMinutes);


            yearCoded = Convert.ToString(Array[0], 2).PadLeft(12, '0');

            monthCoded = Convert.ToString(Array[1], 2).PadLeft(4, '0');

            dayCoded = Convert.ToString(Array[2], 2).PadLeft(5, '0');

            hourCoded = Convert.ToString(Array[3], 2).PadLeft(5,'0');

            minutesCoded = Convert.ToString(Array[4], 2).PadLeft(6,'0');

            secondsCoded = Convert.ToString(Array[5], 2).PadLeft(6,'0');

            milisecondsCoded = Convert.ToString(Array[6], 2).PadLeft(10,'0');

            tzhourCoded = Convert.ToString(Array[7], 2).PadLeft(5,'0');

            tzminutesCoded = Convert.ToString(Array[8], 2).PadLeft(6, '0');

            AllCoded = yearCoded.Replace(" ","") + monthCoded.Replace(" ", "") + dayCoded.Replace(" ", "") + hourCoded.Replace(" ", "") + minutesCoded.Replace(" ", "") + secondsCoded.Replace(" ", "") + milisecondsCoded.Replace(" ", "") + tzhourCoded.Replace(" ", "") + tzminutesCoded.Replace(" ", "");
            
            return AllCoded;
        }
    }
}
