namespace Advent_of_Code_2024._1._1;

internal class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("Text.txt");
        //string[] lines = {"3   4", "4   3", "2   5", "1   3", "3   9", "3   3"};
        int[][] data = new int[2][];

        for (int i = 0; i < 2; i++)
        {
            data[i] = new int[lines.Length];
            for (int j = 0; j < lines.Length; j++)
            {
                string[] line = lines[j].Split("   ");
                data[i][j] = int.Parse(line[i]);
            }
                
        }

        Array.Sort(data[0]);
        Array.Sort(data[1]);
        int count = 0;
        for (int i = 0;i < data[0].Length; i++) //data[0].Length == data[1].Length
        {
            //Console.WriteLine($"Difference: {data[1][i] - data[0][i]}");
            if (data[1][i] > data[0][i])
            {
                count += data[1][i] - data[0][i];
            }
            else count += data[0][i] - data[1][i];

        }
        Console.WriteLine(count);

        Console.ReadKey();
    }
}