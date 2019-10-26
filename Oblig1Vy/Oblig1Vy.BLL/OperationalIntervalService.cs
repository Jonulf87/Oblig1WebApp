using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oblig1Vy.DAL;

namespace Oblig1Vy.BLL
{
    public class OperationalIntervalService
    {
        public OperationalIntervalVm GetOperationalInterval(int id)
        {
            var oisRepo = new OperationalIntervalRepository();
            var ois = oisRepo.GetOperationalInterval(id);

            return ois;
        }
        
        public List<OperationalIntervalVm> GetOperationalIntervals()
        {
            var oisRepo = new OperationalIntervalRepository();
            var oisList = oisRepo.GetOperationalIntervals();

            return oisList;
        }

        public void UpdateOperationalInterval(OperationalIntervalVm ois)
        {
            var oisRepo = new OperationalIntervalRepository();
            oisRepo.UpdateOperationalInterval(ois);
        }

        public int AddOis(OperationalIntervalVm ois)
        {
            var oisRepo = new OperationalIntervalRepository();
            var oisId = oisRepo.AddOis(ois);

            return oisId;
        }

        public void DeleteOis(int id)
        {
            var oisRepo = new OperationalIntervalRepository();
            oisRepo.DeleteOis(id);
        }
    }
}
