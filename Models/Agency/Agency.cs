namespace EaTS.Models
{
    public class Agency
    {
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Короткое наименование
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Тип учреждения
        /// </summary>
        public AgencyType AgencyType { get; set; }
        /// <summary>
        /// Позиция в списке
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
