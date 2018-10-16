using System;
using System.Collections.Generic;
using System.Threading;
using DotNetAPI.Model;
using DotNetAPI.Model.Context;

namespace DotNetAPI.Services.Mock
{
    public class PersonServiceMock : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }

            return people;
        }

        public Person FindById(long id)
        {
            //return context.People.SingleOrDefault(x => x.Id.Equals(id));
            return new Person()
            {
                Id = id,
                FirstName = "FirstName " + id,
                LastName = "LastName " + id,
                Address = "Address " + id,
                Gender = "Gender  " + id
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementedAndGet(),
                FirstName = "FirstName " + i,
                LastName = "LastName " + i,
                Address = "Address " + i,
                Gender = "Gender  " + i
            };
        }

        private long IncrementedAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}