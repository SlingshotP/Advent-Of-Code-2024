namespace _6._2;
internal class Program
{
    // 1599 tried, incorrect

    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("Text.txt");
        char[][] grid = new char[lines.Length][];

        int x = -1, y = -1;
        char d = '^';
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            grid[i] = new char[line.Length];
            for (int j = 0; j < line.Length; j++)
            {
                grid[i][j] = line[j];
                if (grid[i][j] == d)
                {
                    x = j;
                    y = i;
                }
            }
        }
        //Console.WriteLine($"Guard is at row {y}, column {x}");

        List<(int x, int y, char d)> directionalHistory = [];
        Loop(grid, x, y, d, directionalHistory);

        var history = directionalHistory.Select(i => (i.x, i.y)).Distinct().ToList();

        //Console.SetCursorPosition(0, 0);
        //for (int i = 0; i < grid.Length; i++)
        //{
        //    for (int j = 0; j < grid[i].Length; j++)
        //    {
        //        Console.Write(grid[i][j]);
        //    }
        //    Console.WriteLine();
        //}

        int count = 0;
        foreach (var (j, i) in history)
        {
            //Console.SetCursorPosition(j, i);
            //Console.Write('X');

            var temp = grid[i][j];
            grid[i][j] = '#';

            if (Loop(grid, x, y, d, []))
            {
                //Console.WriteLine($"({j}, {i})");
                count++;
            }
            grid[i][j] = temp;
            //Console.WriteLine("One pos");
        }
        //Console.SetCursorPosition(0, grid.Length);
        Console.WriteLine(count);
    }
    static bool Loop(char[][] grid, int x, int y, char d, List<(int x, int y, char d)> history)
    {
        while (true)
        {
            if (history.Contains((x, y, d)))
            {
                //Console.WriteLine($"{x}, {y}, {d}");
                return true;
            }

            history.Add((x, y, d));
            if (y == 0 || x == 0 || y == grid.Length - 1 || x == grid[y].Length - 1)
            {
                return false;
            }

            // Up
            if (d == '^')
            {
                if (grid[y - 1][x] == '#')
                {
                    d = '>';
                }
                else
                {
                    y--;
                }
            }
            // Right
            else if (d == '>')
            {
                if (grid[y][x + 1] == '#')
                {
                    d = 'v';
                }
                else
                {
                    x++;
                }
            }
            // Down
            else if (d == 'v')
            {
                if (grid[y + 1][x] == '#')
                {
                    d = '<';
                }
                else
                {
                    y++;
                }
            }
            // Left
            else //if (d == '<')
            {
                if (grid[y][x - 1] == '#')
                {
                    d = '^';
                }
                else
                {
                    x--;
                }
            }
        }
    }
}