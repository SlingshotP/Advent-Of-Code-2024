namespace _2._2
{
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
                    count++;
                }
                else
                {
                    for (int j = 0; j < data[i].Length; j++)
                    {
                        int tmp = data[i][j];
                        List<int> newData = new List<int>();
                        for (int k = 0; k < data[i].Length; k++)
                        {
                            if (k != j) newData.Add(data[i][k]);
                        }
                        if (CheckSingleLevelRemoved(newData.ToArray()))
                        {
                            count++;
                            break;
                        }
                        else data[i][j] = tmp;
                    }
                }
            }

            Console.WriteLine(count);
            Console.ReadKey();


        }

        static bool CheckSingleLevelRemoved(int[] data)
        {
            bool safe = false;
            for (int i = 0; i < data.Length; i++)
            {
                int count1 = 1;
                int count2 = 1;
                for (int j = 1; j < data.Length; j++)
                {
                    if (data[j] < data[j - 1])
                    {
                        int difference = data[j - 1] - data[j];
                        if (difference > 0 && difference < 4)
                        {
                            count1++;
                        }
                    }
                    else if (data[j] > data[j - 1])
                    {
                        int difference = data[j] - data[j - 1];
                        if (difference > 0 && difference < 4)
                        {
                            count2++;
                        }
                    }
                }
                if (count1 == data.Length || count2 == data.Length)
                {
                    safe = true;
                }
            }
            return safe;


        }
    }
}
