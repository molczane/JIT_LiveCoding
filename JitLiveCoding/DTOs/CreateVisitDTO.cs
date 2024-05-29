namespace JitLiveCoding.DTOs;

public record CreateVisitDTO(
    string ReserverName,
    string ReserverSurname ,
    string CatName,
    int CatAgeInMonths,
    string CatColor 
    );