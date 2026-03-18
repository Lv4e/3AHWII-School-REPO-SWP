using System;
using Bruch;

Console.WriteLine("Fraction Demo");
Console.WriteLine("=============");

// Test 1: Einfache Brüche
var f1 = new Fraction(1, 2);
var f2 = new Fraction(1, 3);
Console.WriteLine($"{f1} + {f2} = {f1 + f2}");

// Test 2: Parsing
var f3 = Fraction.Parse("1 1/2");
var f4 = Fraction.Parse("2/3");
Console.WriteLine($"{f3} + {f4} = {f3 + f4}");

// Test 3: Kürzen
var f5 = new Fraction(4, 8);
Console.WriteLine($"4/8 gekürzt = {f5}");
