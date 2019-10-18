using Oblig1Vy.DAL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.BLL
{
    public class TripService
    {
        public List<DepartureTimeVm> GetDepartureTimes(TravelSearchVm travelSearch)
        {
            var tripRepository = new TripRepository();

            var departureTimes = tripRepository.GetDepartureTimes(travelSearch);

            //foreach (var departureTime in departureTimes)
            //{
            //    var price = 50 + (departureTime.Stops.Count * 15);
            //    //calculate price based on departureTime.Stops
            //}

            return departureTimes;
        }

        public List<StationVm> GetStationsByName(string searchterm)
        {
            var tripRepository = new TripRepository();

            var stationNames = tripRepository.GetStationsByName(searchterm);

            return stationNames;
        }
        
    }
}
