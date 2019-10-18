﻿using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.DAL
{
    public class TicketRepository
    {
        public int AddTicket(TicketVm ticket)
        {
            var travelTicket = new Ticket
            {
                ArrivalStationId = ticket.ArrivalStationId,
                DepartureStationId = ticket.DepartureStationId,
                TripId = ticket.TripId,
                JourneyDate = ticket.Date
            };

            using (Oblig1Context db = new Oblig1Context())
            {
                db.Tickets.Add(travelTicket);
                db.SaveChanges();
            }

            return travelTicket.Id;
        }

        public TicketSummaryVm GetTicketSummary(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var ticket = db.Tickets.Find(id);

                var departureTime = ticket.Trip.Schedules.SingleOrDefault(a => a.StationId == ticket.DepartureStationId);

                return new TicketSummaryVm
                {
                    ArrivalStation = ticket.ArrivalStation.StationName,
                    DepartureStation = ticket.DepartureStation.StationName,
                    LineName = ticket.Trip.Line.LineName,
                    TicketDateAndTime = ticket.JourneyDate.Date.Add(departureTime.DepartureTime.Value)
                };
            }
        }
    }
}