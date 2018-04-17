using Contacts_upstack.Models;
using System.Collections.Generic;
using System.Linq;

namespace Contacts_upstack.Data
{
    public class DbInitializer
    {
        public static void Init(ContactsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Persons.Any())
            {
                return;
            }

            var persons = new List<Person>
            {
                new Person {FirstName = "Adam", LastName = "Levine", Phone = "23452627"},
                new Person {FirstName = "David", LastName = "Copperfield", Phone = "2345237627"},
                new Person {FirstName = "Jessica", LastName = "Jones", Phone = "1234567890"},
                new Person {FirstName = "Bruce", LastName = "Wayne", Phone = "1234567890"},
                new Person {FirstName = "Peter", LastName = "Parker", Phone = "658765872"},
                new Person {FirstName = "David", LastName = "Beckham", Phone = "2346734734"},
                new Person {FirstName = "Lionel", LastName = "Messi", Phone = "5687345624"},
                new Person {FirstName = "Cristiano", LastName = "Ronaldo", Phone = "234523425362"},
                new Person {FirstName = "Artur", LastName = "Borubar", Phone = "12341235134645"},
                new Person {FirstName = "LeBron", LastName = "James", Phone = "1234623475"}
            };


            context.Persons.AddRange(persons);

            context.SaveChanges();
        }
    }
}