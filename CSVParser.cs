using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PeopleManagement
{
    public class CSVParser
    {
        public static List<Person> ParseCsv(string filePath)
        {
            var people = new List<Person>();

            using (var reader = new StreamReader(filePath))
            {
                // Read the header line
                var headers = reader.ReadLine()?.Split(',') ?? new string[0];

                // Check if the header line is correctly read
                if (headers.Length == 0)
                {
                    throw new InvalidDataException("CSV file is empty or incorrectly formatted.");
                }

                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine()?.Split(',');

                    if (values == null || values.Length != headers.Length) continue;

                    var person = new Person
                    {
                        Id = int.Parse(values[0], CultureInfo.InvariantCulture),
                        Name = $"{values[2]} {values[3]}", // Concatenate First Name and Last Name
                        Gender = values[4],
                        Age = CalculateAge(DateTime.Parse(values[7], CultureInfo.InvariantCulture)),
                        Email = values[5],
                        Phone = values[6]
                    };

                    people.Add(person);
                }
            }

            return people;
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
