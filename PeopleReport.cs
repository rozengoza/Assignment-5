using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PeopleManagement
{
    public class PeopleReport
    {
        public void SaveMales(List<Person> people)
        {
            var males = people.Where(p => p.Gender == "Male").ToList();
            WriteToCsv("males.csv", males);
        }

        public void SaveFemales(List<Person> people)
        {
            var adultFemales = people.Where(p => p.Gender == "Female" && p.Age >= 18).ToList();
            WriteToCsv("adultfemales.csv", adultFemales);
        }

        public void SaveDotComUsers(List<Person> people)
        {
            var dotComUsers = people
                .Where(p => p.Email.EndsWith("@example.com"))
                .Select(p => new { p.Id, p.Email, p.Phone })
                .ToList();

            WriteToCsv("dotcomusers.csv", dotComUsers);
        }

        private void WriteToCsv<T>(string filePath, IEnumerable<T> records)
        {
            using (var writer = new StreamWriter(filePath))
            {
                var properties = typeof(T).GetProperties();

                // Write header
                writer.WriteLine(string.Join(",", properties.Select(p => p.Name)));

                // Write records
                foreach (var record in records)
                {
                    var values = properties.Select(p => p.GetValue(record)?.ToString() ?? string.Empty);
                    writer.WriteLine(string.Join(",", values));
                }
            }
        }
    }
}
