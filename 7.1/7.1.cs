namespace _7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Text.txt");
            long[][] data = new long[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                data[i] = new long[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    data[i][j] = long.Parse(line[j].Trim(':'));
                }
            }

            long sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                long[] equation = data[i];
                long result = equation[0];
                long[] operands = equation[1..];

                char[][] combinations = Combify(operands.Length - 1);

                for (int j = 0; j < combinations.Length; j++)
                {
                    long acc = operands[0];

                    char[] operators = combinations[j];
                    for (int k = 0; k < operators.Length; k++)
                    {
                        if (operators[k] == '+') acc += operands[k + 1];
                        else acc *= operands[k + 1];
                    }
                    if (acc == result)
                    {
                        sum += result;
                        break;
                    }
                }

            }
            Console.WriteLine(sum);

            Console.ReadKey();
        }


        static IEnumerable<IEnumerable<char>> CombifyTmp(int remaining)
        {
            if (remaining == 0)
            {
                yield return [];
            }
            else
            {
                var rest = CombifyTmp(remaining - 1);
                foreach (var item in rest)
                {
                    yield return item.Append('+');
                    yield return item.Append('*');
                }
            }
        }

        static char[][] Combify(int remaining)
        {
            return CombifyTmp(remaining).Select(x => x.ToArray()).ToArray();
        }
    }
}
