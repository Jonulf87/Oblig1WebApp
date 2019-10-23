using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL;
using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public class StationService
    {
        public List<StationListVm> GetStations()
        {
            var stationRepository = new StationRepository();
            var stations = stationRepository.GetStations();

            return stations;

        }
    }
}
