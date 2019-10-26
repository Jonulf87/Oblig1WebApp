using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public interface ILineRepository
    {
        int AddLine(LineVm newLine);
        void DeleteLine(int? id);
        LineVm GetLine(int id);
        List<LineVm> GetLines();
        void UpdateLine(LineVm lineEdit);
    }
}