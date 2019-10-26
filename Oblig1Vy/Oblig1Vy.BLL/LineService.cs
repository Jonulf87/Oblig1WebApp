using Oblig1Vy.DAL;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.BLL
{
    public class LineService : ILineService
    {
        private ILineRepository _repository;

        public LineService()
        {
            _repository = new LineRepository();
        }

        public LineService(ILineRepository stub)
        {
            _repository = stub;
        }
        public LineVm GetLine(int id)
        {
            var lineRepo = _repository;
            var line = lineRepo.GetLine(id);

            return line;
        }

        public List<LineVm> getLines()
        {
            var lineRepo = _repository;
            var lines = lineRepo.GetLines();

            return lines;
        }

        public void UpdateLine(LineVm line)
        {
            var lineRepo = _repository;
            lineRepo.UpdateLine(line);
        }

        public int AddLine(LineVm line)
        {
            var lineRepo = _repository;
            var lineId = lineRepo.AddLine(line);

            return lineId;
        }

        public void DeleteLine(int? id)
        {
            var lineRepo = _repository;
            lineRepo.DeleteLine(id.Value);
        }
    }
}
