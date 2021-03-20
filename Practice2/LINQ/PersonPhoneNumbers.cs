using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQ
{
    public class Person
    {
        public string Name { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public int Age { get; set; }
    }
    public class PersonPhoneNumbers
    {
        /// <summary>
        /// Returns all phone numbers.
        /// </summary>
        public static IEnumerable<string> GetPhoneNumbers()
        {
            IEnumerable<Person> people = new List<Person>()
            {
                new Person() {Age = 15, Name = "Bob", PhoneNumbers = new List<string>() {"123", "456"}},
                new Person() {Age = 13, Name = "John", PhoneNumbers = new List<string>() {"789", "453"}},
                new Person() {Age = 18, Name = "Jeff", PhoneNumbers = new List<string>() {"879", "146"}},
                new Person() {Age = 17, Name = "Jon", PhoneNumbers = new List<string>() {"765", "481"}},
                new Person() {Age = 16, Name = "Buster", PhoneNumbers = new List<string>() {"294", "090"}},
            };

            // Return list of all phone numbers.
            List<string> phoneNumbers = new List<string>();
            foreach (Person person in people)
            {
                foreach (var phoneNumber in person.PhoneNumbers)
                {
                    phoneNumbers.Add(phoneNumber);
                }
            }

            //var numbers = people.Select(p => p.PhoneNumbers);
            var numbers = people.SelectMany(p => p.PhoneNumbers);
            var names = people.SelectMany(p => p.Name);
            var age = people.Select(p => p.Age);
            //var age = people.Select(p => p.Age + " " + p.Name);
            var ageAndName = people.Select(p => new { A = p.Age, N = p.Name });

            var avg = ageAndName.Average(x => x.A);
            foreach (var item in ageAndName)
            {
                Console.WriteLine(item.A + " " + item.N);
            }
            return numbers;  // IEnumerable<string>   IEnumerable<List<string>>
        }
    }
}
