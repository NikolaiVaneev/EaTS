using System.Collections.Generic;

namespace EaTS.Models
{
    /// <summary>
    /// Класс оборудования (РВОИ, ТЭОИ, Видеокамеры, Видоерегистраторы...)
    /// </summary>
    public class EquipmentClass
    {
        public int Id { get; set; }
        /// <summary>
        /// Аббривиатура
        /// </summary>
        public string ShortName { get; set; } 
        /// <summary>
        /// Полное название типа
        /// </summary>
        public string FullName { get; set; } 
        /// <summary>
        /// Список оборудования
        /// </summary>
        public virtual ICollection<EquipmentKind> Equipments { get; set; }
        /// <summary>
        /// Ремонтируется?
        /// </summary>
        public bool IsRepair { get; set; }
        /// <summary>
        /// Тип класса оборудования
        /// </summary>
        public EquipmentType EqupmentType { get; set; }
        /// <summary>
        /// Позиция в списке
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}