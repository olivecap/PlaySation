namespace PlayStationApiService.Dtos.Player
{
    public class PlayerGetDto
    {
        /// <summary>
        /// GUID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Team name
        /// </summary>
        public string TeamName { get; set; } = string.Empty;

    }
}
