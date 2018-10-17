using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DotNetAPI.Model;
using DotNetAPI.Model.Context;
using DotNetAPI.Repository;

namespace DotNetAPI.Business.Implementation
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository repository ;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            this.repository = repository;
        }

        public List<Person> FindAll()
        {
            return repository.FindAll();
        }

        public Person FindById(long id)
        {
            return repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return repository.Create(person);
        }

        public Person Update(Person person)
        {
            return repository.Update(person);
        }

        public void Delete(long id)
        {
            repository.Delete(id);
        }

    }
}