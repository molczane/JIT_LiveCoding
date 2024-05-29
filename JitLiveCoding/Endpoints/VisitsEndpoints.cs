using JitLiveCoding.DTOs;

namespace JitLiveCoding.Endpoints;

public static class VisitsEndpoints
{
    const string GetVisitEndpointName = "GetVisit";
    
    private static readonly List<VisitDTO> visits = [
        new (
            1,
            "Anna",
            "Monk",
            "Fred",
            30,
            "Red"
        ),
        new (
            1,
            "Anna",
            "Tuz",
            "Garfield",
            32,
            "Blue"
        )
    ];
    
    public static RouteGroupBuilder MapVisitsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("visits")
            .WithParameterValidation(); // USED NUGET PACKAGE
        
        // GET /games
        group.MapGet("/", () => visits);

        // GET /games/{id}
        group.MapGet("/{id}", (int id) =>
            {
                VisitDTO? game =  visits.Find(visit => visit.ID == id);

                return game is null ? Results.NotFound() : Results.Ok(game);
            })
            .WithName(GetVisitEndpointName);

        // POST /games
        group.MapPost("/", (CreateVisitDTO newVisit) =>
        {
            VisitDTO visit = new VisitDTO(
                visits.Count + 1,
                newVisit.ReserverName,
                newVisit.ReserverSurname,
                newVisit.CatName,
                newVisit.CatAgeInMonths,
                newVisit.CatColor);

            visits.Add(visit);

            return Results.CreatedAtRoute(GetVisitEndpointName, new { id = visit.ID }, visit);
        });

        // PUT /games/{id}
        group.MapPut("/{id}", (int id, UpdateVisitDTO updatedVisit) =>
        {
            var index = visits.FindIndex(visit => visit.ID == id);

            if (index == -1)
            {
                return Results.NotFound();
            }
    
            visits[index] = new VisitDTO(
                id,
                updatedVisit.ReserverName,
                updatedVisit.ReserverSurname,
                updatedVisit.CatName,
                updatedVisit.CatAgeInMonths,
                updatedVisit.CatColor
            );

            return Results.NoContent();
        });

        // DELETE /games/{id}
        group.MapDelete("/{id}", (int id) =>
        {
            visits.RemoveAll(game => game.ID == id);

            return Results.NoContent();
        });

        return group;
    }
}