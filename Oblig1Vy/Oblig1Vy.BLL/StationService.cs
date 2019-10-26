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
    public class StationService : IStationService
    {
        private IStationRepository _repository;
        
        public StationService()
        {
            _repository = new StationRepository();
        }

        public StationService(IStationRepository stub)
        {
            _repository = stub;
        }

        public StationVm GetStation(int id)
        {
            var stationRepo = _repository;
            var station = stationRepo.GetStation(id);

            return station;
        }
        public List<StationVm> GetStations()
        {
            var stationRepository = _repository;
            var stations = stationRepository.GetStations();

            return stations;

        }

        public void UpdateStation(StationVm station)
        {
            var stationRepo = _repository;
            stationRepo.UpdateStation(station);
        }

        public int AddStation(StationVm station)
        {
            var stationRepo = _repository;
            var stationId = stationRepo.AddStation(station);

            return stationId;
        }

        public void DeleteStation(int id)
        {
            var stationRepo = _repository;
            stationRepo.DeleteStation(id);
        }
    }
}
