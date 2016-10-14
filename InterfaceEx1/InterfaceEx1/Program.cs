using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEx1
{
    class Customer : IComparable //able to use compare
    {
        string name;
        double creditLimit;

        public Customer (String name, double credit)
        {
            this.name = name;
            this.creditLimit = credit;
        }
        public override string ToString()
        {
            return String.Format("Customer:{0}", name);

        }
        public int CompareTo(Object obj) // tell computer how to compare
        {
            if (obj is Customer)
            {
                Customer cus2 = (Customer)obj;
                // return name.CompareTo(cus2.name);

                                         //compare with creditLimit
                return creditLimit.CompareTo(cus2.creditLimit);
            }
            else
                return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 9, 2, 13, 5, 20 };
            string[] syms = new string[] { "xyz", "abc", "efg" };

            Print(numbers);
            Array.Sort(numbers); // method of array
            Print(numbers);
            Print(syms);

            Customer[] c = new Customer[] { new Customer("Tan Ah Kow", 4) ,
                new Customer("Lin Ah Lian", 2),
                new Customer("Lee Ah Lian", 3) };
            Print(c);

                                        //sort according to settings
            Array.Sort(c);
            Print(c);

            Array.Reverse(c);
            Print(c);
        }
        

        public static void Print(int[] n)
        {
            foreach (var item in n)
            {
                Console.WriteLine("{0},", item);
            }
            Console.WriteLine();

        }
        static void Print(String[] n)
        {
            foreach (var item in n)
            {
                Console.WriteLine("{0},", item);
            }
            Console.WriteLine();

        }
        static void Print(Customer[] n)
        {
            foreach (var item in n)
            {
                Console.WriteLine("{0},", item);
            }
            Console.WriteLine();
        }
    }
}

