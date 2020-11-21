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
    }
}
