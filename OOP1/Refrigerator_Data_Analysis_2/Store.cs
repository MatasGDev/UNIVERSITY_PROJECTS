using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L2.U2_10
{
    internal class Store
    {
        private List<Fridge> AllFridges;
        private string Name;
        private string Address;
        private string PhoneNumber;

        public Store()
        {
            AllFridges = new List<Fridge>();
            Name = string.Empty;
            Address = string.Empty;
            PhoneNumber = string.Empty;
        }
        public Store(List<Fridge> allFridges)
        {
            AllFridges = new List<Fridge>();
            foreach (Fridge fridge in allFridges)
            {
                AllFridges.Add(fridge);
            }
        }
        public void Add(Fridge fridge)
        {
            AllFridges.Add(fridge);
        }
        public List<Fridge> GetFridges()
        {
            return AllFridges;
        }
        /// <summary>
        /// Gives a list of all possible manufacturers in the registry
        /// </summary>
        /// <returns>List of all manufacturers</returns>
        public List<string> GetAllManufacturers()
        {
            List<string> manufacturers = new List<string>();
            foreach (Fridge fridge in AllFridges)
            {
                if (!manufacturers.Contains(fridge.Manufacturer))
                {
                    manufacturers.Add(fridge.Manufacturer);
                }
            }
            return manufacturers;
        }
        /// <summary>
        /// Adds information to the private variables about store info
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        /// <param name="PhoneNumber"></param>
        public void AddStoreInfo(string Name, string Address, string PhoneNumber)
        {
            this.Name = Name;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
        /// <summary>
        /// Gives a string of all the store info
        /// </summary>
        /// <returns>Store info</returns>
        public string StoreToString()
        {
            return $"{Name},{Address},{PhoneNumber}";
        }
        /// <summary>
        /// Filters fridges that are >= capacity
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns>Filtered list</returns>
        public List<Fridge> FilteredByCapacity(int capacity)
        {
            List<Fridge> Filtered = new List<Fridge>();
            foreach (Fridge fridge in AllFridges)
            {
                if (fridge.Capacity >= capacity)
                {
                    Filtered.Add(fridge);
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Filters fridges by the specified manufacturer
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <returns>Filtered list</returns>
        private List<Fridge> FilterByManufacturer(string manufacturer)
        {
            List<Fridge> filtered = new List<Fridge>();
            foreach (Fridge fridge in AllFridges)
            {
                if (fridge.Manufacturer == manufacturer)
                {
                    filtered.Add(fridge);
                }
            }
            return filtered;
        }
        /// <summary>
        /// Gives the average price of a list
        /// </summary>
        /// <param name="List"></param>
        /// <returns>AveragePrice</returns>
        private decimal AveragePrice(List<Fridge> List)
        {
            Decimal Average = 0;
            int i = 0;
            for (i = 0; i < List.Count(); i++)
            {
                Average += List[i].Price;
            }

            return Average / i;
        }
        /// <summary>
        /// Finds the manufacturer(s) that have the most expensive fridges on average
        /// </summary>
        /// <returns>Manufacturer(s)</returns>
        public List<string> OverallHighestPriced()
        {
            string manufacturerMAX = string.Empty;
            List<string> manufacturerMAXlist = new List<string>();
            decimal average = decimal.MinValue;
            List<String> allmanufacturers = GetAllManufacturers();
            foreach (string manufacturer in allmanufacturers)
            {
                if (AveragePrice(FilterByManufacturer(manufacturer)) > average)
                {
                    average = AveragePrice(FilterByManufacturer(manufacturer));
                    manufacturerMAX = manufacturer;
                }
            }
            foreach (string manufacturer in allmanufacturers)
            {
                if (AveragePrice(FilterByManufacturer(manufacturer)) == average)
                {
                    manufacturerMAXlist.Add(manufacturer);
                }
            }
            return manufacturerMAXlist;
        }
        /// <summary>
        /// Compares a registry to another regitry and checks if it has exclusive manufacturers that are only in that store
        /// </summary>
        /// <param name="registry2"></param>
        public List<Fridge> FindExclusives(Store registry2)
        {
            List<Fridge> Exclusives = new List<Fridge>();
            List<string> otherManufacturers = registry2.GetAllManufacturers();
            for (int i = 0; i < AllFridges.Count; i++)
            {
                string manufacturer = AllFridges[i].Manufacturer;
                bool alreadyAdded = false;

                for (int j = 0; j < Exclusives.Count; j++)
                {
                    if (Exclusives[j].Manufacturer == manufacturer)
                    {
                        alreadyAdded = true;
                        break;
                    }
                }
                if (!otherManufacturers.Contains(manufacturer) && !alreadyAdded)
                {
                    Exclusives.Add(AllFridges[i]);
                }
            }
            return Exclusives;
        }
        /// <summary>
        /// (private) used for finding the overall highest values from both decimals
        /// </summary>
        /// <param name="max1"></param>
        /// <param name="max2"></param>
        /// <returns>Highest value</returns>
        private decimal HighestFromBoth(decimal max1, decimal max2)
        {
            if (max1 > max2)
            {
                return max1;
            }
            return max2;
        }
        /// <summary>
        /// Finds the highest total price from both filtered lists, if there are more then 1 then it puts all of them in a list
        /// </summary>
        /// <param name="filtered1"></param>
        /// <param name="filtered2"></param>
        /// <param name="highestPrice"></param>
        /// <returns>Filtered list</returns>
        public List<Fridge> FilteredFromBoth(int capacity,Store registry2)
        {
            List<Fridge> filteredfromboth = new List<Fridge>();
            
            List<Fridge> filtered1 = FilteredByCapacity(capacity);
            List<Fridge> filtered2 = registry2.FilteredByCapacity(capacity);
            decimal filtered1MAX = FindHighestPrice(filtered1);
            decimal filtered2MAX = FindHighestPrice(filtered2);
            decimal highestPrice = HighestFromBoth(filtered1MAX, filtered2MAX);
            List<Fridge> filteredmaxlist = new List<Fridge>();
            foreach (Fridge fridge in filtered1)
            {
                if (fridge.Price == highestPrice)
                {
                    filteredfromboth.Add(fridge);
                }

            }
            foreach (Fridge fridge in filtered2)
            {
                if (fridge.Price == highestPrice)
                {
                    filteredfromboth.Add(fridge);
                }
            }
            return filteredfromboth;
        }
        /// <summary>
        /// Finds the highest price in a list
        /// </summary>
        /// <param name="List"></param>
        /// <returns>Highest price</returns>
        private decimal FindHighestPrice(List<Fridge> List)
        {
            Decimal HighestPrice = decimal.MinValue;
            foreach (Fridge fridge in List)
            {
                if (fridge.Price > HighestPrice)
                {
                    HighestPrice = fridge.Price;
                }
            }
            return HighestPrice;
        }
    }
}
