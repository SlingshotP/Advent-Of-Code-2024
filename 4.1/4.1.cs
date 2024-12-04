namespace _4._1;
internal class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("Text.txt");
        int count = 0;
        (int y, int x)[] vectors = [(1, 0), (-1, 0), (0, -1), (0, 1), (1, 1), (1, -1), (-1, 1), (-1, -1)];
        for (int r = 0; r < lines.Length; r++)
        {
            string line = lines[r];

            for (int c = 0; c < line.Length; c++)
            {
                for (int k = 0; k < vectors.Length; k++)
                {
                    if (c < 3 && (vectors[k].x == -1)                     // left
                        || c > line.Length - 4 && vectors[k].x == 1   // right
                        || r < 3 && vectors[k].y == -1                    // top
                        || r > lines.Length - 4 && vectors[k].y == 1) // bottom
                        continue;


                    if (line[c] == 'X'
                        && lines[r + vectors[k].y][c + vectors[k].x] == 'M'
                        && lines[r + vectors[k].y * 2][c + vectors[k].x * 2] == 'A'
                        && lines[r + vectors[k].y * 3][c + vectors[k].x * 3] == 'S')
                        count++;
                }
            }



        }
        Console.WriteLine(count);

        Console.ReadKey();
    }
}