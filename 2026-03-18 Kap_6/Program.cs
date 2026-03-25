using System;
using System.Text;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = Encoding.UTF8;

		PrintTitle("Kap 5.6 – Signaturen (Überladung, optional, params)");
		DemoSignaturen();

		PrintTitle("Kap 6 – Referenz- und Wertetypen");
		DemoValueVsReferenceTypes();

		PrintTitle("Kap 6 – ref vs out");
		DemoRefVsOut();

		PrintTitle("Kap 7 – Beziehungen von Objekten");
		DemoObjectRelationships();

		PrintTitle("Kap 8 – Strings: .Equals / == / StringBuilder");
		DemoStrings();

		PrintTitle("Kap 9 – Schleifen: break / continue");
		DemoLoopsBreakContinue();
	}

	static void PrintTitle(string title)
	{
		Console.WriteLine();
		Console.WriteLine(new string('=', title.Length));
		Console.WriteLine(title);
		Console.WriteLine(new string('=', title.Length));
	}

	// --- Kap 5.6: Signaturen ---
	static void DemoSignaturen()
	{
		Console.WriteLine($"Add(2, 3) = {Add(2, 3)}");
		Console.WriteLine($"Add(2.5, 3.1) = {Add(2.5, 3.1):F2}");

		Console.WriteLine(FormatResult(42));
		Console.WriteLine(FormatResult(42, prefix: "Antwort"));

		Console.WriteLine($"Sum(1,2,3,4) = {Sum(1, 2, 3, 4)}");
	}

	static int Add(int a, int b) => a + b;
	static double Add(double a, double b) => a + b;
	static string FormatResult(int value, string prefix = "Result") => $"{prefix}: {value}";
	static int Sum(params int[] values)
	{
		int total = 0;
		foreach (int v in values) total += v;
		return total;
	}

	// --- Kap 6: Wertetyp vs Referenztyp ---
	struct Punkt
	{
		public int X;
		public int Y;
		public override string ToString() => $"({X},{Y})";
	}

	class Kiste
	{
		public int Wert;
		public override string ToString() => $"Kiste(Wert={Wert})";
	}

	static void DemoValueVsReferenceTypes()
	{
		Punkt p1 = new Punkt { X = 1, Y = 2 };
		Punkt p2 = p1; // Kopie
		p2.X = 99;

		Console.WriteLine($"p1 = {p1} (unverändert)");
		Console.WriteLine($"p2 = {p2} (geändert)");

		Kiste k1 = new Kiste { Wert = 10 };
		Kiste k2 = k1; // gleiche Referenz
		k2.Wert = 777;

		Console.WriteLine($"k1 = {k1} (mitgeändert)");
		Console.WriteLine($"k2 = {k2} (gleiche Referenz)");
	}

	// --- Kap 6: ref vs out ---
	static void DemoRefVsOut()
	{
		int a = 5;
		int b = 9;
		Console.WriteLine($"Vor Swap: a={a}, b={b}");
		Swap(ref a, ref b);
		Console.WriteLine($"Nach Swap: a={a}, b={b}");

		string input = "123";
		if (TryParsePositiveInt(input, out int number))
		{
			Console.WriteLine($"'{input}' wurde zu {number} geparst.");
		}
		else
		{
			Console.WriteLine($"'{input}' ist keine gültige positive Zahl.");
		}
	}

	static void Swap(ref int left, ref int right)
	{
		int tmp = left;
		left = right;
		right = tmp;
	}

	static bool TryParsePositiveInt(string text, out int value)
	{
		if (!int.TryParse(text, out value)) return false;
		if (value <= 0)
		{
			value = 0;
			return false;
		}
		return true;
	}

	// --- Kap 7: Beziehungen von Objekten ---
	class Adresse
	{
		public string Stadt { get; set; }
		public Adresse(string stadt)
		{
			Stadt = string.IsNullOrWhiteSpace(stadt) ? "(unbekannt)" : stadt;
		}
		public override string ToString() => Stadt;
	}

	class Person
	{
		public string Name { get; }
		public Adresse Adresse { get; }
		public Person(string name, Adresse adresse)
		{
			Name = string.IsNullOrWhiteSpace(name) ? "(unbekannt)" : name;
			Adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
		}
		public override string ToString() => $"{Name} aus {Adresse}";
	}

	static void DemoObjectRelationships()
	{
		// Aggregation: zwei Personen teilen sich dieselbe Adresse (gleiche Referenz)
		var gemeinsameAdresse = new Adresse("Wien");
		var p1 = new Person("Anna", gemeinsameAdresse);
		var p2 = new Person("Ben", gemeinsameAdresse);

		Console.WriteLine(p1);
		Console.WriteLine(p2);

		gemeinsameAdresse.Stadt = "Graz";
		Console.WriteLine("Nach Änderung der Adresse:");
		Console.WriteLine(p1);
		Console.WriteLine(p2);
	}

	// --- Kap 8: Strings ---
	static void DemoStrings()
	{
		string s1 = "Hallo";
		string s2 = "Ha" + "llo";

		Console.WriteLine($"s1 == s2: {s1 == s2}");
		Console.WriteLine($"s1.Equals(s2): {s1.Equals(s2)}");

		string name1 = "lukas";
		string name2 = "LUKAS";
		Console.WriteLine($"OrdinalIgnoreCase Equals: {string.Equals(name1, name2, StringComparison.OrdinalIgnoreCase)}");

		// StringBuilder ist effizient, wenn man viele Teile zusammenfügt
		var sb = new StringBuilder();
		for (int i = 1; i <= 5; i++)
		{
			sb.Append("#");
			sb.Append(i);
			if (i < 5) sb.Append(", ");
		}
		Console.WriteLine($"StringBuilder: {sb}");
	}

	// --- Kap 9: Schleifen + break/continue ---
	static void DemoLoopsBreakContinue()
	{
		Console.WriteLine("continue-Beispiel (überspringe Vielfache von 3):");
		for (int i = 1; i <= 10; i++)
		{
			if (i % 3 == 0) continue;
			Console.Write(i + " ");
		}
		Console.WriteLine();

		Console.WriteLine("break-Beispiel (stoppe bei erster Zahl > 7):");
		int[] numbers = { 2, 4, 7, 8, 10 };
		foreach (int n in numbers)
		{
			if (n > 7) break;
			Console.Write(n + " ");
		}
		Console.WriteLine();
	}
}
