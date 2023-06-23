using System;
namespace Person.Business
{
    public interface IPersonBusiness
    {
        Task<List<Person.DTO.PersonDto>> GetAll();
        Task<Person.DTO.PersonDto> GetById(int id);
        Task<Person.DTO.PersonDto> Add(Person.DTO.PersonDto person);
        Task<Person.DTO.PersonDto> Update(int id, Person.DTO.PersonDto person);
        Task<int> Delete(int id);
    }
}