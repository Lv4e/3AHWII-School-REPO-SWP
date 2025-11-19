using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // --- 1. Commandline-Arguments ---
            if (args.Length == 2)
            {
                Fraction f1 = Fraction.Parse(args[0]);
                Fraction f2 = Fraction.Parse(args[1]);
                Fraction result = f1 + f2;

                Console.WriteLine($"Ergebnis (Args): {result}");
                return;
            }
            else if (args.Length != 0)
            {
                Console.WriteLine("Fehler: Bitte genau zwei Argumente angeben!");
                Console.WriteLine("Beispiel: Program.exe \"1 1/2\" \"2/3\"");
                return;
            }

            // --- 2. Optional: Zufällige Testfälle ---
            Console.WriteLine("Wie viele zufällige Testfälle möchten Sie generieren? (0 für keine):");
            int testCount = int.Parse(Console.ReadLine() ?? "0");

            if (testCount > 0)
            {
                Console.WriteLine("\nZufällige Testfälle:");
                for (int i = 0; i < testCount; i++)
                {
                    string s1 = Fraction.GenerateRandomString();
                    string s2 = Fraction.GenerateRandomString();

                    Fraction f1 = Fraction.Parse(s1);
                    Fraction f2 = Fraction.Parse(s2);
                    Fraction result = f1 + f2;

                    Console.WriteLine($"{i + 1}: {s1} + {s2} = {result}");
                }
            }

            Console.WriteLine("\n--- Eigene Eingaben ---");

            // --- 3. Manuelle Eingabe ---
            Console.WriteLine("Geben Sie den ersten Bruch ein (z.B. 2/3 oder 1 1/2):");
            Fraction a = Fraction.Parse(Console.ReadLine());

            Console.WriteLine("Geben Sie den zweiten Bruch ein:");
            Fraction b = Fraction.Parse(Console.ReadLine());

            Console.WriteLine($"Ergebnis: {a + b}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Fehler: Ungültiges Eingabeformat.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Fehler: Division durch Null.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unbekannter Fehler: " + ex.Message);
        }
    }
}
