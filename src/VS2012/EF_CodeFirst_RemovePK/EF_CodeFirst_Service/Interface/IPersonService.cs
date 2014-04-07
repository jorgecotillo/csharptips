using EF_CodeFirst_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_Service.Interface
{
    public interface IPersonService
    {
        IList<Person> GetAllPersons();
        void InsertPerson(Person person);
    }
}
