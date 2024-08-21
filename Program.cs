using System;
using System.Collections.Generic;
using System.IO;

namespace PeopleManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the path to the CSV file located in the CSVFiles folder
            string csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "CSVFiles", "data.csv");

            // Ensure the file exists
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine("The specified CSV file does not exist.");
                return;
            }

            // Parse CSV to list of people
            List<Person> people = CSVParser.ParseCsv(csvFilePath);

            // Generate reports
            PeopleReport report = new PeopleReport();
            report.SaveMales(people);
            report.SaveFemales(people);
            report.SaveDotComUsers(people);

            Console.WriteLine("Reports generated successfully.");
        }
    }
}
