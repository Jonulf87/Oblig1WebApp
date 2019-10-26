using System.Collections.Generic;
using Oblig1Vy.Model.ViewModels;

namespace Oblig1Vy.DAL
{
    public interface IOperationalIntervalRepository
    {
        int AddOis(OperationalIntervalVm oisVm);
        void DeleteOis(int id);
        OperationalIntervalVm GetOperationalInterval(int id);
        List<OperationalIntervalVm> GetOperationalIntervals();
        void UpdateOperationalInterval(OperationalIntervalVm ois);
    }
}