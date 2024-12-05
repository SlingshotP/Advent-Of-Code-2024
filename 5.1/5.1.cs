namespace _5._1;
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
            int[] update = updates[i].Split(',').Select(int.Parse).ToArray();


            for (int j = 0; j < update.Length; j++)
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
            if (valid)
            {
                //Console.WriteLine($"Update {i} is legit fam no cap!");
                sum += update[update.Length / 2];
            }

        }
        Console.WriteLine(sum);

        Console.ReadKey();
    }
}