namespace Advent_of_Code_2024._1._2;

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

        int mainCount = 0;
        int subCount = 0;
        for (int i = 0; i < data[0].Length; i++) //data[0].Length == data[1].Length
        {
            for (int j = 0; j < data[1].Length; j++)
            {
                if (data[0][i] == data[1][j])
                {
                    //Console.Write("Matching data: ");
                    subCount++;
                    //Console.Write(subCount);
                    //Console.WriteLine();
                }
            }
            mainCount += data[0][i] * subCount;
            subCount = 0;
        }
        Console.WriteLine(mainCount);

        Console.ReadKey();
    }
}