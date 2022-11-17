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


            while (true)
            {
                Console.WriteLine("Enter a number to pick an option.");
                Console.WriteLine("\n1. The number of represented countries.");
                Console.WriteLine("");
                Console.WriteLine("2. The most commonly occurring country.");
                Console.WriteLine("");
                Console.WriteLine("3. The number of people living in the Nordic countries.");
                Console.WriteLine("");
                Console.WriteLine("4. The number of people living in Scandinavia.");
                Console.WriteLine("");
                Console.WriteLine("5. The first 10 people in the list whose last name starts with a specific letter.");
                Console.WriteLine("");
                Console.WriteLine("6. All people whose first- and last names start with a specific letter.");
                Console.WriteLine("");
                Console.WriteLine("7. The number of unique usernames and passwords.\n");
            
            
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        get.NumberOfCountries(person);
                        Console.WriteLine("\n");
                        Console.ResetColor();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        get.MostCommonCountry(person);
                        Console.WriteLine("\n");
                        Console.ResetColor();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        get.NumberOfPplNordic(person);
                        Console.WriteLine("The Nordic countries are: Sweden, Norway, Denmark, Finland, Iceland.\n");
                        Console.ResetColor();
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        get.NumberOfPplScandinavia(person);
                        Console.WriteLine("The Scandinavian countries are: Sweden, Norway, Denmark.\n");
                        Console.ResetColor();
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Last name starts with: ");
                        Console.ResetColor();
                        get.LastNameStartsWithLetter(person);
                        Console.WriteLine("\n");
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("First and last names start with: ");
                        Console.ResetColor();
                        get.FirstAndLastNameStartsWithLetter();
                        Console.WriteLine("\n");
                        break;
                    case "7":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        get.UniqueUserAndPW(person, person);
                        Console.WriteLine("\n");
                        Console.ResetColor();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.\n");
                        Console.ResetColor();
                        break;
                }

                
                
                Console.ReadKey();
                Console.Clear();


            }
            
        }

            
        
    }
}
