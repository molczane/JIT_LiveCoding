using JitLiveCoding.Entities;
using Microsoft.EntityFrameworkCore;

namespace JitLiveCoding.Data;

public class VisitsContext(DbContextOptions<VisitsContext> options) 
    : DbContext(options)
{
    public DbSet<Visit> Games => Set<Visit>();
}