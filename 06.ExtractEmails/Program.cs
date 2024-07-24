using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emailPattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";
            MatchCollection emailMatches = Regex.Matches(text, emailPattern);
            foreach (Match email in emailMatches)
            {
                Console.WriteLine(email.Value);
            }
        }
    }
}