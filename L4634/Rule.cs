using System;

namespace LatinPrimer
{
    //------------------------------------------------------
    class Rule
    {
        public int N { get; set; }
        public string Symbol { get; set; }

        public Rule(int n, string symbol)
        {
            N = n;
            Symbol = symbol;
        }
        //------------------------------------------------------
        // Create rules in descending order
        static Rule[] Rules = new Rule[]
        {
            new Rule(1000, "M"),
            new Rule(900, "CM"),
            new Rule(500, "D"),
            new Rule(400, "CD"),
            new Rule(100, "C"),
            new Rule(90, "XC"),
            new Rule(50, "L"),
            new Rule(40, "XL"),
            new Rule(10, "X"),
            new Rule(9, "IX"),
            new Rule(5, "V"),
            new Rule(4, "IV"),
            new Rule(1, "I"),
        };

        public static string Romanise(int n)
        {
            if (n == 0)
                return "";

            foreach (var rule in Rules)
            {
                if (rule.N <= n)
                {
                    return rule.Symbol + Romanise(n - rule.N);
                }
            }
            throw new ArgumentOutOfRangeException("$recursion failure - n={n}");
        }

    }
}
