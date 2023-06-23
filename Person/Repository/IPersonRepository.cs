using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Person.Repository
{
    public interface IPersonRepository
    {
        Task<List<Person.Entity.Person>> GetAll();
        Task<Person.Entity.Person> GetById(int id);
        Task<Person.Entity.Person> Add(Person.Entity.Person person);
        Task<Person.Entity.Person> Update(int id, Person.Entity.Person person);
        Task<int> Delete(int id);
    }
}

