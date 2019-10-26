using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.BLL
{
    public interface ILineService
    {
        int AddLine(LineVm line);
        void DeleteLine(int? id);
        LineVm GetLine(int id);
        List<LineVm> getLines();
        void UpdateLine(LineVm line);
    }
}