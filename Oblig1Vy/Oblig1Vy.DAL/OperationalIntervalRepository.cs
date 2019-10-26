using Oblig1Vy.DAL.Models;
using Oblig1Vy.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.DAL
{
    public class OperationalIntervalRepository : IOperationalIntervalRepository
    {
        public OperationalIntervalVm GetOperationalInterval(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var ois = db.OperationalIntervals.Where(a => a.Id == id).Select(a => new OperationalIntervalVm
                {
                    Id = a.Id,
                    Name = a.Name,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    Monday = a.Monday,
                    Tuesday = a.Tuesday,
                    Wednesday = a.Wednesday,
                    Thursday = a.Thursday,
                    Friday = a.Friday,
                    Saturday = a.Saturday,
                    Sunday = a.Sunday
                }).FirstOrDefault();

                return ois;
            }
        }
        public List<OperationalIntervalVm> GetOperationalIntervals()
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var ois = db.OperationalIntervals.Select(a => new OperationalIntervalVm
                {
                    Id = a.Id,
                    Name = a.Name,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    Monday = a.Monday,
                    Tuesday = a.Tuesday,
                    Wednesday = a.Wednesday,
                    Thursday = a.Thursday,
                    Friday = a.Friday,
                    Saturday = a.Saturday,
                    Sunday = a.Sunday
                }).ToList();

                return ois;
            }
        }


        public void UpdateOperationalInterval(OperationalIntervalVm ois)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var oisDb = db.OperationalIntervals.Where(a => a.Id == ois.Id).FirstOrDefault();

                oisDb.Name = ois.Name;
                oisDb.StartDate = ois.StartDate;
                oisDb.EndDate = ois.EndDate;
                oisDb.Monday = ois.Monday;
                oisDb.Tuesday = ois.Tuesday;
                oisDb.Wednesday = ois.Wednesday;
                oisDb.Thursday = ois.Thursday;
                oisDb.Friday = ois.Friday;
                oisDb.Saturday = ois.Saturday;
                oisDb.Sunday = ois.Sunday;

                db.SaveChanges();
            }
        }

        public int AddOis(OperationalIntervalVm oisVm)
        {
            var ois = new OperationalInterval
            {
                Name = oisVm.Name,
                StartDate = oisVm.StartDate,
                EndDate = oisVm.EndDate,
                Monday = oisVm.Monday,
                Tuesday = oisVm.Tuesday,
                Wednesday = oisVm.Wednesday,
                Thursday = oisVm.Thursday,
                Friday = oisVm.Friday,
                Saturday = oisVm.Saturday,
                Sunday = oisVm.Sunday
            };

            using (Oblig1Context db = new Oblig1Context())
            {
                db.OperationalIntervals.Add(ois);
                db.SaveChanges();
            }

            return ois.Id;
        }

        public void DeleteOis(int id)
        {
            using (Oblig1Context db = new Oblig1Context())
            {
                var oisRemove = db.OperationalIntervals.FirstOrDefault(a => a.Id == id);
                db.OperationalIntervals.Remove(oisRemove);
                db.SaveChanges();
            }
        }
    }
}
