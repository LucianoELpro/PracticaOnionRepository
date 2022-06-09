using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Models;
using WorkerService1.Data;

namespace WorkerService1.Service
{
    public class TaskService : ITaskService
    {
        private readonly IDataConnection Dbconnection;

        public TaskService(IDataConnection dbconnection)
        {
            Dbconnection = dbconnection;
        }

        public async Task<List<TaskParameters>> TaskWorking(DateTime date, int hour, int minute)
        {
            var parameters = new { date, hour, minute };
            List<TaskParameters> resultado = new List<TaskParameters>();

            using (var connection = Dbconnection.GetConnection())
            {
                connection.Open();
                var list = await connection
                    .QueryAsync<TaskParameters>("SpLisTaskParameters", parameters,
                    commandType: CommandType.StoredProcedure);
                connection.Close();
                resultado = list.ToList();

            }
            return resultado;
        }

    }
}
