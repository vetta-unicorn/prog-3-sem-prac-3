using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica3;
using part_1;
using part_2;


namespace part_3
{

    interface IComparable
    {
        int CompareTo(object o);
    }

    interface IComparer
    {
        int Compare(object o1, object o2);
    }

    public interface IClonable
    {
        object Clone();
    }

    // класс из лабораторной работы 1
    public class HomeAppliance : IComparable<HomeAppliance>, ICloneable
    {
        public string model;
        public string manufacturer;
        public double price;
        public int year;

        public HomeAppliance(string m = "Unknown", string manu = "Unknown", double p = 0.0, int y = 2000)
        {
            model = m;
            manufacturer = manu;
            price = p;
            year = y;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Model: {model}, Manufacturer: {manufacturer}, Price: {price} RUB, Year: {year}");
            Console.WriteLine("-----------------------");
        }

        // Свойства
        public string Model
        {
            get { return model; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                price = value;
            }
        }

        public int CompareTo(HomeAppliance other)
        {
            if (other == null) return 1; // Текущий объект больше null

            int priceComparison = price.CompareTo(other.price);
            if (priceComparison != 0) return priceComparison; // Сначала сравниваем по цене

            return year.CompareTo(other.year); // Если цены равны, сравниваем по году
        }

        public object Clone()
        {
            return new HomeAppliance(model, manufacturer, price, year);
        }

    }

    public class HomeApplianceComparer : IComparer<HomeAppliance>
    {
        public int Compare(HomeAppliance x, HomeAppliance y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int manufacturerComparison = string.Compare(x.manufacturer, y.manufacturer, StringComparison.OrdinalIgnoreCase);
            if (manufacturerComparison != 0) return manufacturerComparison; // Сначала по производителю

            return x.CompareTo(y); // Затем по цене и году (используем уже реализованный CompareTo)
        }
    }

    class collection_generic_home_appliance 
    {
        public void NewCollection_home_app(Stack<HomeAppliance> home_app_stack, HomeAppliance app)
        {
            home_app_stack.Push(app);
        }

        public void PrintInfo_h_app(Stack<HomeAppliance> home_app_stack)
        {
            foreach (var a in home_app_stack)
            {
                a.PrintInfo();
            }
        }

        public void Delete_h_app(Stack<HomeAppliance> home_app_stack, int n)
        {
            if (n > home_app_stack.Count())
            {
                throw new Exception("There's less elemets than you want to delete!");
            }

            for (int i = 0; i < n; i++)
            {
                home_app_stack.Pop();
            }
        }

        public void stack_to_list_app(Stack<HomeAppliance> home_app_stack, List<HomeAppliance> home_app_list)
        {
            foreach(var a in home_app_stack)
            {
                home_app_list.Add(a);
            }
        }

        public void PrintInfo_h_app_list(List<HomeAppliance> home_app_list)
        {
            for(int i = 0; i <home_app_list.Count; i++)
            {
                home_app_list[i].PrintInfo();
            }
        }

        public void Find_Value_in_list(List<HomeAppliance> home_app_list, object o)
        {
            bool Flag = false;
            for(int i = 0; i < home_app_list.Count; i++)
            {
                if (home_app_list[i] == o)
                {
                    Console.WriteLine($"\nNumber of wanted element: {i + 1}\n");
                    Flag = true;
                }
            }
            if (Flag == false)
            {
                Console.WriteLine("\nThere's no such element in list.\n");
            }
        }

    }


}
