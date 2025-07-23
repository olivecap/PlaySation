using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayStationApi.Entities
{
    /// <summary>
    /// Base class to create playStation entity
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Generate unique identifier
        /// </summary>
        [Required]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity other)
                return false;
            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
