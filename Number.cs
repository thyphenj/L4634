namespace L4634;

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

    public bool HasCharAtPosition(char ch, int pos) => Roman[pos] == ch;

    public int Sum(Number a) => (this.Integer + a.Integer);

    public int Sum(int a) => (this.Integer + a);

    public bool Equals(Number other) => this.Integer == other.Integer;

    public bool Equals(int other) => this.Integer == other;

    public string Format() => $"{Integer,4} - {Roman}";

    public override string ToString() => Roman;
}