using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Person
    {
        public string Name { get; set; }
        public List<string> PhoneNumbers { get; set; }
    }
    public class PersonPhoneNumbers
    {
        /// <summary>
        /// Returns all phone numbers.
        /// </summary>
        public static void GetPhoneNumbers()
        {
            IEnumerable<Person> people = new List<Person>()
            {
                new Person() {Name = "Bob", PhoneNumbers = new List<string>() {"123", "456"}},
                new Person() {Name = "John", PhoneNumbers = new List<string>() {"789", "453"}},
                new Person() {Name = "Jeff", PhoneNumbers = new List<string>() {"879", "146"}},
                new Person() {Name = "Jon", PhoneNumbers = new List<string>() {"765", "481"}},
                new Person() {Name = "Buster", PhoneNumbers = new List<string>() {"294", "090"}},
            };

            //TODO
            // Return list of all phone numbers.

        }
    }
}
