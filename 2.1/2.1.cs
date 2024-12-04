namespace _2._1;
internal class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("Text.txt");
        int[][] data = new int[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(' ');
            data[i] = new int[line.Length];
            for (int j = 0; j < line.Length; j++)
            {
                data[i][j] = int.Parse(line[j]);
            }
        }

        int count = 0;
        for (int i = 0; i < data.Length; i++)
        {
            int count1 = 1;
            int count2 = 1;
            //Console.Write("List beginning: " + data[i][0] + ": ");
            for (int j = 1; j < data[i].Length; j++)
            {

                if (data[i][j] < data[i][j - 1])
                {
                    int difference = data[i][j - 1] - data[i][j];
                    if (difference > 0 && difference < 4)
                    {
                        count1++;
                    }
                }
                else if (data[i][j] > data[i][j - 1])
                {
                    int difference = data[i][j] - data[i][j - 1];
                    if (difference > 0 && difference < 4)
                    {
                        count2++;
                    }
                }
            }
            if (count1 == data[i].Length || count2 == data[i].Length)
            {
                //Console.Write("Safe");
                count++;
            }
            //Console.WriteLine();
        }

        Console.WriteLine(count);
        Console.ReadKey();


    }
}