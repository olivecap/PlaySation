using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayStationApi.Data;
using PlayStationApi.Entities;
using PlayStationApiService.Dtos.Player;
using PlayStationApiService.Mapping;

namespace PlayStationApiService.Endpoints
{
    /// <summary>
    /// Extends app to manage Players endpoint
    /// </summary>
    public static class PalyersEndpoint
    {
        //------------------------------
        // Csts
        //------------------------------
        const string GetPlayerEntryPointName = "GetPlayer";
        const string GetPlayerByIdEntryPointName = "GetPlayerById";


        //---------------------
        //  Extension class
        //---------------------
        /// <summary>
        /// Create an extension for the WebApplication
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static RouteGroupBuilder MapPlayersEndpoints(this WebApplication app)
        {
            // TODO Change post with list
            // TODO Return IActionResult
            //---------------------------------------------------------
            // Add group root to avaoid to add each time route (games)
            // Use group in each endpoint
            // Avoid to recall /games  in each endpoints
            // Add validation of inut
            //---------------------------------------------------------
            var routeGroup = app.MapGroup("/Api/V1/Players")
                                .WithParameterValidation();

            //-------------
            //- ENDPOINTS -
            //-------------
            #region Endpoints

            //----------------------------------
            //      GET ENDPOINT
            //----------------------------------
            // Get all games /games
            // Add db link using injection PlayStationDbContext dbContext
            routeGroup.MapGet("/", async (PlayStationDbContext dbContext) =>
            {
                var gameList = await dbContext.Players
                    // Allow to specify we also use gGenre table
                    // Select each game
                    .Select(player => player.ToPlayerGetDto())
                    // Optimization to avoid to track modification because one shot action
                    .AsNoTracking()
                    // ToListAsync allow to change in async mode
                    .ToListAsync();

                //Results.Ok(games);
                return Results.Ok(gameList);
            });

            //----------------------------------
            //      GET BY ID ENDPOINT
            //----------------------------------
            // Get games by id /get/{id}
            // Add db link using injection PlayStationDbContext dbContext
            routeGroup.MapGet("/{id:Guid}", async ([FromRoute] Guid id, PlayStationDbContext dbContext) =>
            {
                try
                {
                    // Get entity object
                    // Await and replace find by find async
                    PlayerEntity? playerEntity = await dbContext.Players.FindAsync(id);
                    if (playerEntity == null)
                        return Results.NotFound();

                    // Transform 
                    return playerEntity == null ? Results.NotFound() : Results.Ok(playerEntity.ToPlayerGetDto());
                }
                catch(Exception e)
                {
                    return Results.BadRequest();
                }
            })                
            .WithName(GetPlayerByIdEntryPointName);

            //----------------------------------
            //      POST ENDPOINT
            //----------------------------------
            // Post games (body = create game dto
            // Add db link using injection PlayStationDbContext dbContext
            routeGroup.MapPost("/", async ([FromBody] PlayerCreateDto newPlayerDto, PlayStationDbContext dbContext) =>
            {                
                // Generate playef entity
                PlayerEntity playerEntity = newPlayerDto.ToPlayerEntity();

                //----------------------------
                //  AWAIT ONLY ON SAVE
                //----------------------------
                // Add object i db
                dbContext.Players.Add(playerEntity);

                // Save DB
                await dbContext.SaveChangesAsync();

                // Return DTO
                return Results.CreatedAtRoute(
                    GetPlayerByIdEntryPointName,
                    new { id = playerEntity.Id },
                    playerEntity.ToPlayerGetDto()
                );
            });

            //----------------------------------
            //      PATCH ENDPOINT
            //----------------------------------
            // Pacth games (body = Update player dto
            // Add db link using injection PlayStationDbContext dbContext
            routeGroup.MapPatch("/{id:Guid}", async ([FromRoute] Guid id, [FromBody] PlayerUpdateDto updatePlayerDto, PlayStationDbContext dbContext) =>
            {
                PlayerEntity? playerEntity = await dbContext.Players.FindAsync(id);
                if (playerEntity == null)
                    return Results.NotFound();

                // Update entity
                // We need to lock entity
                dbContext.Entry(playerEntity)
                    .CurrentValues
                    .SetValues(updatePlayerDto.ToPlayerEntity(id));

                // Save DB
                await dbContext.SaveChangesAsync();

                return Results.Ok(playerEntity.ToPlayerUpdateDto());
            });

            //----------------------------------
            //      DELETE AL ENDPOINT
            //----------------------------------
            // Delete all games
            // Add db link using injection PlayStationDbContext dbContext
            routeGroup.MapDelete("/", async (PlayStationDbContext dbContext) =>
            {
                //Delete all object
                await dbContext.Players
                    .Where(player => player.Id.ToString().Length >= 0)
                    .ExecuteDeleteAsync();

                return Results.NoContent();
            });

            //----------------------------------
            //      DELETE ENDPOINT BY ID
            //----------------------------------
            // Delete games by id /delete/{id}
            // Add db link using injection PlayStationDbContext dbContext
            routeGroup.MapDelete("/{id:Guid}", async ([FromRoute] Guid id, PlayStationDbContext dbContext) =>
            {
                // Get entity object
                PlayerEntity? playerentity = await dbContext.Players.FindAsync(id);
                if (playerentity is null)
                    return Results.NotFound();

                // More optimized
                await dbContext.Players
                    .Where(player => player.Id == id)
                    .ExecuteDeleteAsync();

                return Results.NoContent();
            });

            #endregion

            // Return extension class
            return routeGroup;
        }
    }   
}
