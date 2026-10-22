using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.U1_10
{
    internal static class TaskUtils
    {
        /// <summary>
        /// Returns a list of fridge models from the specified manufacturer
        /// </summary>
        /// <param name="fridges"></param>
        /// <param name="manufacturer"></param>
        /// <returns>A list of fridge models</returns>
        public static List<string> Models(List<Fridge> fridges,string manufacturer)
        {
            List<string> list = new List<string>();
            for(int j = 0; j < fridges.Count; j++)
            {
                if (fridges[j].Manufacturer == manufacturer)
                {
                        list.Add(fridges[j].Model);
                }
            }
            return list;
        }
        /// <summary>
        /// Finds the cheapest fridge
        /// </summary>
        /// <param name="fridges"></param>
        /// <returns>cheapest fridge</returns>
        public static decimal Cheapest(List<Fridge> fridges)
        {
            decimal cheapest = decimal.MaxValue;
            foreach (Fridge f in fridges)
            {
                if (f.Price < cheapest)
                {
                    cheapest = f.Price;
                }
            }
            return cheapest;
        }
        
        /// <summary>
        /// Makes a list of fridges whose capacity is greater or equal to the variable
        /// </summary>
        /// <param name="fridges"></param>
        /// <param name="capacity"></param>
        /// <returns>A fridge type list</returns>
        public static List<Fridge> FilterByCapacity(List<Fridge> fridges,int capacity)
        {
            List<Fridge> list = new List<Fridge>();
            foreach (Fridge f in fridges)
            {
                if (f.Capacity >= capacity)
                {
                    list.Add(f);
                }
            }
            return list;
        }
        /// <summary>
        /// Gives a list of fridges that are the cheapest and are greater or equal to the capacity
        /// </summary>
        /// <param name="fridges"></param>
        /// <returns>A list of fridges that are the cheapeast and are greator or equal to the capacity</returns>
        /*public static List<Fridge> FindBestOption(List<Fridge> fridges,int capacity)
        {
            List<Fridge> list = new List<Fridge>();
            List<Fridge> cheapestlist = CheapestList(fridges);
            List<Fridge> capacitylist = FilterByCapacity(fridges,capacity);
            for (int i = 0; i<cheapestlist.Count; i++)
            {
                for(int j = 0; j < capacitylist.Count; j++)
                {
                    if (cheapestlist[i].Model == capacitylist[j].Model)
                        list.Add(cheapestlist[i]);
                }
            }
            return list;
        }
        */
        public static List<Fridge> FindBestOption(List<Fridge> fridges, int capacity)
        {
            List<Fridge> list = new List<Fridge>();
            List<Fridge> capacitylist = FilterByCapacity(fridges, capacity);
            decimal cheapest = Cheapest(capacitylist);
            for (int i = 0; i < capacitylist.Count; i++)
            {
                if (capacitylist[i].Price == cheapest)
                {
                    list.Add(capacitylist[i]);
                }
            }
            return list;
        }
        /// <summary>
        /// Gives a list of fridges that are of the same installation type
        /// </summary>
        /// <param name="fridges"></param>
        /// <param name="installation"></param>
        /// <returns>A list of fridges that have the certant installation</returns>
        public static List<Fridge> FindInstallations(List<Fridge> fridges, string installation)
        {
            List<Fridge> list = new List<Fridge>();
            foreach(Fridge f in fridges)
            {
                if(f.InstallationType == installation)
                {
                    list.Add(f);
                }
            }
            return list;
        }
        /// <summary>
        /// Makes a list that writes information about all fridges that are greater or equal to the capacity and have the specific installation type
        /// </summary>
        /// <param name="fridges"></param>
        /// <param name="capacity"></param>
        /// <returns>A list of friges that have the certant capacity and installation</returns>
        public static List<Fridge> SameInstallationWithEnoughCapacity(List<Fridge> fridges, int capacity)
        {
            List<Fridge> list = new List<Fridge>();
            List<Fridge> installationlist = FindInstallations(fridges, "Laisvai_pastatomas");
            List<Fridge> capacitylist = FilterByCapacity(fridges, 80);

            for (int i = 0; i < capacitylist.Count; i++)
            {
                for (int j = 0; j < installationlist.Count; j++)
                {
                    if (capacitylist[i].Model == installationlist[j].Model)
                    {
                        list.Add(capacitylist[i]);
                    }
                }
            }
            return list;
        }
    }
}
