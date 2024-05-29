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
            "Red",
            new DateTime(2024, 10, 2, 8, 0, 0)
        ),
        new (
            2,
            "Anna",
            "Tuz",
            "Garfield",
            32,
            "Blue",
            new DateTime(2024, 10, 2, 9, 0, 0)
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
                newVisit.CatColor,
                newVisit.VisitDate);

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

            if (updatedVisit.VisitDate.Hour < 8 || updatedVisit.VisitDate.Hour > 16)
                return Results.Content("Vet not working at this hour!");
            
            visits[index] = new VisitDTO(
                id,
                updatedVisit.ReserverName,
                updatedVisit.ReserverSurname,
                updatedVisit.CatName,
                updatedVisit.CatAgeInMonths,
                updatedVisit.CatColor,
                updatedVisit.VisitDate
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