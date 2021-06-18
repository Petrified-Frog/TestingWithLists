using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithLists
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
    }

    public static class People
    {
        public static List<Person> peopleList = new List<Person>();

        public static void AddPerson(Person newPerson)
        {
            //some validation
            if (newPerson.Age < 0)
                throw new ArgumentException("Age cannot be negative", "Age");
            if (string.IsNullOrWhiteSpace(newPerson.FirstName))
                throw new ArgumentException("Invalid first name", "FirstName");
            if (string.IsNullOrWhiteSpace(newPerson.LastName))
                throw new ArgumentException("Invalid last name", "LastName");

            peopleList.Add(newPerson);
        }

        public static List<Person> SortPeopleByAge(List<Person> people)
        {
            List<Person> orderedList =  people.OrderBy(o => o.Age).ToList();
            return orderedList;
        }

        public static List<Person> SortPeopleByLastName(List<Person> people)
        {
            List<Person> orderedList = people.OrderBy(o => o.LastName).ToList();
            return orderedList;
        }
    }
}
