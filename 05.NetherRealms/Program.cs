using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] demonNames = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            SortedDictionary<string, Demon> demons = new SortedDictionary<string, Demon>();
            foreach (var demonName in demonNames)
            {
                int health = CalculateHealth(demonName);
                double damage = CalculateDamage(demonName);
                demons[demonName] = new Demon { Name = demonName, Health = health, Damage = damage };
            }
            foreach (var demon in demons.Values)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }
        static int CalculateHealth(string demonName)
        {
            string healthPattern = @"[^0-9+\-*\/.]";
            MatchCollection matches = Regex.Matches(demonName, healthPattern);
            int health = 0;
            foreach (Match match in matches)
            {
                health += match.Value[0];
            }
            return health;
        }
        static double CalculateDamage(string demonName)
        {
            string damagePattern = @"-?\d+(\.\d+)?";
            MatchCollection matches = Regex.Matches(demonName, damagePattern);
            double damage = 0;
            foreach (Match match in matches)
            {
                damage += double.Parse(match.Value);
            }
            foreach (char ch in demonName)
            {
                if (ch == '*')
                {
                    damage *= 2;
                }
                else 
                if (ch == '/')
                {
                    damage /= 2;
                }
            }
            return damage;
        }
    }
}