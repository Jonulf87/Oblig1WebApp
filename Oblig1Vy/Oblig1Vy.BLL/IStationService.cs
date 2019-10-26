using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public interface IStationService
    {
        int AddStation(StationVm station);
        void DeleteStation(int id);
        StationVm GetStation(int id);
        List<StationVm> GetStations();
        void UpdateStation(StationVm station);
    }
}