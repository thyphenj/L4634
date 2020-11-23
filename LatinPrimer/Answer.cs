using System;
namespace LatinPrimer
{
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
