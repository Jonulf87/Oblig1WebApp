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
        public StationVm GetStation(int id)
        {
            var stationRepo = new StationRepository();
            var station = stationRepo.GetStation(id);

            return station;
        }
        public List<StationVm> GetStations()
        {
            var stationRepository = new StationRepository();
            var stations = stationRepository.GetStations();

            return stations;

        }

        public void UpdateStation(StationVm station)
        {
            var stationRepo = new StationRepository();
            stationRepo.UpdateStation(station);
        }

        public int AddStation(StationVm station)
        {
            var stationRepo = new StationRepository();
            var stationId = stationRepo.AddStation(station);

            return stationId;
        }

        public void DeleteStation(int? id)
        {
            var stationRepo = new StationRepository();
            stationRepo.DeleteStation(id.Value);
        }
    }
}
