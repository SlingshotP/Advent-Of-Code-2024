using System.Text.RegularExpressions;

namespace _3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Text.txt");

            var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");
            int count = 0;
            foreach (Match match in matches)
            {
                var data = match.Groups.Cast<Group>().Skip(1).ToArray();
                int int1 = int.Parse(data[0].Value);
                int int2 = int.Parse(data[1].Value);
                int product = int1 * int2;
                count += product;
            }
            Console.WriteLine(count);

            Console.ReadKey();
        }
    }
}
