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
        static int Main(string[] args)
        {
            try
            {
                var providerName = string.Empty;
                var connectionString = string.Empty;
                //Getting the type of SQL Server instance ("sqlserver" "sqlce")
                if (args.Length > 0)
                {
                    providerName = args[0];
                    if (providerName.Contains("sqlce"))
                        connectionString = GetCETestDbName();
                    else
                        connectionString = GetSQLTestDbName();
                }
                else
                {
                    Console.WriteLine("Please, specify a SQL Server instance (sqlserver or sqlce)");
                    Console.ReadLine();
                    return -1;
                }
                //Initializing variables
                var dataProviderManager = new EFDataProviderManager();
                var dataProvider = (IEFDataProvider)dataProviderManager.LoadDataProvider(providerName);

                //Creates DB Connection Factory - Depending on the SQL Server instance this factory can be: SqlCeConnectionFactory or SqlConnectionFactory 
                dataProvider.InitConnectionFactory();
                
                //Creates the EF Context based on the connection string
                EFCustomContext context = new EFCustomContext(connectionString);

                //Verifies if the DB exists so that we can remove it and then create the tables
                if (context.Database.Exists())
                {
                    Console.WriteLine("Do you want to remove the existing DB? (Y/N) \nBy removing the DB you will autogenerate your new tables, if aplicable.");
                    if (Console.ReadKey(false).Key == ConsoleKey.Y)
                    {                        
                        context.Database.Delete();
                        dataProvider.InitDatabase();
                        context.Database.Create();
                    }
                    //If the user says No to the question, then we won't create the DB
                }
                else
                    context.Database.Create();

                //Inject dependencies
                IRepository<Person> personRepository = new EFRepository<Person>(context);
                IPersonService personService = new PersonService(personRepository);

                //Insert a person
                personService.InsertPerson(new Person() { FirstName = "Jorge" });

                //Select the person and display it
                Console.WriteLine("\n\nResult from DB Query:\n\n" + personService.GetAllPersons().FirstOrDefault().FirstName);
                Console.ReadLine();
                return 1;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
                return -1;
            }
        }

        static string GetCETestDbName()
        {
            string testDbName = "Data Source=" + (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + @"\\Nop.Data.Tests.Db.sdf;Persist Security Info=False";
            return testDbName;
        }

        static string GetSQLTestDbName()
        {
            return @"Data Source=.\SQLEXPRESS; Initial Catalog=nopTest2;Integrated Security=True;Persist Security Info=False;MultipleActiveResultSets=True";
        }
    }
}
