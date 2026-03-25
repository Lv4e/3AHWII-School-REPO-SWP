using System;
using System.Collections.Generic;

public interface IInventarGegenstand
{
	string Name { get; }
	string BeschreibeDich();
}

public class Waffe : IInventarGegenstand
{
	public string Name { get; }
	public int Schaden { get; }

	public Waffe(string name, int schaden)
	{
		if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name darf nicht leer sein.", nameof(name));
		if (schaden < 0) throw new ArgumentOutOfRangeException(nameof(schaden), "Schaden darf nicht negativ sein.");

		Name = name;
		Schaden = schaden;
	}

	public string BeschreibeDich() => $"Ich bin {Name} und mache {Schaden} Schaden.";
}

public class Heiltrank : IInventarGegenstand
{
	public string Name { get; }
	public int Heilwert { get; }

	public Heiltrank(string name, int heilwert)
	{
		if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name darf nicht leer sein.", nameof(name));
		if (heilwert < 0) throw new ArgumentOutOfRangeException(nameof(heilwert), "Heilwert darf nicht negativ sein.");

		Name = name;
		Heilwert = heilwert;
	}

	public string BeschreibeDich() => $"Ich bin {Name} und heile {Heilwert} HP.";
}

class Program
{
	static void Main()
	{
		var inventar = new List<IInventarGegenstand>
		{
			new Waffe("Schwert", 15),
			new Heiltrank("Kleiner Heiltrank", 25)
		};

		foreach (IInventarGegenstand gegenstand in inventar)
		{
			Console.WriteLine(gegenstand.BeschreibeDich());
		}
	}
}
