using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1Vy.DAL.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public AuditType Type { get; set; }
        public string User { get; set; }
        public string Model { get; set; }
        public string Log { get; set; }
    }
    
    public enum AuditType
    {
        Created = 0,
        Updated = 1,
        Removed = 2
    }
}
