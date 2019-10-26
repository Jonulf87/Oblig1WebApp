using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public class LineRepositoryStub : ILineRepository
    {
        public LineVm GetLine(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var line = db.Lines.Where(a => a.Id == id).Select(a => new LineVm
                {
                    Id = a.Id,
                    LineName = a.LineName,
                    DepartureStationId = a.DepartureId,
                    ArrivalStationId = a.ArrivalId,
                    DepartureStation = a.Departure.StationName,
                    ArrivalStation = a.Arrival.StationName


                }).SingleOrDefault();

                return line;
            }
        }

        public List<LineVm> GetLines()
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var linesList = db.Lines.Select(a => new LineVm
                {
                    Id = a.Id,
                    LineName = a.LineName,
                    DepartureStationId = a.DepartureId,
                    ArrivalStationId = a.ArrivalId,
                    DepartureStation = a.Departure.StationName,
                    ArrivalStation = a.Arrival.StationName
                }).ToList();

                return linesList;
            }

        }

        public void UpdateLine(LineVm lineEdit)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var lineDb = db.Lines.Where(a => a.Id == lineEdit.Id).SingleOrDefault();

                lineDb.LineName = lineEdit.LineName;
                lineDb.DepartureId = lineEdit.DepartureStationId;
                lineDb.ArrivalId = lineEdit.ArrivalStationId;

                db.SaveChanges();
            }
        }

        public int AddLine(LineVm newLine)
        {
            var line = new Line
            {
                LineName = newLine.LineName,
                DepartureId = newLine.DepartureStationId,
                ArrivalId = newLine.ArrivalStationId
            };

            using (Oblig1Context db = new Oblig1Context())
            {
                db.Lines.Add(line);
                db.SaveChanges();
            }

            return line.Id;
        }

        public void DeleteLine(int? id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var lineRemove = db.Lines.SingleOrDefault(a => a.Id == id.Value);
                db.Lines.Remove(lineRemove);
                db.SaveChanges();
            }
        }
    }
}
