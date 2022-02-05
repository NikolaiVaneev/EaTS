using EaTS.Models;
using System.Collections.Generic;

namespace EaTS.ViewModels
{
    public class EquipmentKindViewModel
    {
        public EquipmentClass EquipmentClass { get; set; }
        public ICollection<EquipmentKind> Equipments { get; set; }
    }
}
