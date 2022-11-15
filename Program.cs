// See https://aka.ms/new-console-template for more information
using JSSQLAssignment1;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, MySQL!");

        
        MySQLHandler mySQLHandler = new MySQLHandler();

        Menu menu = new Menu();

        menu.NavigationMenu();
       
        
    }
}