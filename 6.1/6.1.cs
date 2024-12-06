namespace _6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("Text.txt");
            char[][] grid = new char[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                grid[i] = new char[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    grid[i][j] = line[j];
                }
            }

            int tmpCount = 0;
            bool @out = false;
            while (!@out)
            {
                for (int i = 0; i < grid.Length && !@out; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (i == 0 && grid[i][j] == '^'
                            || j == 0 && grid[i][j] == '<'
                            || i == grid.Length - 1 && grid[i][j] == 'v'
                            || j == grid[i].Length - 1 && grid[i][j] == '>')
                        {
                            grid[i][j] = 'X';
                            @out = true;
                            break;
                        }
                        // Up
                        if (grid[i][j] == '^')
                        {
                            grid[i][j] = 'X';
                            if (grid[i - 1][j] == '#')
                            {
                                grid[i][j + 1] = '>';
                            }
                            else
                            {
                                grid[i - 1][j] = '^';
                            }
                        }
                        // Right
                        else if (grid[i][j] == '>')
                        {
                            grid[i][j] = 'X';
                            if (grid[i][j + 1] == '#')
                            {
                                grid[i + 1][j] = 'v';
                            }
                            else
                            {
                                grid[i][j + 1] = '>';
                            }
                        }
                        // Down
                        else if (grid[i][j] == 'v')
                        {
                            grid[i][j] = 'X';
                            if (grid[i + 1][j] == '#')
                            {
                                grid[i][j - 1] = '<';
                            }
                            else
                            {
                                grid[i + 1][j] = 'v';
                            }
                        }
                        // Left
                        else if (grid[i][j] == '<')
                        {
                            grid[i][j] = 'X';
                            if (grid[i][j - 1] == '#')
                            {
                                grid[i - 1][j] = '^';
                            }
                            else
                            {
                                grid[i][j - 1] = '<';
                            }
                        }
                        tmpCount++;
                        
                    }
                }
            }
            Console.WriteLine(tmpCount);
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 'X')
                    {
                        count++;
                        //Console.WriteLine($"Found X at row {i}, column {j}");
                    }
                }
            }
            Console.WriteLine(count);

            Console.ReadKey();
        }
    }
}
