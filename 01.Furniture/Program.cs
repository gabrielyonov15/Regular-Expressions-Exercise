using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> furniture = new List<string>();
            decimal totalCost = 0m;
            string pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)";
            Regex regex = new Regex(pattern);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    furniture.Add(name);
                    totalCost += price * quantity;
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (string item in furniture)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {totalCost:F2}");
        }
    }
}