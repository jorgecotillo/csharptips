using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_Entity
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
