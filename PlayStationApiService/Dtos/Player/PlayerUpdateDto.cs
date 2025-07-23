using System.ComponentModel.DataAnnotations;

namespace PlayStationApiService.Dtos.Player
{
    public class PlayerUpdateDto
    {
        /// <summary>
        /// GUID
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(50)][MinLength(2)] 
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Team name
        /// </summary>
        [Required]
        [StringLength(100)]
        [MinLength(2)]
        public string TeamName { get; set; } = string.Empty;
    }
}
