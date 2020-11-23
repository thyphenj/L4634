using System;
using System.Linq;
using System.Collections.Generic;

namespace LatinPrimer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Number> numbers = new List<Number>();

            foreach (var p in Prime.Primes)
            {
                var n = new Number(p);
                if (n.Length > 1 && n.Length < 10)
                {
                    numbers.Add(n);
                }
            }

            //for (int i = 2; i < 10; i++)
            //{
            //    Console.WriteLine($"=================={i}===============");
            //    foreach (var n in numbers.Where(a => a.Length == i).OrderBy(b => b.Roman))
            //    {
            //        Console.WriteLine(n.Format());
            //    }
            //}


            //------------------------------------------------------------------
            Console.WriteLine("\n------ 2n == 2p + a + 3 ----------");
            List<Number[]> poss_np = new List<Number[]>();
            foreach (var p in numbers.Where(a => a.Length == 6))
            {
                foreach (var n in numbers.Where(a => a.Length == 6))
                {
                    int aaa = 2 * n.Integer - 2 * p.Integer - 3;
                    foreach (var a in numbers.Where(z => z.Length == 2))
                    {
                        if (aaa == a.Integer)
                        {
                            Console.WriteLine($"npa - {n} {p} {a}");
                            poss_np.Add(new Number[] { n, p });  // a = CI
                        }

                    }
                }
            }
            Number A = new Number(101);

            //------------------------------------------------------------------
            Console.WriteLine("\n-------- s + b == t + a ----------");
            List<Number[]> poss_sbt = new List<Number[]>();
            foreach (var s in numbers.Where(z => z.Length == 9))
            {
                foreach (var t in numbers.Where(z => z.Length == 9 && z.Integer != s.Integer))
                {
                    int bbb = t.Integer + A.Integer - s.Integer;
                    foreach (var b in numbers.Where(z => z.Length == 2))
                    {
                        if (bbb == b.Integer)
                        {
                            if (s.Contains(A.Roman[0], 0) || t.Contains(A.Roman[0], 0))
                            {
                                Console.WriteLine($"sbtA - {s} {b} {t} {A}");
                                poss_sbt.Add(new Number[] { s, b, t });
                            }
                        }
                    }
                }
            }
            Number S, B, T;
            if (poss_sbt.Count == 1)
            {
                S = new Number(poss_sbt[0][0].Integer);
                B = new Number(poss_sbt[0][1].Integer);
                T = new Number(poss_sbt[0][2].Integer);
            }


            //------------------------------------------------------------------
            Console.WriteLine("\n----- q + 15 == 4r -------------");
            List<Number[]> poss_qr = new List<Number[]>();
            foreach (var q in numbers.Where(z => z.Length == 7))
            {
                foreach (var r in numbers.Where(z => z.Length == 7 && z.Integer != q.Integer))
                {
                    if (q.Integer + 15 == 4 * r.Integer)
                    {
                        if (r.Contains(A.Roman[0], 1) || q.Contains(A.Roman[0], 1))
                        {
                            Console.WriteLine($"qr - {q} {r}");
                            poss_qr.Add(new Number[] { q, r });
                        }
                        else
                            Console.WriteLine($"     {q} {r} xxxxxxxxxxxxxx");
                    }
                }
            }
        }
        //    {
        //        if (r.Roman.Length == 7 && r.Value * 4 - 15 < 2000)
        //        {
        //            int q = 4 * r.Value - 15;
        //            if (IsPrime(q) && Rule.Romanise(q).Length == 7)
        //                if (Rule.Romanise(q)[1] == 'C' || r.Roman[1] == 'C')
        //                    Console.WriteLine($"{Rule.Romanise(q)} + XV = IV * {r.Roman}");
        //        }
        //    }
        //    int Q = 318;
        //    int R = 83;

        //    Console.WriteLine("\n-------- s + b == t + a ----------");
        //    foreach (var t in Prime.RomanPrimes)
        //    {
        //        if (t.Roman.Length == 9 && t.Value * 5 < 2000)
        //        {
        //            int s = t.Value + A - B;
        //            if (IsPrime(s) && Rule.Romanise(s).Length == 9)
        //                Console.WriteLine($"{Rule.Romanise(s)} + {Rule.Romanise(B)} = {t.Roman} + {Rule.Romanise(A)}");

        //        }
        //    }
        //    int S = 373;
        //    int T = 283;

        //    Console.WriteLine("\n-------- m + 4 == s + 2a ---");
        //    int M = S + 2 * A - 4;
        //    Console.WriteLine($"{Rule.Romanise(M)} + IV = {Rule.Romanise(S)} + II * {Rule.Romanise(A)}");

        //    Console.WriteLine("\n-------- d = 5t + c + n ---");
        //    foreach (int n in new int[] { 89, 179, 359 })
        //    {
        //        foreach (int c in new int[] { 3, 7, 19, 41, 69, 61, 109, 151 })
        //        {
        //            int d = 5 * T + c + n;
        //            if (IsPrime(d) && Rule.Romanise(d).Length == 4)
        //                Console.WriteLine($"{Rule.Romanise(d)} = V * {Rule.Romanise(T)} + {Rule.Romanise(c)} + {Rule.Romanise(n)}");
        //        }
        //    }
        //    int C = 7;

        //    Console.WriteLine("\n-------- e + f + g + h + k + 7 = s + m ---");
        //    foreach (var e in Prime.RomanPrimes)
        //    {
        //        if (e.Roman.Length == 4)
        //            foreach (var f in Prime.RomanPrimes)
        //                if (f.Roman.Length == 4 && f.Value > e.Value)
        //                    foreach (var g in Prime.RomanPrimes)
        //                        if (g.Roman.Length == 4 && g.Value > f.Value)
        //                            foreach (var h in Prime.RomanPrimes)
        //                                if (h.Roman.Length == 4 && h.Value > g.Value)
        //                                    foreach (var k in Prime.RomanPrimes)
        //                                        if (k.Roman.Length == 4 && k.Value > h.Value)
        //                                        {
        //                                            int sum = e.Value + f.Value + g.Value + h.Value + k.Value + 7;
        //                                            if (e.Roman[1] == 'C' || f.Roman[1] == 'C' || g.Roman[1] == 'C' || h.Roman[1] == 'C' || k.Roman[1] == 'C')
        //                                                if (sum == S + M)
        //                                                    Console.WriteLine($"{e.Roman} {f.Roman} {g.Roman} {h.Roman} {k.Roman}");
        //                                        }
        //    }
        //}
        //private static bool IsPrime(int a)
        //{
        //    foreach (int p in Prime.Primes)
        //    {
        //        if (p == a)
        //            return true;
        //    }
        //    return false;
        //}

        //private void Init()
        //{
        //    foreach (int prime in Prime.Primes)
        //    {
        //        string romanised = Rule.Romanise(prime);
        //        int romanLength = romanised.Length;
        //        if (romanLength > 1 && romanLength < 10)
        //        {
        //            var answer = new Answer(prime, romanised);
        //            if (romanLength >= 4 || !answer.Contains('M') && !answer.Contains('D'))
        //            {
        //                //    RomanPrimes.Add(answer);
        //            }
        //        }
        //    }

    }

}
