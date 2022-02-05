using System.ComponentModel;

namespace EaTS
{
    public static class WC
    {
        /// <summary>
        /// Состояние оборудования
        /// </summary>
        public enum EquipmentCondition
        {
            [Description("На ремонте")]
            OnRepair,
            [Description("Отремонтировано")]
            Repaired,
            [Description("Не подлежит ремонту")]
            NotRepairable,
            [Description("Подготовлено ТЗ")]
            TechnicalConclusion
        }
        /// <summary>
        /// Статус ремонта
        /// </summary>
        public enum RepairStatus
        {
            [Description("Поступило на ремонт")]
            ReceivedForRepair,
            [Description("Направлено в ОМР")]
            SendForDIR,
            [Description("Принято из ОМР")]
            TakenFromDIR,
            [Description("Передано в учреждение")]
            ReturnedToOwner
        }
    }
}
