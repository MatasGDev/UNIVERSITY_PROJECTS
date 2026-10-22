using Lab1.Exercises.U1_10;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Lab1.Exercises.U1_10
{

    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Fridge> fridges = InOutUtils.ReadFridge("Duomenys1.csv");
            List<string> siemens = TaskUtils.Models(fridges,"Siemens");
            List<Fridge> bestoptions = TaskUtils.FindBestOption(fridges, 80);
            if (TaskUtils.Models(fridges, "Siemens").Count > 0)
            {
                Console.WriteLine("+-----------------------+");
                Console.WriteLine($"{"Siemens"} fridge models: ");
                foreach(string model in siemens)
                {
                   Console.WriteLine($"   {model}           ");
                }
                Console.WriteLine("+-----------------------+");
            }
            else
            {
                Console.WriteLine("+------------------------+");
                Console.WriteLine("|No {0} models found!|", "Siemens");
                Console.WriteLine("+------------------------+");
            }
            if (bestoptions.Count > 0)
            {
                Console.WriteLine("+-------------------------------------------------------------------------------+");
                Console.WriteLine("The cheapest (capacity >= 80) fridges:");
                foreach (Fridge f in bestoptions)
                {
                    Console.WriteLine($"Manufacturer: {f.Manufacturer}, Model: {f.Model}, Capacity: {f.Capacity}, Price: {f.Price}");
                }
                Console.WriteLine("+-------------------------------------------------------------------------------+");
            }
            else
            {
                Console.WriteLine("+------------------------------------+");
                Console.WriteLine($"|No fridges found with capacity >= {80}|");
                Console.WriteLine("+------------------------------------+");
            }
            InOutUtils.WriteCSV("„Pastatomi80.csv",fridges);
            InOutUtils.WriteInitial("Rezultatai.txt", fridges);
        }
    }
}
