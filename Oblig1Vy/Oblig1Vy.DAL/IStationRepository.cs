using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public interface IStationRepository
    {
        int AddStation(StationVm stationVm);
        void DeleteStation(int? id);
        StationVm GetStation(int id);
        List<StationVm> GetStations();
        void UpdateStation(StationVm stationEdit);
    }
}