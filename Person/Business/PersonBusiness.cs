using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Person.DTO;
using Person.Repository;

namespace Person.Business
{
    public class PersonBusiness : IPersonBusiness
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonBusiness(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<List<Person.DTO.PersonDto>> GetAll()
        {
            var persons = await _personRepository.GetAll();

            var personsDto = _mapper.Map<List<PersonDto>>(persons);

            //var personsDto = persons.Select(p => new Person.DTO.PersonDto
            //{
            //    Id = p.Id,
            //    LastName = p.LastName,
            //    MiddleName = p.MiddleName,
            //    FirstName = p.FirstName,
            //    BirthDate = p.BirthDate,
            //    Gender = p.Gender,
            //    Location = p.Location
            //}).ToList();

            return personsDto;
        }

        public async Task<PersonDto> GetById(int id)
        {
            var entityPerson = await _personRepository.GetById(id);

            var person = _mapper.Map<PersonDto>(entityPerson);

            return person;
        }

        public async Task<PersonDto> Add(PersonDto person)
        {
            // DTO to entity. DTO'daki veriler, entity nesnesine kopyalanıyor.
            var entityPerson = _mapper.Map<Person.Entity.Person>(person);

            var addedEntityPerson = await _personRepository.Add(entityPerson);

            // from entity to DTO
            var addedPersonDto = _mapper.Map<PersonDto>(addedEntityPerson);

            return addedPersonDto;
        }

        public async Task<PersonDto> Update(int id, PersonDto person)
        {
            var entityPerson = _mapper.Map<Person.Entity.Person>(person);

            var updatedEntityPerson = await _personRepository.Update(id, entityPerson);

            var updatedDtoPerson = _mapper.Map<PersonDto>(updatedEntityPerson);

            return updatedDtoPerson;
        }

        public async Task<int> Delete(int id)
        {
            var person = await _personRepository.Delete(id);

            return id;
        }
    }
}

