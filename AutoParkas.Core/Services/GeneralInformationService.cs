using AutoParkas.Core.Models;
using AutoParkas.Core.Utils;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkas.Core.Services
{
    public class GeneralInformationService
    {
        private AppDatabaseContext _dbContext;
        public GeneralInformationService(AppDatabaseContext databaseContext)
        {
            _dbContext = databaseContext;
            ObjektuDuomenuBazejeKiekioTikrinimas();
        }
        private async Task ObjektuDuomenuBazejeKiekioTikrinimas()
        {
            while(true)
            {
                int autoKiekis = _dbContext.Automobiliai.Count();
                int klientuKiekis = _dbContext.Automobiliai.Count();
                Log.Information($"Klientu kiekis {klientuKiekis} Automobiliu kiekis {autoKiekis}");
                await Task.Delay(10000);
            }
            
        }
    }
}
