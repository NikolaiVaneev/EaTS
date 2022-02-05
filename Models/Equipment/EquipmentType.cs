using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EaTS.Models
{
    /// <summary>
    /// Тип оборудования (ОИ, Видеонаблюдение, Досмотровое)
    /// </summary>
    public class EquipmentType
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Наименование типа")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        /// <summary>
        /// Наименование типа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Классы типа
        /// </summary>
        public virtual ICollection<EquipmentClass> Classes { get; set; }

        public int DisplayOrder { get; set; }
    }
}
