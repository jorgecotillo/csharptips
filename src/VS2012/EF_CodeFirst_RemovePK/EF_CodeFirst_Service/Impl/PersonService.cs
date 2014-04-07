using EF_CodeFirst_Data.Repository;
using EF_CodeFirst_Entity;
using EF_CodeFirst_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_Service.Impl
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        public PersonService(IRepository<Person> personRepository)
        {
            //I prefer to pass an interface to the service so that I can easily mock the concrete implementation and I can execute unit tests.
            //Also by doing this, I'm applying one of the S.O.L.I.D. principles which is S = Single Responsibility Principle (Each class is responsible for one action and the creation of instances won't be in the scope)
            _personRepository = personRepository;
        }

        public IList<Person> GetAllPersons()
        {
            try
            {
                return _personRepository.Table.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }            
        }

        public void InsertPerson(Person person)
        {
            try
            {
                //Do something with the person (i.e. Set LastUpdated value)
                person.LastUpdated = System.DateTime.Now;
                //Uncomment this line when you already removed the Identity from the PK Mapping (PersonEFMapping)
                //person.Id = new Random(10000).Next();
                _personRepository.Insert(person);
            }
            catch (Exception)
            {
                
                throw;
            }            
        }
    }
}
