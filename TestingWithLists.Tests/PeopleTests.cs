using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingWithLists;
using Xunit;

namespace TestingWithLists.Tests
{
    public class PeopleTests
    {
        [Fact]
        public void AddPerson_ShouldIncreaseList()
        {
            Person newPerson = new Person { FirstName = "Bob", LastName = "Bobsson", Age = 15 };
            
            TestingWithLists.People.AddPerson(newPerson);
            Assert.True(TestingWithLists.People.peopleList.Count == 1);
            Assert.Contains<Person>(newPerson, TestingWithLists.People.peopleList);
        }

        [Theory]
        [InlineData("Bob", "", 14, "LastName")]
        [InlineData("  ", "Bobbson", 15, "FirstName")]
        [InlineData("Bob", "Bobsson", -15, "Age")]
        public void AddPerson_ShouldFailWhenPersonInvalid(string firstName, string lastName, int age, string badParam)
        {
            Person newPerson = new Person { FirstName = firstName, LastName = lastName, Age = age };
            
            Assert.Throws<ArgumentException>(badParam, () => TestingWithLists.People.AddPerson(newPerson));
        }

        [Fact]
        public void SortPeopleByAge_ShouldSortPeopeList()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person { FirstName = "Bob", LastName = "Bobsson", Age = 15 });
            people.Add(new Person { FirstName = "Ture", LastName = "Sventon", Age = 43 });
            people.Add(new Person { FirstName = "Hans", LastName = "Gretson", Age = 8 });

            List < Person > sortedList = new List<Person>();
            sortedList = TestingWithLists.People.SortPeopleByAge(people);

            Assert.Same(sortedList[0], people[2] );
        }

        [Fact]
        public void SortPeopleByLastName_ShouldSortPeopeList()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person { FirstName = "Bob", LastName = "Bobsson", Age = 15 });
            people.Add(new Person { FirstName = "Ture", LastName = "Sventon", Age = 43 });
            people.Add(new Person { FirstName = "Hans", LastName = "Gretson", Age = 8 });

            List<Person> sortedList = new List<Person>();
            sortedList = TestingWithLists.People.SortPeopleByLastName(people);

            Assert.Same(sortedList[0], people[0] );
        }

    }
}
