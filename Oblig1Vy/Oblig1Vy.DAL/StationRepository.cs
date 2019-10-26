using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public class StationRepository : IStationRepository
    {
        public StationVm GetStation(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var station = db.Stations.Where(a => a.Id == id).Select(a => new StationVm { StationId = a.Id, StationName = a.StationName }).FirstOrDefault();
                return station;
            }
        }
        public List<StationVm> GetStations()
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var stationsList = db.Stations.Select(a => new StationVm { StationId = a.Id, StationName = a.StationName }).ToList();

                return stationsList;
            }
        }

        public void UpdateStation(StationVm stationEdit)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var stationDb = db.Stations.Where(a => a.Id == stationEdit.StationId).FirstOrDefault();

                stationDb.StationName = stationEdit.StationName;
                db.SaveChanges();
            }
        }

        public int AddStation(StationVm stationVm)
        {
            var station = new Station
            {
                StationName = stationVm.StationName
            };

            using (Oblig1Context db = new Oblig1Context())
            {
                db.Stations.Add(station);
                db.SaveChanges();
            }

            return station.Id;
        }

        public void DeleteStation(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var stationRemove = db.Stations.FirstOrDefault(a => a.Id == id);
                db.Stations.Remove(stationRemove);
                db.SaveChanges();
            }
        }
    }
}
