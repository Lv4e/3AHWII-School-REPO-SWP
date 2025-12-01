using System;

class Program
{
    static void Main(string[] args)
    {
        var f1 = ToImproperFraction(args[0]);
        var f2 = ToImproperFraction(args[1]);

        int numerator = f1.Item1 * f2.Item2 + f2.Item1 * f1.Item2;
        int denominator = f1.Item2 * f2.Item2;

        Simplify(ref numerator, ref denominator);

        int whole = numerator / denominator;
        int remainder = numerator % denominator;

        if (remainder == 0)
            Console.WriteLine(whole);
        else if (whole == 0)
            Console.WriteLine($"{remainder}/{denominator}");
        else
            Console.WriteLine($"{whole} {remainder}/{denominator}");
    }

    // Converts "2 3/8" to (19, 8)
    static Tuple<int, int> ToImproperFraction(string input)
    {
        string[] parts = input.Split(' ');
        int whole = 0;
        int numerator, denominator;

        if (parts.Length == 2)
        {
            whole = int.Parse(parts[0]);
            var frac = parts[1].Split('/');
            numerator = int.Parse(frac[0]);
            denominator = int.Parse(frac[1]);
        }
        else if (input.Contains("/"))
        {
            var frac = parts[0].Split('/');
            numerator = int.Parse(frac[0]);
            denominator = int.Parse(frac[1]);
        }
        else
        {
            return Tuple.Create(int.Parse(input), 1);
        }

        numerator = whole * denominator + numerator;
        return Tuple.Create(numerator, denominator);
    }

    static void Simplify(ref int num, ref int den)
    {
        int gcd = GCD(Math.Abs(num), den);
        num /= gcd;
        den /= gcd;
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}
