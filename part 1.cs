using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica3;
using part_2;
using part_3;

namespace part_1
{
    // П. 1: необобщенная коллекция
    class MakingCollection_non_generic
    {
        public void NewCollection(ArrayList list)
        {
            for (int i = 0; i < 5; i++)
            {
                Random rnd = new Random();
                int value = rnd.Next(-100000, 100000);
                list.Add(value);
            }

            list.Add("meow");
        }

        public void DeletingCollection(ArrayList list, int index)
        {
            list.RemoveAt(index);
        }

        public void PrintingCollection(ArrayList list)
        {
            Console.WriteLine($"Quantity of elements: {list.Count}");
            string st = "";
            for (int i = 0; i < list.Count; i++)
            {
                st+=list[i] +", ";
            }
            Console.WriteLine($"The collection: {st}");
        }

        public void FindValueInCollection(ArrayList list, object value)
        {
            int x = list.IndexOf(value);
            if (x == -1)
            {
                Console.WriteLine("No such value found");
            }
            else
            {
                Console.WriteLine($"Value number = {x + 1}");
            }
        }

    }
}
