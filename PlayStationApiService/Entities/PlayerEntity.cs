using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStationApi.Entities
{
    public class PlayerEntity: BaseEntity
    {
        /// <summary>
        /// Player name
        /// </summary>
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Team name
        /// </summary>
        [Required]
        [StringLength(100)]
        [MinLength(2)]
        public string TeamName {  get; set; } = String.Empty;
    }
}