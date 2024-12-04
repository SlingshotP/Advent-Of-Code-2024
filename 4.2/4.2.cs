namespace _4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Text.txt");
            int count = 0;
            (int y, int x)[] vectors = [(1, 1), (1, -1), (-1, 1), (-1, -1)];
            for (int r = 0; r < lines.Length; r++)
            {
                string line = lines[r];

                for (int c = 0; c < line.Length; c++)
                {
                    for (int k = 0; k < vectors.Length; k++)
                    {
                        if (c < 1                    // left
                            || c > line.Length - 2   // right
                            || r < 1                 // top
                            || r > lines.Length - 2) // bottom
                            continue;


                        if (line[c] == 'A')
                        {
                            if  (lines[r + vectors[k].y][c + vectors[k].x] == 'M'
                                  && lines[r - vectors[k].y][c - vectors[k].x] == 'S'
                                  && lines[r + vectors[k].y][c - vectors[k].x] == 'M'
                                  && lines[r - vectors[k].y][c + vectors[k].x] == 'S')
                                     count++;

                            else if (lines[r + vectors[k].y][c + vectors[k].x] == 'S'
                                  && lines[r - vectors[k].y][c - vectors[k].x] == 'M'
                                  && lines[r + vectors[k].y][c - vectors[k].x] == 'S'
                                  && lines[r - vectors[k].y][c + vectors[k].x] == 'M')
                                     count++;

                            else if (lines[r + vectors[k].y][c + vectors[k].x] == 'M'
                                  && lines[r - vectors[k].y][c - vectors[k].x] == 'S'
                                  && lines[r + vectors[k].y][c - vectors[k].x] == 'S'
                                  && lines[r - vectors[k].y][c + vectors[k].x] == 'M')
                                     count++;

                            else if (lines[r + vectors[k].y][c + vectors[k].x] == 'S'
                                  && lines[r - vectors[k].y][c - vectors[k].x] == 'M'
                                  && lines[r + vectors[k].y][c - vectors[k].x] == 'M'
                                  && lines[r - vectors[k].y][c + vectors[k].x] == 'S')
                                     count++;
                        }

                    }
                }



            }
            Console.WriteLine(count / 4); // I realised my code checks everything 4 times over so I just decided to divide by 4

            Console.ReadKey();
        }
    }
}
