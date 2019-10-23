using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public class StationRepository
    {
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
    }
}
