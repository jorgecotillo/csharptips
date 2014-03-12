using System;
using System.Configuration;

namespace EF_CodeFirst_Data
{
    public partial class EFDataProviderManager
    {
        public IDataProvider LoadDataProvider()
        {

            var providerName = ConfigurationManager.AppSettings["providerName"];
            if (String.IsNullOrWhiteSpace(providerName))
                throw new Exception("Data settings not provided");
          
            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();
                case "sqlce":
                    return new SqlCeDataProvider();
                default:
                    throw new Exception(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
