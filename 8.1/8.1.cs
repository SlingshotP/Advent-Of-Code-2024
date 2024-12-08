namespace _8._1;
internal class Program
{
    static void Main(string[] args)
    {
        //431 too high
        //310 also tried
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

        char[][] gridCopy = new char[grid.Length][]; // Making a copy so that I can overwrite spots that have antennas with antinodes, without losing those antennas
        for (int i = 0; i < grid.Length; i++)
        {
            string line = lines[i];
            gridCopy[i] = new char[lines.Length];
            for (int j = 0; j < line.Length; j++)
            {
                gridCopy[i][j] = line[j];
            }
        }

        for (int i = 0;i < grid.Length; i++)
        {
            for (int j = 0;j < grid[i].Length; j++)
            {
                if (grid[i][j] != '.')
                {
                    char antenna1 = grid[i][j];
                    int antenna1X = j;
                    int antenna1Y = i;
                    for (int k = i; k < grid.Length; k++)
                    {
                        for (int l = 0; l < grid[i].Length; l++)
                        {
                            if (k == i && l <= j) continue;
                            if (grid[k][l] == grid[i][j])
                            {
                                char antenna2 = grid[k][l];
                                int antenna2X = l;
                                int antenna2Y = k;

                                int distanceX;
                                if (antenna2X >= antenna1X)
                                {
                                    distanceX = antenna2X - antenna1X;
                                }
                                else
                                { 
                                    distanceX = antenna1X - antenna2X; 
                                }
                                int distanceY = antenna2Y - antenna1Y;

                                if (antenna2Y + distanceY < grid.Length
                                    && antenna2X >= antenna1X
                                    && antenna2X + distanceX < grid[i].Length) // checking lower antinode isn't off the map to the right
                                {
                                    gridCopy[antenna2Y + distanceY][antenna2X + distanceX] = '#';
                                }
                                else if (antenna2Y + distanceY < grid.Length // to the left
                                    && antenna1X >= antenna2X
                                    && antenna2X - distanceX >= 0)
                                {
                                    gridCopy[antenna2Y + distanceY][antenna2X - distanceX] = '#';
                                }

                                if (antenna1Y - distanceY >= 0
                                    && antenna1X >= antenna2X
                                    && antenna1X + distanceX < grid[i].Length) // checking upper right
                                {
                                    gridCopy[antenna1Y - distanceY][antenna1X + distanceX] = '#';
                                }

                                else if (antenna1Y - distanceY >= 0 // upper left
                                        && antenna1X <= antenna2X
                                        && antenna1X - distanceX >= 0)
                                {
                                    gridCopy[antenna1Y - distanceY][antenna1X - distanceX] = '#';
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
                if (gridCopy[i][j] == '#') count++;
            }
        }
        Console.WriteLine(count);
    }
}