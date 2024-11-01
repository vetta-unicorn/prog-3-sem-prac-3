using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using part_1;
using Practica3;
using part_3;
using System.Diagnostics.Metrics;

namespace part_2
{
    // П. 2: обобщенная коллекция
    class MakingCollection_generic
    {
        public void NewCollection_generic(Stack<char> letters, char[] lett)
        {
            for (int i = 0; i < 5; i++)
            {
                letters.Push(lett[i]);
            }

        }

        public void PrintingCollection_generic_stack(Stack<char> letters)
        {
            string st = "";
            foreach (var letter in letters)
            {
                st += letter + ", ";
            }
            Console.WriteLine(st);
        }

        public void RemovingElements_generic(Stack<char> letters, int num)
        {
            for (int i = 0; i < num; i++)
            {
                letters.Pop();
            }
        }

        public void Copy_stack_to_list(Stack<char> letters, List<char> letters_list)
        {
            int i = 0;
            foreach (var letter in letters)
            {
                letters_list[i] = letter;
                i++;
            }
        }

        public void PrintingCollection_generic_list(List<char> letters_list)
        {
            string st = "";
            for (int i = 0; i < letters_list.Count; i++)
            {
                st += letters_list[i] + ", ";
            }
            Console.WriteLine(st);
        }

        public void Find_value_in_list(List<char> letters_list, char l)
        {
            bool Flag = false;
            for (int i = 0; i < letters_list.Count; i++)
            {
                if (letters_list[i] == l)
                {
                    Flag = true;
                    Console.WriteLine($"Letter number: {i + 1}");
                }
            }
            if (Flag == false)
            {
                Console.WriteLine("There's no such letter in list");
            }
        }

    }

}
