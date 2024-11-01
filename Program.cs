using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using part_1;
using part_2;
using part_3;

namespace Practica3
{
    class Program
    {
        static void Main(string[] args)
        {
            //П. 1: необобщенная коллекция
            
            Console.WriteLine("________________________________________________");
            Console.WriteLine("Part 1: Non-generic collections\n");
            ArrayList list = new ArrayList();
            int index = 1;
            string value = "meow";
            MakingCollection_non_generic c = new MakingCollection_non_generic();

            c.NewCollection(list);
            Console.WriteLine("\nMaking new collection with random values and string...\n");
            c.PrintingCollection(list);

            Console.WriteLine($"\nDeleting element number {index}...\n");
            c.DeletingCollection(list, index);

            Console.WriteLine("\nThe result:");
            c.PrintingCollection(list);
            Console.WriteLine($"\nTrying to find value {value} in list...\n");
            c.FindValueInCollection(list, value);

            // П.2: обобщенная коллекция
            Console.WriteLine("________________________________________________");
            Console.WriteLine("Part 2: Generic collections: Stack<char>, List<char>\n");
            Stack<char> letters = new Stack<char>();
            char[] lett = { 'a', 'b', 'c', 'd', 'e' };
            char[] lett2 = { 'f', 'g', 'h', 'i', 'j' };
            int num = 3;
            MakingCollection_generic g = new MakingCollection_generic();
            g.NewCollection_generic(letters, lett);
            Console.WriteLine("\nCollection Stack<char> letters: ");
            g.PrintingCollection_generic_stack(letters);
            g.RemovingElements_generic(letters, num);
            Console.WriteLine($"\nCollection Stack<char> letters with {num} deleted elements: ");
            g.PrintingCollection_generic_stack(letters);
            g.NewCollection_generic(letters, lett2);
            Console.WriteLine($"\nCollection Stack<char> letters with {lett2.Count()} added elements: ");
            g.PrintingCollection_generic_stack(letters);


            List<char> letters_list = new List<char>(letters.ToArray());
            Console.WriteLine("\nCollection List<char> letters_list: ");
            g.PrintingCollection_generic_list(letters_list);

            char l = 'm';
            Console.WriteLine($"\nTrying to find letter {l} in list...");
            g.Find_value_in_list(letters_list, l);

            char l2 = 'b';
            Console.WriteLine($"\nTrying to find letter {l2} in list...");
            g.Find_value_in_list(letters_list, l2);

            //П.3: обобщенная коллекция HomeAppliance

            Console.WriteLine("________________________________________________");
            Console.WriteLine("Part 3: Non-generic collections: Stack<HomeAppliance>, List<HomeAppliance>");
            int n = 2;
            HomeAppliance a1 = new HomeAppliance("toaster", "Russia", 6500.0, 1999);
            HomeAppliance a2 = new HomeAppliance("iron", "Germany", 8995.0, 1998);
            HomeAppliance a3 = new HomeAppliance("vacuum cleaner", "USA", 32999.99, 2017);

            HomeAppliance a4 = new HomeAppliance("kettle", "Russia", 2700.7, 2013);
            HomeAppliance a5 = new HomeAppliance("TV", "China", 56800.0, 2018);
            HomeAppliance a6 = new HomeAppliance("coffee machine", "Japan", 19900.0, 2019);

            collection_generic_home_appliance coll_app = new collection_generic_home_appliance();
            Stack<HomeAppliance> st_app = new Stack<HomeAppliance>();
            coll_app.NewCollection_home_app(st_app, a1);
            coll_app.NewCollection_home_app(st_app, a2);
            coll_app.NewCollection_home_app(st_app, a3);

            Console.WriteLine("\nPrinting new Home appliance stack collection...\n");
            coll_app.PrintInfo_h_app(st_app);
            Console.WriteLine("*********************************");

            Console.WriteLine($"\nDeleting {n} elements from collection...\n");
            coll_app.Delete_h_app(st_app, n);
            Console.WriteLine("\nPrinting Home appliance stack collection...\n");
            coll_app.PrintInfo_h_app(st_app);
            Console.WriteLine("*********************************");

            Console.WriteLine("\nAdding elements to the home appliance stack collection...\n");
            coll_app.NewCollection_home_app(st_app, a4);
            coll_app.NewCollection_home_app(st_app, a5);
            coll_app.NewCollection_home_app(st_app, a6);

            Console.WriteLine("\nPrinting Home Appliance stack collection...\n");
            coll_app.PrintInfo_h_app(st_app);
            Console.WriteLine("*********************************");

            List<HomeAppliance> l_app = new List<HomeAppliance>();
            Console.WriteLine("\nTransforming home appliance stack into list...\n");
            coll_app.stack_to_list_app(st_app, l_app);
            Console.WriteLine("\nPrinting Home Appliance list collection...\n");
            coll_app.PrintInfo_h_app_list(l_app);
            Console.WriteLine("*********************************");

            Console.WriteLine($"\nTrying to find element:");
            a1.PrintInfo();
            coll_app.Find_Value_in_list(l_app, a1);
            Console.WriteLine("*********************************");

            Console.WriteLine("\nComparing elements with IComparable using firstly price and then year:\n");
            a1.PrintInfo();
            a2.PrintInfo();
            if (a1.CompareTo(a2) > 0)
            {
                Console.WriteLine("\nFirst element is bigger than second.\n");
            }
            else if (a1.CompareTo(a2) < 0)
            {
                Console.WriteLine("\nSecond element is bigger than first.\n");
            }
            else if (a1.CompareTo(a2) == 0)
            {
                Console.WriteLine("\nElements are equal.\n");
            }
            Console.WriteLine("*********************************");

            HomeApplianceComparer home_app_comp = new HomeApplianceComparer();

            Console.WriteLine("\nComparing elements with IComparer using firstly manufacturer and then price and year:\n");
            a2.PrintInfo();
            a3.PrintInfo();
            if (home_app_comp.Compare(a2, a3) > 0)
            {
                Console.WriteLine("\nFirst element is bigger than second.\n");
            }
            else if (home_app_comp.Compare(a2, a3) < 0)
            {
                Console.WriteLine("\nSecond element is bigger than first.\n");
            }
            else if (home_app_comp.Compare(a2, a3) == 0)
            {
                Console.WriteLine("\nElements are equal.\n");
            }
            Console.WriteLine("*********************************");

            Console.WriteLine("Copying element to the new one with ICloneable...\n the old one:\n");
            a6.PrintInfo();
            HomeAppliance a7 = (HomeAppliance)a6.Clone();
            Console.WriteLine("\nThe new one:\n");
            a7.PrintInfo();
            Console.WriteLine("*********************************");

            // П.4: объект наблюдаемой коллекции и событие
            // Создаем наблюдаемую коллекцию
            Console.WriteLine("________________________________________________");
            Console.WriteLine("Part 4: Observable collections and events: ObservableCollection<HomeAppliance>\n");
            ObservableCollection<HomeAppliance> appliances = new ObservableCollection<HomeAppliance>();

            // Подписываемся на событие CollectionChanged
            appliances.CollectionChanged += Appliances_CollectionChanged;

            // Добавляем элементы в коллекцию
            appliances.Add(a1);
            appliances.Add(a5);

            // Удаляем элемент из коллекции
            appliances.RemoveAt(0); // Удаляем первый элемент

            // Добавляем элементы в коллекцию
            appliances.Add(a6);
            appliances.Add(a3);

            // Удаляем элемент из коллекции
            appliances.RemoveAt(2); // Удаляем третий элемент
        }

        // событие изменения коллекции
        private static void Appliances_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (HomeAppliance appliance in e.NewItems)
                {
                    Console.WriteLine("\nAdded: ");
                    appliance.PrintInfo();
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (HomeAppliance appliance in e.OldItems)
                {
                    Console.WriteLine("\nRemoved: ");
                    appliance.PrintInfo();
                }
            }
        }
    }
}