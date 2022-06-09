using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WorkerService1.Service;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ITaskService taskService;
        public Worker(ILogger<Worker> logger, ITaskService taskService)
        {
            this._logger = logger;
            this.taskService = taskService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {    
                GetTask();
                await Task.Delay(60000, stoppingToken);
            }
        }
        private async void GetTask()
        {
            //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            var fechaActual = DateTime.Now;
            var DayOfWeek = DateTime.Now.DayOfWeek;
            var horaActual = DateTime.Now.Hour;
            var minutoActual = DateTime.Now.Minute;

            if(DayOfWeek == DayOfWeek.Friday && horaActual== 3 && minutoActual == 1) 
            {
                MoveFile();
            }


            var ElementList = await taskService.TaskWorking(fechaActual, horaActual, minutoActual);

            foreach (var Element in ElementList)
            {
               
                using (HttpClient cliente = new HttpClient())
                {

                    var response = await cliente.GetAsync(Element.Url);

                    if (response.IsSuccessStatusCode)
                    {

                        _logger.LogInformation($"Se Realizó Tarea Trama");
                    }
                    else
                    {
                        _logger.LogInformation($"Error al consumir web api. {response.StatusCode}");
                    }
                }
            }           
        }


        // logica de Angel

        private void MoveFile() 
        {
            string sourceFilePath = @"C:\2019\Sample.txt";
            string destinationFilePath = @"C:\2020\Sample.txt";
            System.IO.File.Copy(sourceFilePath, destinationFilePath);
            return;
        }
      
    }
}
