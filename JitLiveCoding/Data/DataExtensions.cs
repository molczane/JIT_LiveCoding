using Microsoft.EntityFrameworkCore;

namespace JitLiveCoding.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<VisitsContext>();
        dbContext.Database.Migrate();
    }
}