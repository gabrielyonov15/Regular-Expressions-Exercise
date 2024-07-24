using System.Text.RegularExpressions;
namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var participants = Console.ReadLine().Split(", ").ToList();
            var racers = new Dictionary<string, int>();
            foreach (var participant in participants)
            {
                racers[participant] = 0;
            }
            string namePattern = @"[A-Za-z]+";
            string distancePattern = @"\d";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }
                var nameMatches = Regex.Matches(input, namePattern);
                var distanceMatches = Regex.Matches(input, distancePattern);
                string name = string.Join("", nameMatches);
                int distance = distanceMatches.Select(match => int.Parse(match.Value)).Sum();
                if (racers.ContainsKey(name))
                {
                    racers[name] += distance;
                }
            }
            var topRacers = racers
                .OrderByDescending(r => r.Value)
                .Take(3)
                .ToList();
            Console.WriteLine("1st place: " + topRacers[0].Key);
            Console.WriteLine("2nd place: " + topRacers[1].Key);
            Console.WriteLine("3rd place: " + topRacers[2].Key);
        }
    }
}
