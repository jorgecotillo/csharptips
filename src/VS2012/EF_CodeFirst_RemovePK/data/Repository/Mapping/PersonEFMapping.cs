using EF_CodeFirst_Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CodeFirst_Data.Repository.Mapping
{
    public class PersonEFMapping : EntityTypeConfiguration<Person>
    {
        public PersonEFMapping()
        {
            this.ToTable("Person");
            this.HasKey(p => p.Id);
            
            //Uncomment this line in case you want to remove Identity setting to the PK.

            //this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            this.Property(p => p.FirstName).HasMaxLength(20);
        }
    }
}
