using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public interface ITripRepository
    {
        int AddTrip(TripVm tripVm, string userName);
        void DeleteTrip(int id, string userName);
        List<DepartureTimeVm> GetDepartureTimes(TravelSearchVm travelSearch);
        List<StationVm> GetStationsByName(string searchterm);
        TripVm GetTrip(int id);
        List<TripVm> GetTrips();
        void UpdateTrip(TripVm tripVm, string userName);
    }
}