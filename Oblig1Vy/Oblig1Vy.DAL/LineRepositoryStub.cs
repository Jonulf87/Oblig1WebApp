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
            var line = new LineVm
            {
                Id = 1,
                LineName = "Stavanger - Oslo",
                DepartureStationId = 0,
                ArrivalStationId = 9,
                DepartureStation = "Stavanger",
                ArrivalStation = "Oslo"
            };
            return line;
        }

        public List<LineVm> GetLines()
        {
            var LinesList = new List<LineVm>();
            var Lines = new LineVm
            {
                Id = 1,
                LineName = "Stavanger - Oslo",
                DepartureStationId = 0,
                ArrivalStationId = 9,
                DepartureStation = "Stavanger",
                ArrivalStation = "Oslo"
            };
            LinesList.Add(Lines);
            LinesList.Add(Lines);
            LinesList.Add(Lines);

            return LinesList;

        }

        public void UpdateLine(LineVm lineEdit)
        {

        }

        public int AddLine(LineVm newLine)
        {
            var line = new Line
            {
                LineName = "Oslo - Bergen",
                DepartureId = 9,
                ArrivalId = 18
            };

            return line.Id;
        }

        public void DeleteLine(int? id)
        {
            
        }
    }
}
