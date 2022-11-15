using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JSSQLAssignment1
{
    internal class Menu
    {
        MySQLHandler get = new MySQLHandler();

        Person person = new Person();
        
        public void NavigationMenu()
        {
            Console.WriteLine("Welcome to the navigation menu.\n");
            Console.WriteLine("What information would you like to see?");
            Console.WriteLine("Enter a number to pick an option.");
            
            Console.WriteLine("\n1. The number of represented countries.");
            Console.WriteLine("2. The most commonly occurring country.");
            Console.WriteLine("3. The number of people living in the Nordic countries.");
            Console.WriteLine("4. The number of people living in Scandinavia.");
            Console.WriteLine("5. The first 10 people in the list whose last name starts with a specific letter.");
            Console.WriteLine("6. All people whose first- and last names start with a specific letter.");
            Console.WriteLine("7. The number of unique usernames and passwords.");
            
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        get.NumberOfCountries(person);
                        break;
                    case "2":
                        get.MostCommonCountry(person);
                        break;
                    case "3":
                        get.NumberOfPplNordic(person);
                        Console.WriteLine("The Nordic countries are: Sweden, Norway, Denmark, Finland, Iceland.");
                        break;
                    case "4":
                        get.NumberOfPplScandinavia(person);
                        Console.WriteLine("The Scandinavian countries are: Sweden, Norway, Denmark.");
                        break;
                    case "5":
                        Console.WriteLine("Enter your search query: ");
                        get.LastNameStartsWithLetter(person);
                        break;
                    case "6":
                        Console.WriteLine("Enter your search query: ");
                        get.FirstAndLastNameStartsWithLetter();
                        break;
                    case "7":
                        get.UniqueUserAndPW(person, person);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
            }
            
        }

            
        
    }
}
