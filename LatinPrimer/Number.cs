using System;
namespace LatinPrimer
{
    public class Number
    {
        public int Integer { get; set; }
        public string Roman { get; set; }
        public int Length { get; set; }

        public Number(int n)
        {
            setValues(n, Rule.Romanise(n));
        }
        public Number(int n, string str)
        {
            setValues(n, str);
        }
        private void setValues(int n, string str)
        {
            Integer = n;
            Roman = str;
            Length = str.Length;
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
        public bool Contains(char ch, int pos)
        {
            return Roman[pos] == ch;
        }
        public override string ToString()
        {
            return Roman;
        }
        public string Format()
        {
            return $"{Integer,4} - {Roman}";
        }
        public int Sum(Number a)
        {
            return (this.Integer + a.Integer);
        }
        public int Sum(int a)
        {
            return (this.Integer + a);
        }
    }
}
