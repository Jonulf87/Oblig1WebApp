using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public class LineRepository
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
                    ArrivalStationId = a.ArrivalId
                }).FirstOrDefault();

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
                    ArrivalStationId = a.ArrivalId
                }).ToList();

                return linesList;
            }
        }
    }
}
