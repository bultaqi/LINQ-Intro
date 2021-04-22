using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Intro
{
    // Build a collection of customers who are millionaires
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class BankReport
    {
        public string BankName;
        public int NumberOfCustomer;
    }    
    public class Program
    {

        static void Main(string[] args)
        {


            List<Customer> customers = new List<Customer>() {
                        new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                        new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                        new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                        new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                        new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                        new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                        new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                        new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                        new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                        new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                    };

            IEnumerable<Customer> millionaires = customers.Where(customer => customer.Balance >= 1000000);
            Console.WriteLine(millionaires);


            List<BankReport> countOfMillionairesAtEachBank = (from customer in millionaires
                group customer by customer.Bank into millionareClub
                select new BankReport {
                  BankName = millionareClub.Key,
                  NumberOfCustomer = millionareClub.Count()
                }).OrderByDescending(list => list.NumberOfCustomer).ToList();

            foreach(BankReport entry in countOfMillionairesAtEachBank)
            {
                Console.WriteLine($"{entry.BankName}, {entry.NumberOfCustomer}");
            }
            

 

            // // Find the words in the collection that start with the letter 'L'
            // List<string> fruits = new List<string>() 
            // {   
            //     "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"
            // };

            // IEnumerable<string> LFruits = from fruit in fruits 
            //     where fruit.StartsWith("L")
            //     select fruit;
            
            // Console.WriteLine(LFruits);
            
            

            // // Which of the following numbers are multiples of 4 or 6
            // List<int> numbers = new List<int>()
            // {
            //     15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            // };

            // IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 && n % 6 == 0);
            // Console.WriteLine(fourSixMultiples);



            // // Order these student names alphabetically, in descending order (Z to A)
            // List<string> names = new List<string>()
            // {
            //     "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            //     "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            //     "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            //     "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            //     "Francisco", "Tre"
            // };

            // var descend = names.OrderByDescending(n => n);
            
            // foreach (string name in descend)
            // {
            //     Console.WriteLine(name);
            // }


            // Build a collection of these numbers sorted in ascending order
            // List<int> numbers = new List<int>()
            // {
            //     15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            // };

            // var ascend = numbers.OrderBy(n => n);

            // foreach (int num in ascend)
            // {
            //     Console.WriteLine(num);
            // }



            // Output how many numbers are in this list
            // List<int> numbers = new List<int>()
            // {
            //     15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            // };

            // var counting = numbers.Count();

            // Console.WriteLine(counting);


            // How much money have we made?
            // List<double> purchases = new List<double>()
            // {
            //     2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            // };

            // var moneyMade = purchases.Sum();
            // Console.WriteLine(moneyMade);


            // What is our most expensive product?
            // List<double> prices = new List<double>()
            // {
            //     879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            // };

            // var mostExpensive = prices.Max();
            // Console.WriteLine(mostExpensive);


        }

    internal struct NewStruct
    {
        public object Item1;
        public object Item2;

        public NewStruct(object item1, object item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public override bool Equals(object obj)
        {
            return obj is NewStruct other &&
                   EqualityComparer<object>.Default.Equals(Item1, other.Item1) &&
                   EqualityComparer<object>.Default.Equals(Item2, other.Item2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Item1, Item2);
        }

        public void Deconstruct(out object item1, out object item2)
        {
            item1 = Item1;
            item2 = Item2;
        }

        public static implicit operator (object, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((object, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}
}
