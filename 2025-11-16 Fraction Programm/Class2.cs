using System;

public class Fraction
{
    public int Num { get; private set; }
    public int Den { get; private set; }

    // Konstruktor
    public Fraction(int num, int den)
    {
        if (den == 0)
            throw new DivideByZeroException();

        Num = num;
        Den = den;

        Simplify();
    }

    // Parsing von: "3/4", "1 1/2", "5"
    public static Fraction Parse(string input)
    {
        if (input == null)
            throw new FormatException();

        input = input.Trim();
        string[] parts = input.Split(' ');

        int whole = 0;
        int num = 0;
        int den = 1;

        if (parts.Length == 2) // "1 3/4"
        {
            whole = int.Parse(parts[0]);
            string[] f = parts[1].Split('/');
            num = int.Parse(f[0]);
            den = int.Parse(f[1]);
        }
        else if (input.Contains("/")) // "3/7"
        {
            string[] f = input.Split('/');
            num = int.Parse(f[0]);
            den = int.Parse(f[1]);
        }
        else // "5"
        {
            whole = int.Parse(input);
            num = 0;
            den = 1;
        }

        // Ganze Zahl in Bruch umwandeln
        num = whole * den + num;

        return new Fraction(num, den);
    }

    // Addition
    public static Fraction operator +(Fraction a, Fraction b)
    {
        int n = a.Num * b.Den + b.Num * a.Den;
        int d = a.Den * b.Den;
        return new Fraction(n, d);
    }

    // Ausgabe
    public override string ToString()
    {
        int whole = Num / Den;
        int rest = Num % Den;

        if (rest == 0)
            return whole.ToString();

        if (whole == 0)
            return $"{rest}/{Den}";

        return $"{whole} {rest}/{Den}";
    }

    // Kürzen
    private void Simplify()
    {
        int gcd = GCD(Math.Abs(Num), Math.Abs(Den));
        Num /= gcd;
        Den /= gcd;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    // Zufallsbruch
    public static string GenerateRandomString()
    {
        Random r = new Random();
        bool mixed = r.Next(2) == 0;

        int whole = mixed ? r.Next(0, 3) : 0;
        int num = r.Next(1, 10);
        int den = r.Next(1, 10);

        if (whole > 0)
            return $"{whole} {num}/{den}";
        return $"{num}/{den}";
    }
}
