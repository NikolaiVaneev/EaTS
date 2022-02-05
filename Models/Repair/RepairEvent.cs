using System;
using static EaTS.WC;

namespace EaTS.Models
{
    public class RepairEvent
    {
        public int Id { get; set; }
        public DateTime DateEvent { get; set; }
        public string Description { get; set; }
        public Repair Repair { get; set; }
        public RepairStatus Status { get; set; }
    }
}
