using System;
using System.Collections.Generic;

namespace LatinPrimer
{
    class Program
    {
        static int[] primes = {
   2,    3,    5,    7,   11,   13,   17,   19,   23,   29,
  31,   37,   41,   43,   47,   53,   59,   61,   67,   71,
  73,   79,   83,   89,   97,  101,  103,  107,  109,  113,
 127,  131,  137,  139,  149,  151,  157,  163,  167,  173,
 179,  181,  191,  193,  197,  199,  211,  223,  227,  229,
 233,  239,  241,  251,  257,  263,  269,  271,  277,  281,
 283,  293,  307,  311,  313,  317,  331,  337,  347,  349,
 353,  359,  367,  373,  379,  383,  389,  397,  401,  409,
 419,  421,  431,  433,  439,  443,  449,  457,  461,  463,
 467,  479,  487,  491,  499,  503,  509,  521,  523,  541,
 547,  557,  563,  569,  571,  577,  587,  593,  599,  601,
 607,  613,  617,  619,  631,  641,  643,  647,  653,  659,
 661,  673,  677,  683,  691,  701,  709,  719,  727,  733,
 739,  743,  751,  757,  761,  769,  773,  787,  797,  809,
 811,  821,  823,  827,  829,  839,  853,  857,  859,  863,
 877,  881,  883,  887,  907,  911,  919,  929,  937,  941,
 947,  953,  967,  971,  977,  983,  991,  997, 1009, 1013,
1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069,
1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151,
1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223,
1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291,
1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373,
1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451,
1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511,
1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583,
1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657,
1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733,
1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811,
1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889
};
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
        static List<Answer> Answers = new List<Answer>();

        static void Main(string[] args)
        {
            int count = 0;
            foreach (int prime in primes)
            {
                string romanised = Romanise(prime);
                int romanLength = romanised.Length;
                if (romanLength > 1 && romanLength < 10)
                {
                    var answer = new Answer(prime, romanised);
                    if ((answer.Contains('M') || answer.Contains('D')) && romanLength < 4)
                    {
                        //Console.WriteLine($"====> {prime,4}  {romanised}");
                    }
                    else
                    {
                        Answers.Add(answer);
                        count++;
                        //Console.WriteLine($"{count,3} - {prime,4}  {romanised}");
                    }
                }
            }
            for (int i = 2; i < 6; i++)
            {
                foreach (var ans in Answers)
                {
                    if (ans.Roman.Length == i)
                    {
                        Console.WriteLine(ans);
                    }
                }
                Console.WriteLine();
            }


            //------------------------------------------------------
            Console.WriteLine("\n------ 2n == 2p + a + 3 ----------");
            foreach (var p in Answers)
            {
                if (p.Roman.Length == 6)
                {
                    foreach (int a in new int[] { 11, 101 })
                    {
                        int N = 2 * p.Value + a + 3;
                        if (N % 2 == 0 && IsPrime(N / 2) && Romanise(N / 2).Length == 6)
                            Console.WriteLine($"II * {Romanise(N / 2)} = II * {p.Roman} + {Romanise(a)} + III");
                    }
                }
            }
            int A = 101;
            int B = 11;

            Console.WriteLine("\n----- q + 15 == 4r -------------");
            foreach (var r in Answers)
            {
                if (r.Roman.Length == 7 && r.Value * 4 - 15 < 2000)
                {
                    int q = 4 * r.Value - 15;
                    if (IsPrime(q) && Romanise(q).Length == 7)
                        if (Romanise(q)[1] == 'C' || r.Roman[1] == 'C')
                            Console.WriteLine($"{Romanise(q)} + XV = IV * {r.Roman}");
                }
            }
            int Q = 318;
            int R = 83;

            Console.WriteLine("\n-------- s + b == t + a ----------");
            foreach (var t in Answers)
            {
                if (t.Roman.Length == 9 && t.Value * 5 < 2000)
                {
                    int s = t.Value + A - B;
                    if (IsPrime(s) && Romanise(s).Length == 9)
                        Console.WriteLine($"{Romanise(s)} + {Romanise(B)} = {t.Roman} + {Romanise(A)}");

                }
            }
            int S = 373;
            int T = 283;

            Console.WriteLine("\n-------- m + 4 == s + 2a ---");
            int M = S + 2 * A - 4;
            Console.WriteLine($"{Romanise(M)} + IV = {Romanise(S)} + II * {Romanise(A)}");

            Console.WriteLine("\n-------- d = 5t + c + n ---");
            foreach (int n in new int[] { 89, 179, 359 })
            {
                foreach (int c in new int[] { 3, 7, 19, 41, 69, 61, 109, 151 })
                {
                    int d = 5 * T + c + n;
                    if (IsPrime(d) && Romanise(d).Length == 4)
                        Console.WriteLine($"{Romanise(d)} = V * {Romanise(T)} + {Romanise(c)} + {Romanise(n)}");
                }
            }
            int C = 7;

            Console.WriteLine("\n-------- e + f + g + h + k + 7 = s + m ---");
            foreach (var e in Answers)
            {
                if (e.Roman.Length == 4)
                    foreach (var f in Answers)
                        if (f.Roman.Length == 4 && f.Value > e.Value)
                            foreach (var g in Answers)
                                if (g.Roman.Length == 4 && g.Value > f.Value)
                                    foreach (var h in Answers)
                                        if (h.Roman.Length == 4 && h.Value > g.Value)
                                            foreach (var k in Answers)
                                                if (k.Roman.Length == 4 && k.Value > h.Value)
                                                {
                                                    int sum = e.Value + f.Value + g.Value + h.Value + k.Value + 7;
                                                    if (e.Roman[1] == 'C' || f.Roman[1] == 'C' || g.Roman[1] == 'C' || h.Roman[1] == 'C' || k.Roman[1] == 'C')
                                                        if (sum == S + M)
                                                            Console.WriteLine($"{e.Roman} {f.Roman} {g.Roman} {h.Roman} {k.Roman}");
                                                }
            }
        }
        //------------------------------------------------------
        private static string Romanise(int n)
        {
            if (n == 0) return ""; // Recursion termination

            foreach (var rule in Rules) // Rules are in descending order
                if (rule.N <= n)
                    return rule.Symbol + Romanise(n - rule.N); // Recurse 

            // If this line is reached then n < 0
            throw new ArgumentOutOfRangeException("n must be greater than or equal to 0");
        }
        private static bool IsPrime(int a)
        {
            foreach (int p in primes)
            {
                if (p == a)
                    return true;
            }
            return false;
        }
    }
    //------------------------------------------------------

    class Answer
    {
        public int Value { get; set; }
        public string Roman { get; set; }

        public Answer(int value, string roman)
        {
            Value = value;
            Roman = roman;
        }
        public bool Contains(char ch)
        {
            foreach (char chr in Roman)
            {
                if (ch == chr)
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            return ($"{Value,4} {Roman}");
        }
    }
}
