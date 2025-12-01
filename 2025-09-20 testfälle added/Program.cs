using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Wie viele zufällige Testfälle möchten Sie generieren? (0 für keine):");
            int testCount = int.Parse(Console.ReadLine() ?? "0");

            if (testCount > 0)
            {
                Console.WriteLine("\nZufällige Testfälle:");
                for (int i = 0; i < testCount; i++)
                {
                    string frac1 = GenerateRandomFraction();
                    string frac2 = GenerateRandomFraction();
                    Console.WriteLine($"{i + 1}: {frac1} + {frac2} = {AddFractions(frac1, frac2)}");
                }
                Console.WriteLine("\n--- Eigene Eingaben ---");
            }

            Console.WriteLine("Geben Sie den ersten Bruch ein (z.B. 2/3 oder 1 1/2):");
            string input1 = Console.ReadLine();
            Console.WriteLine("Geben Sie den zweiten Bruch ein:");
            string input2 = Console.ReadLine();

            Console.WriteLine($"Ergebnis: {AddFractions(input1, input2)}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Fehler: Ungültiges Eingabeformat. Bitte geben Sie Brüche im Format 'Ganzzahl Zähler/Nenner' oder 'Zähler/Nenner' ein.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Fehler: Division durch Null. Der Nenner darf nicht Null sein.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unbekannter Fehler: {ex.Message}");
        }
    }

    static string AddFractions(string s1, string s2)
    {
        var f1 = ToImproperFraction(s1);
        var f2 = ToImproperFraction(s2);

        int numerator = f1.Item1 * f2.Item2 + f2.Item1 * f1.Item2;
        int denominator = f1.Item2 * f2.Item2;

        Simplify(ref numerator, ref denominator);

        int whole = numerator / denominator;
        int remainder = numerator % denominator;

        if (remainder == 0)
            return whole.ToString();
        else if (whole == 0)
            return $"{remainder}/{denominator}";
        else
            return $"{whole} {remainder}/{denominator}";
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

        if (denominator == 0)
            throw new DivideByZeroException();

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

    static string GenerateRandomFraction()
    {
        Random rnd = new Random();
        // Decide randomly if it will be a mixed number or a simple fraction
        bool mixed = rnd.Next(2) == 0;
        int whole = mixed ? rnd.Next(0, 3) : 0;
        int numerator = rnd.Next(1, 10);
        int denominator = rnd.Next(1, 10);
        return whole > 0 ? $"{whole} {numerator}/{denominator}" : $"{numerator}/{denominator}";
    }
}
