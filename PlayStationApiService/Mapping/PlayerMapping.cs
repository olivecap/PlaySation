using PlayStationApi.Entities;
using PlayStationApiService.Dtos.Player;

namespace PlayStationApiService.Mapping
{
    public static class PlayerMapping
    {
        //---------------------------------
        //- Mapping player entity to DTO
        //---------------------------------
        #region Mapping entity to DTO

        /// <summary>
        /// Convert PlayerEntity to PlayerGetDTO
        /// </summary>
        /// <param name="playerEntity"></param>
        /// <returns></returns>
        public static PlayerGetDto ToPlayerGetDto(this PlayerEntity playerEntity)
        {
            return new PlayerGetDto()
            { 
                // Map properties
                Id = playerEntity.Id,
                Name = playerEntity.Name,
                TeamName = playerEntity.TeamName
            };  
        }

        /// <summary>
        /// Convert PlayerEntity to PlayerUpdateDTO
        /// </summary>
        /// <param name="gameEntity"></param>
        /// <returns></returns>
        public static PlayerUpdateDto ToPlayerUpdateDto(this PlayerEntity playerEntity)
        {
            return new PlayerUpdateDto()
            {
                // Map properties
                Id = playerEntity.Id,
                Name = playerEntity.Name,
                TeamName = playerEntity.TeamName
            };
        }

        #endregion

        //--------------------------
        //- Mapping DTO to Entity
        //--------------------------
        #region Mapping DTO to Entity

        /// <summary>
        /// Extend 
        /// </summary>
        /// <param name="createGameDto"></param>
        /// <returns></returns>
        public static PlayerEntity ToPlayerEntity(this PlayerCreateDto playerCreateDto)
        {
            // Create Game entity
            return new PlayerEntity()
            {
                // Without table link
                Name = playerCreateDto.Name,
                TeamName = playerCreateDto.TeamName
            };
        }

        /// <summary>
        /// Extend 
        /// </summary>
        /// <param name="createGameDto"></param>
        /// <returns></returns>
        public static PlayerEntity ToPlayerEntity(this PlayerUpdateDto playerUpdateDto, Guid id)
        {
            // Create Game entity
            return new PlayerEntity()
            {
                // Without table link
                Id = id,
                Name = playerUpdateDto.Name,
                TeamName = playerUpdateDto.TeamName
            };
        }

        #endregion
    }
}
