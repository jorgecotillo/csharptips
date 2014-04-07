using EF_CodeFirst_Data.Initializer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace EF_CodeFirst_Data
{
    public class SqlCeDataProvider : BaseEFDataProvider
    {
        /// <summary>
        /// Get connection factory
        /// </summary>
        /// <returns>Connection factory</returns>
        public override IDbConnectionFactory GetConnectionFactory()
        {
            return new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        }

        /// <summary>
        /// Set database initializer
        /// </summary>
        public override void SetDatabaseInitializer()
        {
            //var initializer = new CreateDatabaseIfNotExists<NopObjectContext>();
            var initializer = new CreateCeDatabaseIfNotExists<EFCustomContext>();
            Database.SetInitializer(initializer);
        }

        /// <summary>
        /// A value indicating whether this data provider supports stored procedures
        /// </summary>
        public override bool StoredProceduredSupported
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a support database parameter object (used by stored procedures)
        /// </summary>
        /// <returns>Parameter</returns>
        public override DbParameter GetParameter()
        {
            return new SqlParameter();
        }
    }
}
