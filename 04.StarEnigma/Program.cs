using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                int decryptionKey = encryptedMessage.ToLower().Count(c => "star".Contains(c));
                string decryptedMessage = new string(encryptedMessage.Select(c => (char)(c - decryptionKey)).ToArray());
                string pattern = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<soldierCount>\d+)";
                Match match = Regex.Match(decryptedMessage, pattern);
                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    string attackType = match.Groups["attackType"].Value;
                    if (attackType == "A")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else
                    if (attackType == "D")
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(p => p))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}