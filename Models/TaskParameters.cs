using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Models
{
    public class TaskParameters
    {
        public int idTask { get; set; }
        public DateTime StartTask { get; set; }
        public DateTime EndTask { get; set; }
        public string Url { get; set; }
        public string DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        
    }
}
