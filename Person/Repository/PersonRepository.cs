using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;

namespace Person.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonContext _dbContext;

        public PersonRepository(PersonContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person.Entity.Person>> GetAll()
        {
            return await _dbContext.Persons.ToListAsync();
        }

        public async Task<Person.Entity.Person> GetById(int id)
        {
            var existingPerson = await _dbContext.Persons.FindAsync(id);

            if (existingPerson != null)
            {
                return existingPerson;
            }
            else
            {
                throw new Exception("Person not found");
            }
        }

        public async Task<Person.Entity.Person> Add(Person.Entity.Person person)
        {
            // sirayla yazilmasinin sebebi tutarlilik.
            // Bu şekilde yazmak, veritabanına herhangi bir değişiklik yapmadan önce
            // tüm değişiklikleri tamamlamak için beklemek.
            // Böylece, veritabanındaki tutarlılığı sağlamak için işlemleri birleştirir ve
            // veritabanında aynı anda yapılan değişikliklerin çakışmasını engeller.

            // nesneyi bellekteki veritabanı bağlamına ekler
            await _dbContext.Persons.AddAsync(person);

            //değişiklikleri veritabanına kaydetmek için
            await _dbContext.SaveChangesAsync();

            return person;
        }

        public async Task<Entity.Person> Update(int id, Person.Entity.Person person)
        {
            var existingPerson = await _dbContext.Persons.FindAsync(id);

            if (existingPerson != null)
            {


                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.MiddleName = person.MiddleName;
                existingPerson.BirthDate = person.BirthDate;
                existingPerson.Gender = person.Gender;
                existingPerson.Location = person.Location;

                // Update metodu içinde, existingPerson nesnesinin yeniden oluşturulmasına gerek yok.
                // Zaten existingPerson örneği veritabanından getirildiği için,
                // içindeki özellikler otomatik olarak güncellenecektir. 
                //existingPerson = new Person.Entity.Person
                //{
                //    FirstName = person.FirstName,
                //    LastName = person.LastName,
                //    MiddleName = person.MiddleName,
                //    BirthDate = person.BirthDate,
                //    Gender = person.Gender,
                //    Location = person.Location
                //};

                // Entity Framework'e, mevcut kişinin güncellendiğini bildirir.
                _dbContext.Entry(existingPerson).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return existingPerson;
            }
            else
            {
                throw new Exception("Person not found");
            }
        }

        public async Task<int> Delete(int id)
        {
            var person = await _dbContext.Persons.FindAsync(id);

            if (person == null)
            {
                throw new Exception("Person not found");
            }

            _dbContext.Persons.Remove(person);
            await _dbContext.SaveChangesAsync();

            return id;
        }
    }
}
