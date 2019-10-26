using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public class StationRepositoryStub : IStationRepository
    {
        public StationVm GetStation(int id)
        {
                var station = new StationVm()
                {
                    StationId = 0,
                    StationName = "Stavanger",
                };
                return station;
        }
        public List<StationVm> GetStations()
        {
            var StationList = new List<StationVm>();
            var Stations = new StationVm()
            {
                StationId = 0,
                StationName = "Stavanger",
            };
            StationList.Add(Stations);
            StationList.Add(Stations);
            StationList.Add(Stations);
            return StationList;
        }

        public void UpdateStation(StationVm stationEdit)
        {
            
        }

        public int AddStation(StationVm stationVm)
        {
            var station = new Station
            {
                StationName = "Bergen",
                Id = 18,
            };

            return station.Id;
        }

        public void DeleteStation(int id)
        {
            
        }
    }
}