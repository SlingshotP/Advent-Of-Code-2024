namespace _8._2;
internal class Program
{
    static void Main(string[] args)
    {
        //968 tried, too low
        string[] lines = File.ReadAllLines("Text.txt");
        char[][] grid = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            grid[i] = line.ToCharArray();
        }
        // Making a copy so that I can overwrite spots that have antennas with antinodes, without losing those antennas:
        char[][] gridCopy = grid.Select(x => x.ToArray()).ToArray(); 


        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] != '.')
                {
                    char antenna1 = grid[i][j];
                    
                    for (int k = i; k < grid.Length; k++)
                    {
                        for (int l = 0; l < grid[k].Length; l++)
                        {
                            int x1 = j; // (x1, y1) "number one"
                            int y1 = i;
                            int x2 = l; // (x2, y2) "number two"
                            int y2 = k;
                            //Console.WriteLine($"({i}, {j}), ({k}, {l})");
                            // sigma
                            if (k == i && l <= j) continue;
                            if (grid[k][l] == grid[i][j])
                            {
                                char antenna2 = grid[k][l];
                                

                                int distanceX = x2 >= x1 ? x2 - x1 : x1 - x2;
                                int distanceY = y2 - y1;

                                bool done = false;
                                while (!done)
                                {
                                    if (y2 + distanceY < grid.Length // down right
                                        && x2 >= x1
                                        && x2 + distanceX < grid[k].Length) // checking lower antinode isn't off the map to the right
                                    {
                                        gridCopy[y2 + distanceY][x2 + distanceX] = '#';
                                        y2 += distanceY;
                                        x2 += distanceX;
                                    }
                                    else if (y2 + distanceY < grid.Length // down left
                                        && x1 >= x2
                                        && x2 - distanceX >= 0)
                                    {
                                        gridCopy[y2 + distanceY][x2 - distanceX] = '#';
                                        y2 += distanceY;
                                        x2 -= distanceX;
                                    }
                                    else done = true;
                                }
                                done = false;
                                while (!done)
                                {
                                    if (y1 - distanceY >= 0
                                        && x2 <= x1
                                        && x1 + distanceX < grid[k].Length) // upper right
                                    {
                                        gridCopy[y1 - distanceY][x1 + distanceX] = '#';
                                        y1 -= distanceY;
                                        x1 += distanceX;
                                    }

                                    else if (y1 - distanceY >= 0 // upper left
                                            && x1 <= x2
                                            && x1 - distanceX >= 0)
                                    {
                                        gridCopy[y1 - distanceY][x1 - distanceX] = '#';
                                        y1 -= distanceY;
                                        x1 -= distanceX;
                                    }
                                    else done = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        int count = 0;
        for (int i = 0; i < gridCopy.Length; i++) // Looking for all hashtags
        {
            for (int j = 0; j < gridCopy[i].Length; j++)
            {
                if (gridCopy[i][j] != '.') count++;
            }
        }
        Console.WriteLine(count);
    }
}