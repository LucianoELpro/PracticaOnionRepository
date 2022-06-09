using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.Models;

namespace WorkerService1.Service
{
    public interface ITaskService
    {
        public  Task<List<TaskParameters>> TaskWorking(DateTime date, int hour, int minute);

    }
}
