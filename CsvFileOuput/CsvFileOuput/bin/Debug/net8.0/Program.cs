using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Path to CSV file
        string filePath = "persons.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found: " + filePath);
            return;
        }

        // Ensure UTF-8 output so special characters display correctly
        Console.OutputEncoding = Encoding.UTF8;

        using (var reader = new StreamReader(filePath, Encoding.UTF8))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line == null) continue;

                // Split by semicolon
                string[] fields = line.Split(';');

                // Print fields separated by tabs for clean alignment
                foreach (string field in fields)
                {
                    Console.Write(field.Trim() + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
