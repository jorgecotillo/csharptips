using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_Data.Interfaces
{
    public interface IODSDbContext
    {
        /// <summary>
        /// Execute stores procedure and load a list of entities at the end
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="commandText">Command text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entities</returns>
        T ExecuteStoredProcedureSingleResult<T>(string commandText, params object[] parameters);
        object[] ExecuteStoredProcedureMultipleResult(string commandText, params object[] parameters);
    }
}
