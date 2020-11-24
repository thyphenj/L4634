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

            //------------------------------------------------------------------
            Console.WriteLine("\n------ 2n == 2p + a + 3 ----------");
            List<Number[]> poss_npa = new List<Number[]>();
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
                            poss_npa.Add(new Number[] { n, p, a });  // a = CI
                        }

                    }
                }
            }
            Number A;
            {
                Console.WriteLine(poss_npa.Count);
                A = new Number(poss_npa[0][2].Integer);
                Console.WriteLine($"-----A = {A.Format()}");
            }

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
            //if (poss_sbt.Count == 1)
            {
                Console.WriteLine(poss_sbt.Count);
                S = new Number(poss_sbt[0][0].Integer);
                T = new Number(poss_sbt[0][2].Integer);
                B = new Number(poss_sbt[0][1].Integer);
                Console.WriteLine($"-----S = {S.Format()}");
                Console.WriteLine($"-----T = {T.Format()}");
                Console.WriteLine($"-----B = {B.Format()}");
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
                    }
                }
            }
            Number Q, R;
            //if (poss_qr.Count == 1)
            {
                Console.WriteLine(poss_qr.Count);
                Q = new Number(poss_qr[0][0].Integer);
                R = new Number(poss_qr[0][1].Integer);
                Console.WriteLine($"-----Q = {Q.Format()}");
                Console.WriteLine($"-----R = {R.Format()}");
            }

            //------------------------------------------------------------------
            Console.WriteLine("\n-------- m + 4 == s + 2a ---");
            List<Number> poss_m = new List<Number>();
            foreach (var m in numbers.Where(z => z.Length == 5))
            {
                if (m.Integer + 4 == S.Integer + 2 * A.Integer)
                {
                    Console.WriteLine($"m - {m}");
                    poss_m.Add(new Number(m.Integer));
                }
            }
            Number M;
            // if ()
            {
                Console.WriteLine(poss_m.Count);
                M = new Number(poss_m[0].Integer);
                Console.WriteLine($"-----M = {M.Format()}");
            }

            //------------------------------------------------------------------
            Console.WriteLine("\n-------- d = 5t + c + n ---");
            List<Number[]> poss_dcn = new List<Number[]>();
            foreach (var d in numbers.Where(z => z.Length == 4 && z.Integer > 5 * T.Integer))
            {
                foreach (var np in poss_npa)
                {
                    foreach (var n in np.Where(z => z.Length == 6))
                    {
                        foreach (var c in numbers.Where(z => z.Length == 3))
                        {
                            if (d.Integer == 5 * T.Integer + c.Integer + n.Integer)
                            {
                                Console.WriteLine($"dcn - {d} {c} {n}");
                                poss_dcn.Add(new Number[] { d, c, n });
                            }
                        }
                    }
                }
            }
            {
                Console.WriteLine(poss_dcn.Count);
            }

            //------------------------------------------------------------------
            Console.WriteLine("\n-------- e + f + g + h + k + 7 = s + m ---");
            List<Number[]> poss_efghk = new List<Number[]>();
            foreach (var e in numbers.Where(z => z.Length == 4))
            {
                foreach (var f in numbers.Where(z => z.Length == 4 && z.Integer > e.Integer))
                {
                    foreach (var g in numbers.Where(z => z.Length == 4 && z.Integer > f.Integer))
                    {
                        foreach (var h in numbers.Where(z => z.Length == 4 && z.Integer > g.Integer))
                        {
                            foreach (var k in numbers.Where(z => z.Length == 4 && z.Integer > h.Integer))
                            {
                                //        if (e.Roman[1] == 'C' || f.Roman[1] == 'C' || g.Roman[1] == 'C' || h.Roman[1] == 'C' || k.Roman[1] == 'C')
                                if (e.Sum(f.Sum(g.Sum(h.Sum(k.Sum(7))))) == S.Sum(M))
                                {
                                    Console.WriteLine($"efghk - {e} {f} {g} {h} {k}");
                                    poss_efghk.Add(new Number[] { e, f, g, h, k });
                                }
                            }
                        }
                    }
                }
            }
            {
                Console.WriteLine(poss_efghk.Count);
            }
        }
    }
}
