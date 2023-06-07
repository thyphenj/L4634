namespace L4634;

using System;
using System.Collections.Generic;

public class Numbers
{
    public List<Number>[] NumberList;

    public Numbers()
    {
        NumberList = new List<Number>[]
            {
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
            new List<Number>(),
         };


        foreach (var p in Prime.Primes)
        {
            var n = new Number(p);
            if (n.Length > 1 && n.Length < 10)
            {
                NumberList[n.Length].Add(n);
            }
        }
    }
    public List<Number> WithLength(int len)
    {
        return NumberList[len];
    }
}
