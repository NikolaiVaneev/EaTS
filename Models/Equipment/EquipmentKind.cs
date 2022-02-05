namespace EaTS.Models
{
    /// <summary>
    /// Оборудование (Арбалет, Микрос, Внутренняя камера...)
    /// </summary>
    public class EquipmentKind
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Средняя стоимость
        /// </summary>
        public int? Price { get; set; }
        /// <summary>
        /// Устаревшее
        /// </summary>
        public bool IsObsolete { get; set; }
        /// <summary>
        /// Класс оборудования
        /// </summary>
        public virtual EquipmentClass EquipmentClass { get; set; }
        
    }
}