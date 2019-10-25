using Oblig1Vy.DAL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.BLL
{
    public class LineService
    {
        public LineVm GetLine(int id)
        {
            var lineRepo = new LineRepository();
            var line = lineRepo.GetLine(id);

            return line;
        }

        public List<LineVm> getLines()
        {
            var lineRepo = new LineRepository();
            var lines = lineRepo.GetLines();

            return lines;
        }

        public void UpdateLine(LineVm line)
        {
            var lineRepo = new LineRepository();
            lineRepo.UpdateLine(line);
        }

        public int AddLine(LineVm line)
        {
            var lineRepo = new LineRepository();
            var lineId = lineRepo.AddLine(line);

            return lineId;
        }

        public void DeleteLine(int? id)
        {
            var lineRepo = new LineRepository();
            lineRepo.DeleteLine(id.Value);
        }
    }
}
