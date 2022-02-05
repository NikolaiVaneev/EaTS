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
            OnRepair,
            [Description("Направлено в ОМР")]
            Repaired,
            [Description("Принято из ОМР")]
            NotRepairable,
            [Description("Передано в учреждение")]
            TechnicalConclusion
        }
    }
}
