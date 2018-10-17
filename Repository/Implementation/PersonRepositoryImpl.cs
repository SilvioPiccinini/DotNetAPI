using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DotNetAPI.Model;
using DotNetAPI.Model.Context;

namespace DotNetAPI.Repository.Implementation
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySqlContext context;

        public PersonRepositoryImpl(MySqlContext context)
        {
            this.context = context;
        }

        public List<Person> FindAll()
        {
            return context.People.ToList();
        }

        public Person FindById(long id)
        {
            return context.People.SingleOrDefault(x => x.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try{
                context.People.Add(person);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if(!Exist(person)) return null;

            var result = context.People.SingleOrDefault(x => x.Id.Equals(person.Id));
            try{
                context.Entry(result).CurrentValues.SetValues(person);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = context.People.SingleOrDefault(x => x.Id.Equals(id));
            try{
                if(result != null)
                {
                    context.People.Remove(result);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public bool Exist(Person person)
        {
            return context.People.Any(x => x.Id.Equals(person.Id));
        }
    }
}