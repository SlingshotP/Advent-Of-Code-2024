using System.Text.RegularExpressions;

namespace _3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Text.txt");

            var matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)");
            int sum = 0;

            var donts = Regex.Matches(input, @"don't\(\)");
            var dos = Regex.Matches(input, @"do\(\)");

            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                var data = match.Groups.Cast<Group>().Skip(1).ToArray();
                int int1 = int.Parse(data[0].Value);
                int int2 = int.Parse(data[1].Value);
                int index = data[0].Index;

                int biggestDo = -1;
                for (int j = 0; j < dos.Count && dos[j].Index < index; j++)
                {
                    biggestDo = dos[j].Index;
                }
                int biggestDont = -2;
                for (int j = 0; j < donts.Count && donts[j].Index < index; j++)
                {
                    biggestDont = donts[j].Index;
                }



                if (biggestDo > biggestDont)
                {
                    int product = int1 * int2;
                    sum += product;
                }
            }
            Console.WriteLine(sum);


            Console.ReadKey();
        }
    }
}
