namespace JitLiveCoding.Entities;

public class Visit
{
    public int ID { get; set; }
    public required string ReserverName { get; set; }
    public required string ReserverSurname { get; set; }
    public required string CatName { get; set; }
    public required int CatAgeInMonths { get; set; }
    public required string CatColor { get; set; }
    public required DateTime VisitDate { get; set; }
}