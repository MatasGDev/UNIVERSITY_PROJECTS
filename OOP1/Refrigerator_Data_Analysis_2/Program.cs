/*
Buitinės technikos parduotuvė.
Turite informaciją apie dvejose buitinės technikos parduotuvėseesančius šaldytuvus.
Keičiasi duomenų formatas. Pirmoje eilutėje pavadinimas, antroje – adresas, trečioje –telefonas.
Toliau informacija apie šaldytuvus pateikta tokiu pačiu formatu kaip L1 užduotyje.

-Raskite brangiausią šaldytuvą, kurio talpa 80 litrų ar didesnė. Atspausdinkite ekrane visus jo
duomenis. Jei yra keli, spausdinkite visus.

-Suraskite, kurio gamintojo šaldytuvai yra brangiausi kiekvienoje parduotuvėje atskirai,
rezultatą atspausdinkite ekrane.

-Ar yra tokių šaldytuvų gamintojų, kurių produktus galima įsigyti tik vienoje parduotuvėje?
Atspausdinkite tokį gamintojų ir parduotuvių sąrašą faile „TikTen.csv“.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2.U2_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store1 = InOutUtils.ReadFridgesFromStore1("Store1.txt");
            Store store2 = InOutUtils.ReadFridgesFromStore1("Store2.txt");
            InOutUtils.PrintHighestPriceWithCapacity(store1.FilteredFromBoth(80,store2));
            Console.WriteLine(); //Spacing line

            Console.WriteLine($"Store1 manufacturers that are the most expensive:");
            foreach (string manufacturer in store1.OverallHighestPriced())
            {
                Console.WriteLine(manufacturer);
            }
            Console.WriteLine($"Store2 manufacturers that are the most expensive:");
            foreach (string manufacturer in store2.OverallHighestPriced())
            {
                Console.WriteLine(manufacturer);
            }
           
            InOutUtils.PrintToFile_ExclusiveManufacturers("TikTen.txt", store1, store2);
            InOutUtils.WriteStoresData("StoreDatas.txt", store1, store2);
        }
    }
}
