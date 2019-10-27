using Oblig1Vy.DAL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.BLL
{
    public class TripService : ITripService
    {
        private ITripRepository _repository;

        public TripService()
        {
            _repository = new TripRepository();
        }

        public TripService(TripRepository stub)
        {
            _repository = stub;
        }

        public List<DepartureTimeVm> GetDepartureTimes(TravelSearchVm travelSearch)
        {
            var tripRepository = _repository;

            var departureTimes = tripRepository.GetDepartureTimes(travelSearch);

            foreach (var departureTime in departureTimes)
            {
                var price = tripRepository.GetPrices(departureTime.TripId);

                var numberOfStops = departureTime.Stops.Count - 1;

                var totalPrice = price.BasePrice + numberOfStops * price.StopsPrice;

                departureTime.Price = totalPrice;
            }

            return departureTimes;
        }

        public List<StationVm> GetStationsByName(string searchterm)
        {
            var tripRepository = _repository;

            var stationNames = tripRepository.GetStationsByName(searchterm);

            return stationNames;
        }

        public TripVm GetTrip(int id)
        {
            var tripRepo = _repository;
            var trip = tripRepo.GetTrip(id);

            return trip;
        }

        public List<TripVm> GetTrips()
        {
            var tripRepo = _repository;
            var tripList = tripRepo.GetTrips();

            return tripList;
        }

        public void UpdateTrip(TripVm trip, string userName)
        {
            var tripRepo = _repository;
            tripRepo.UpdateTrip(trip, userName);
        }

        public int AddTrip(TripVm trip, string userName)
        {
            var tripRepo = _repository;
            var tripId = tripRepo.AddTrip(trip, userName);

            return tripId;
        }

        public void DeleteTrip(int id, string userName)
        {
            var tripRepo = _repository;
            tripRepo.DeleteTrip(id, userName);
        }

    }
}
