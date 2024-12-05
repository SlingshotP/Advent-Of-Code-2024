namespace _5._2;
internal class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("Text.txt");
        List<string> strRules = [];
        foreach (string line in lines)
        {
            if (line != "")
            {
                strRules.Add(line);
            }
            else break;
        }
        var rules = strRules.Select(rule => rule.Split('|').Select(int.Parse).ToArray()).ToArray();
        List<string> updates = [];
        foreach (string line in lines)
        {
            if (line.Contains(','))
            {
                updates.Add(line);
            }
        }

        int sum = 0;
        for (int i = 0; i < updates.Count; i++)
        {
            bool valid = true /*no cap*/;
            List<int> update = updates[i].Split(',').Select(int.Parse).ToList();


            for (int j = 0; j < update.Count; j++)
            {
                for (int k = 0; k < rules.Length; k++)
                {
                    var rule = rules[k];
                    int x = rule[0];
                    int y = rule[1];
                    if (update[j] == x)
                    {
                        if (update[..j].Contains(y))
                        {
                            valid = false;
                            break;
                        }
                    }
                }
            }
            if (!valid)
            {
                bool sorted = false;
                while (!sorted)
                {
                    sorted = true;
                    for (int j = 0; j < update.Count; j++)
                    {
                        for (int k = 0; k < update.Count; k++)
                        {
                            if (j <= k) continue;

                            for (int l = 0; l < rules.Length; l++)
                            {
                                var rule = rules[l];
                                int x = rule[0];
                                int y = rule[1];
                                if (update[j] == y && update[k] == x)
                                {
                                    (update[j], update[k]) = (update[k], update[j]);
                                    sorted = false;
                                }
                            }
                        }
                    }
                }
                sum += update[update.Count / 2];

            }

        }
        Console.WriteLine(sum);

        Console.ReadKey();
    }
}