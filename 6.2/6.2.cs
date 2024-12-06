namespace _6._2
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

            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '^') continue;
                    var newGrid = grid.Select(r => r.ToArray()).ToArray();
                    newGrid[i][j] = '#';

                    if (Loop(newGrid))
                    {
                        count++;
                        //Console.WriteLine($"Looped at row {i}, column {j}");
                    }
                    //Console.WriteLine("One position");
                }

            //Console.WriteLine("One row");
            }
            Console.WriteLine(count);

            Console.ReadKey();
        }
        static bool Loop(char[][] grid)
        {
            char[] player = ['^', '<', '>', 'v'];

            int count = 0;
            bool @out = false;
            while (!@out)
            {
                for (int i = 0; i < grid.Length && !@out; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (!player.Contains(grid[i][j]))
                        {
                            count++; continue;
                        }

                        if (i == 0 && grid[i][j] == '^'
                            || j == 0 && grid[i][j] == '<'
                            || i == grid.Length - 1 && grid[i][j] == 'v'
                            || j == grid[i].Length - 1 && grid[i][j] == '>')
                        {
                            grid[i][j] = 'X';
                            @out = true;
                            return false;
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
                        count++;
                        if (count > 44162585)
                        {
                            //Console.WriteLine("Looped");
                            return true;
                        }
                    }
                }
            }
            Console.WriteLine("Looped!");
            return true;
        }
    }
}