using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Data
{
    public class DataConnection : IDataConnection
    {
        private readonly IConfiguration config;

        public DataConnection(IConfiguration config)
        {
            this.config = config;
        }
        public IDbConnection GetConnection()
        {
            return new SqlConnection(config.GetConnectionString("defaultConnection"));
        }
    }
}
