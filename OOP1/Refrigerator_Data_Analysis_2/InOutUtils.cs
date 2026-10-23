using L2.U2_10;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L2.U2_10
{
    internal static class InOutUtils
    {
        /// <summary>
        /// Reads a file and puts all information in a FridgeRegistry type 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>FridgeRegistry type information</returns>
        public static Store ReadFridgesFromStore1(string filename)
        {
            Store ReadFridges = new Store();
            List<string> lines = File.ReadAllLines(filename, Encoding.UTF8).ToList();
            if (lines.Count() <= 0)
            {
                Console.WriteLine("The file is empty");
                Environment.Exit(1);
                return null;
            }
            else
            {
                string[] storeinfo = lines[0].Split(';');
                lines.RemoveAt(0);
                foreach (string line in lines)
                {
                    string[] values = line.Split(';');
                    string manufacturer = values[0];
                    string model = values[1];
                    int capacity = int.Parse(values[2]);
                    string energy = values[3];
                    string installationType = values[4];
                    string color = values[5];
                    bool feature = bool.Parse(values[6]);
                    decimal price = decimal.Parse(values[7]);
                    double height = double.Parse(values[8]);
                    double width = double.Parse(values[9]);
                    double depth = double.Parse(values[10]);
                    Fridge fridgeinfo = new Fridge(manufacturer, model, capacity, energy, installationType, color, feature, price, height, width, depth);
                    ReadFridges.Add(fridgeinfo);
                }
                ReadFridges.AddStoreInfo(storeinfo[0], storeinfo[1], storeinfo[2]);
                return ReadFridges;
            }
        }
        /// <summary>
        /// Prints fridges that are the most expensive and are >= capacity
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="registry1"></param>
        /// <param name="registry2"></param>
        public static void PrintHighestPriceWithCapacity(List<Fridge> filteredmaxlist)
        {
            
            if (filteredmaxlist.Count > 0)
            {
                Console.WriteLine($"The most expensive fridges that have a capacity of 80 liters or more:");
                foreach (Fridge fridge in filteredmaxlist)
                {
                    Console.WriteLine(fridge.ToString());
                }
            }
            else
            {
                Console.WriteLine("There are no fridges with a capacity of 80");
            }
        }
        /// <summary>
        /// Makes a file that contains exclusive manufacturers of both stores
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="registry1"></param>
        /// <param name="registry2"></param>
        public static void PrintToFile_ExclusiveManufacturers(string filename, Store registry1, Store registry2)
        {
            registry1.FindExclusives(registry2);
            registry2.FindExclusives(registry1);
            List<Fridge> ex1 = registry1.FindExclusives(registry2);
            List<Fridge> ex2 = registry2.FindExclusives(registry1);
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8))
            {
                if (ex1.Count() == 0)
                {
                    sw.WriteLine($"( {registry1.StoreToString()} )store does not have any exclusive manufacturers");
                }
                else
                {
                    sw.WriteLine($"( {registry1.StoreToString()} )store exclusive manufacturers:");
                    foreach (Fridge fridge in ex1)
                    {
                        sw.WriteLine(fridge.Manufacturer);
                    }
                }

                if (ex2.Count() == 0)
                {
                    sw.WriteLine($"( {registry2.StoreToString()} )store does not have any exclusive manufacturers");
                }
                else
                {
                    sw.WriteLine($"( {registry2.StoreToString()} )store exclusive manufacturers:");
                    foreach (Fridge fridge in ex2)
                    {
                        sw.WriteLine(fridge.Manufacturer);
                    }
                }

            }
        }
        /// <summary>
        /// Creates a file of what is inside of store1.txt, store2.txt
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="store1"></param>
        /// <param name="store2"></param>
        public static void WriteStoresData(string fileName, Store store1, Store store2)
        {
            using (StreamWriter filewriter = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                filewriter.WriteLine($"STORE 1: {store1.StoreToString()}");
                filewriter.WriteLine("+---------------+------------+----------+--------+----------------+----------+---------+------------+----------+----------+----------+");
                filewriter.WriteLine("| Manufacturer  | Model      | Capacity | Energy | Installation   | Color    | Feature | Price      | Height   | Width    | Depth    |");
                foreach (Fridge f in store1.GetFridges())
                {
                    filewriter.WriteLine(BoardStyleForFridgeInfo(f));
                }
                filewriter.WriteLine("+---------------+------------+----------+--------+----------------+----------+---------+------------+----------+----------+----------+");
                filewriter.WriteLine($"STORE 2: {store2.StoreToString()}");
                filewriter.WriteLine("+---------------+------------+----------+--------+----------------+----------+---------+------------+----------+----------+----------+");
                filewriter.WriteLine("| Manufacturer  | Model      | Capacity | Energy | Installation   | Color    | Feature | Price      | Height   | Width    | Depth    |");
                foreach (Fridge f in store2.GetFridges())
                {
                    filewriter.WriteLine(BoardStyleForFridgeInfo(f));
                }
                filewriter.WriteLine("+---------------+------------+----------+--------+----------------+----------+---------+------------+----------+----------+----------+");


            }
        }
        /// <summary>
        /// Makes a string thats formated for the board
        /// </summary>
        /// <param name="f"></param>
        /// <returns>Formated string</returns>
        private static string BoardStyleForFridgeInfo(Fridge f)
        {
            return string.Format(
                "| {0,-13} | {1,-10} | {2,8} | {3,-6} | {4,-14} | {5,-8} | {6,-7} | {7,10} | {8,8} | {9,8} | {10,8} |",
                f.Manufacturer,
                f.Model,
                f.Capacity,
                f.Energy,
                f.InstallationType,
                f.Color,
                f.Feature,
                f.Price,
                f.Height,
                f.Width,
                f.Depth
            );
        }
    }
}

