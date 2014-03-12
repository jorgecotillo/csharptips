using EF_CodeFirst_Data;
using EF_CodeFirst_Data.Repository;
using EF_CodeFirst_Entity;
using EF_CodeFirst_Service.Impl;
using EF_CodeFirst_Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_RemovePK
{
    class Program
    {        
        static void Main(string[] args)
        {            
            //Create Compact Edition DB
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            EFCustomContext context = new EFCustomContext(GetTestDbName());
            context.Database.Delete();
            context.Database.Create();

            //Inject dependencies
            IRepository<Person> personRepository = new EFRepository<Person>(context);
            IPersonService personService = new PersonService(personRepository);

            //Insert a person
            personService.InsertPerson(new Person() { FirstName = "Jorge" });

            //Select the person and display it
            Console.WriteLine(personService.GetAllPersons().FirstOrDefault().FirstName);
            Console.ReadLine();
        }

        static string GetTestDbName()
        {
            string testDbName = "Data Source=" + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + @"\\Nop.Data.Tests.Db.sdf;Persist Security Info=False";
            return testDbName;
        } 
    }
}
