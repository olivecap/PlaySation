using System.ComponentModel.DataAnnotations;

namespace PlayStationApiService.Dtos.Player
{
    public class PlayerCreateDto
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; } = default!;

        /// <summary>
        /// Team name
        /// </summary>
        [Required]
        [StringLength(100)]
        [MinLength(2)]
        public string TeamName { get; set; } = default!;
    }
}
