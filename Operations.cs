/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement
{
    internal class Operations
    {
        static async Task<List<Person>> ReadFileAsync()
        {
            string filePath = @"C:\Users\shrestha.rozen\Desktop\assignment-5\PeopleManagement\PeopleManagement\CSVFiles\People.csv";
            var fileContent = await File.ReadAllTextAsync(filePath);
            var eachLineOfCSV = fileContent.Split(["\n", "\r"], StringSplitOptions.RemoveEmptyEntries);
            var people = new List<Person>();
            foreach ( var person in eachLineOfCSV.Skip(1))
                {
                var personDataSplitted = person.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var index = int.Parse(personDataSplitted[0]);
                var userId = personDataSplitted[1];
                var firstName = personDataSplitted[2];
                var lastName = personDataSplitted[3];
                var sex = personDataSplitted[4];
                var email = personDataSplitted[5];
                var phoneNumber = personDataSplitted[6];
                DateTime.TryParse(personDataSplitted[7], out DateTime dateOfBirth);
                var dob = dateOfBirth;
                var jobTitle = personDataSplitted[8];
                var eachPerson = new Person(index, userId, fileContent, firstName, lastName, sex, email, dob, jobTitle);
                people.Add(eachPerson);
            }
            return people; 
        }

         
    }
}
*/