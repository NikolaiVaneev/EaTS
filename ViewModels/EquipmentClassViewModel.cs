using EaTS.Models;
using System.Collections.Generic;

namespace EaTS.ViewModels
{
    public class EquipmentClassViewModel
    {
        public EquipmentType EquipmentType { get; set; }
        public ICollection<EquipmentClass> EquipmentClasses { get; set; }
    }
}
