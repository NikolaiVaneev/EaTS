using System.Collections.Generic;

namespace EaTS.Models
{
    /// <summary>
    /// Тип учреждения
    /// </summary>
    public class AgencyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        /// <summary>
        /// Учреждения
        /// </summary>
        public virtual ICollection<Agency> Agencies { get; set; }

    }
}
