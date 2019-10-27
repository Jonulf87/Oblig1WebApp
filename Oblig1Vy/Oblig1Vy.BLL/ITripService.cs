using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public interface ITripService
    {
        int AddTrip(TripVm trip, string userName);
        void DeleteTrip(int id, string userName);
        List<DepartureTimeVm> GetDepartureTimes(TravelSearchVm travelSearch);
        List<StationVm> GetStationsByName(string searchterm);
        TripVm GetTrip(int id);
        List<TripVm> GetTrips();
        void UpdateTrip(TripVm trip, string userName);
        //PriceVm GetPrices(int id);
    }
}