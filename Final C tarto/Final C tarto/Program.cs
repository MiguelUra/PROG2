using System;
using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace Final_C_tarto
{
    class Program
    {
        static string Rootpath = AppDomain.CurrentDomain.BaseDirectory;
        static string inputPath = Rootpath + "Input.csv";
        static string outputPath = Rootpath + "Output.csv";
        static string year;
        static string month;
        static string day;
        static string hour;
        static string minutes;
        static string seconds;
        static string miliseconds;
        static string tzhour;
        static string tzminutes;
        static string mintemp;
        static string maxtemp;
        static string precipitation;
        static string outputCoded;
        static string outputCoded2;
        static long To64;
        static int To32;
        
        static void Main(string[] args)
        {
            
            
            FileInfo In = new FileInfo(inputPath);
            FileInfo Out = new FileInfo(outputPath);
            string[] read = File.ReadAllLines(inputPath);
            string[] decod = File.ReadAllLines(outputPath);
            Console.WriteLine("[1] Codificacion [2] Decodificacion");
            char[] p = Console.ReadLine().ToCharArray();
            if (p[0] == '1')
            {
                if (!(read.Length == 0))
                {


                    for (int i = 0; i < read.Length; i++)
                    {
                        string[] separate = read[i].Split('T');
                        string[] timeClimate = separate[1].Split(',');
                        string[] timeTzone = timeClimate[0].Split('-');
                        string[] time = timeTzone[0].Split(':');
                        string[] secMili = time[2].Split('.');
                        string[] timezone = timeTzone[1].Split(':');
                        string[] date = separate[0].Split('-');
                        year = date[0];
                        month = date[1];
                        day = date[2];
                        hour = time[0];
                        minutes = time[1];
                        seconds = secMili[0];
                        miliseconds = secMili[1];
                        tzhour = timezone[0];
                        tzminutes = timezone[1];
                        mintemp = timeClimate[1];
                        maxtemp = timeClimate[2];
                        precipitation = timeClimate[3];
                        DateAndTime dateTime = new DateAndTime(year, month, day, hour, minutes, seconds, miliseconds, tzhour, tzminutes);
                        Climate climate = new Climate(mintemp, maxtemp, precipitation);
                        outputCoded = DateAndTime.vToBinary(dateTime);
                        outputCoded2 = Climate.vToBinary(climate);
                        To64 = Convert.ToInt64(outputCoded, 2);
                        To32 = Convert.ToInt32(outputCoded2, 2);
                        using (StreamWriter file = new StreamWriter(outputPath, true))
                        {
                            file.WriteLine($"{To64},{To32}");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Archivo Vacio");
                    Console.ReadKey();
                }
            }
            else if (p[0] == '2')
            {
                if (!(decod.Length == 0))
                {
                    for (int i = 1; i < decod.Length; i++)
                    {
                        string[] seprt = decod[i].Split(',');
                        long decode64 = long.Parse(seprt[0]);
                        int decode32 = int.Parse(seprt[1]);


                        string binry = Convert.ToString(decode64, 2);
                        string bnry = Convert.ToString(decode32, 2);

                        
                        string anno = binry.Substring(0, 11);
                        string mnth = binry.Substring(11, 4);
                        string dy = binry.Substring(15, 5);
                        string hr = binry.Substring(20, 5);
                        string mnts = binry.Substring(25, 6);
                        string scnds = binry.Substring(31, 6);
                        string mlscnds = binry.Substring(37, 10);
                        string tzhrs = binry.Substring(47, 5);
                        string tzmnts = binry.Substring(52, 4);
                        string mintemp = bnry.Substring(0, 6);
                        string maxtemp = bnry.Substring(6, 7);
                        string precipitation;
                        if (bnry.Length == 19)
                        {
                            precipitation = bnry.Substring(13, 6);
                        }
                        else
                        {
                            precipitation = bnry.Substring(13, 7);
                        }
                        string vdecimal = Convert.ToInt64(anno, 2).ToString();
                        int[] positions = new int[11];
                        positions[0] = Convert.ToInt32(mnth, 2);
                        positions[1] = Convert.ToInt32(dy, 2);
                        positions[2] = Convert.ToInt32(hr, 2);
                        positions[3] = Convert.ToInt32(mnts, 2);
                        positions[4] = Convert.ToInt32(scnds, 2);
                        positions[5] = Convert.ToInt32(mlscnds, 2);
                        positions[6] = Convert.ToInt32(tzhrs, 2);
                        positions[7] = Convert.ToInt32(tzmnts, 2);
                        positions[8] = Convert.ToInt32(mintemp, 2);
                        positions[9] = Convert.ToInt32(maxtemp, 2);
                        positions[10] = Convert.ToInt32(precipitation, 2);
                        //2020 - 07 - 13T19: 30:25.525 - 04:00,25,34,30
                        Console.WriteLine(vdecimal + '-' + positions[0] + '-' + positions[1] + 'T' + positions[2] + ':' + positions[3] + ':' + positions[4] + '.' + positions[5] + "-0" + positions[6] + ":0" + positions[7] + ',' + positions[9] + ',' + positions[8] + ',' + positions[10]);


                    }
                }
                else
                {
                    Console.WriteLine("Archivo Vacio");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Mal");
                Console.ReadKey();
            }
            
            




        }
    }
}
