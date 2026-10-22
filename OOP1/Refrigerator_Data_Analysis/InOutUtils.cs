using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.U1_10
{
    internal static class InOutUtils
    {
        /// <summary>
        /// Reads the file and puts all of the information inside a list
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns>A list with all fridge data</returns>
        public static List<Fridge> ReadFridge(string FileName)
        {
            List<Fridge> list = new List<Fridge>();
            string[] Lines = File.ReadAllLines(FileName, Encoding.UTF8);
            int linenumber = 1; // This is to know which line made an error
            foreach (string Line in Lines)
            {
                string[] Values = Line.Split(';');
                if (Values.Length < 11)
                {
                    Console.WriteLine("Skipped line due to error: Not enough values in line {0}", linenumber);
                    continue;
                }
                else if (Values.Length > 11)
                {
                    Console.WriteLine("Skipped line due to error: Too many values in line {0}", linenumber);
                    continue;
                }
                string manufacturer = Values[0];
                string model = Values[1];
                int capacity = int.Parse(Values[2]);
                string energy = Values[3];
                string installationType = Values[4];
                string color = Values[5];
                bool feature = bool.Parse(Values[6]);
                decimal price = decimal.Parse(Values[7]);
                double height = double.Parse(Values[8]);
                double width = double.Parse(Values[9]);
                double depth = double.Parse(Values[10]);
                linenumber++;
                Fridge FRIDGE = new Fridge(manufacturer, model, capacity, energy, installationType, color, feature, price, height, width, depth);
                list.Add(FRIDGE);
            }
            return list;
        }
        /// <summary>
        /// Creates a file and writes information about all fridges that are greater or equal to the capacity and have the specific installation type
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fridges"></param>
        public static void WriteCSV(string fileName, List<Fridge> fridges)
        {
            using (StreamWriter filewriter = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                List<Fridge> list = TaskUtils.SameInstallationWithEnoughCapacity(fridges, 80);
                if (list.Count > 0)
                {
                    foreach (Fridge f in list)
                    {
                        filewriter.WriteLine($"{f.Manufacturer},{f.Model},{f.Capacity},{f.Energy},{f.InstallationType},{f.Color},{f.Feature},{f.Price.ToString(CultureInfo.InvariantCulture)},{f.Height},{f.Width},{f.Depth}");
                    }
                }
            }
        }
        /// <summary>
        /// Writes all of the initial data in a file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fridges"></param>
        public static void WriteInitial(string fileName, List<Fridge> fridges)
        {
            using (StreamWriter filewriter = new StreamWriter(fileName, false, Encoding.UTF8))
            {

                if (fridges.Count > 0)
                {
                    int longest = 0;
                    foreach (Fridge f in fridges)
                    {
                        if (f.ToString().Length > longest)
                        {
                            longest = f.ToString().Length;
                        }
                    }
                    for (int i = 0; i < longest + 2; i++)
                    {
                        filewriter.Write("-");
                    }
                   
                    foreach (Fridge f in fridges)
                    {
                        int currentlength = f.ToString().Length;
                        filewriter.WriteLine();
                        filewriter.Write($"|{f.Manufacturer},{f.Model},{f.Capacity},{f.Energy},{f.InstallationType},{f.Color},{f.Feature},{f.Price.ToString(CultureInfo.InvariantCulture)},{f.Height},{f.Width},{f.Depth}");
                        for(int i=currentlength; i < longest; i++)
                        {
                            filewriter.Write(" ");
                        }
                        filewriter.Write("|");
                    }
                    filewriter.WriteLine();
                    for (int i = 0; i < longest + 2; i++)
                    {
                        filewriter.Write("-");
                    }
                }
            }
        }
    }
}
