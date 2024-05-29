namespace JitLiveCoding.DTOs;

public record VisitDTO(
        int ID,
        string ReserverName,
        string ReserverSurname ,
        string CatName,
        int CatAgeInMonths,
        string CatColor 
        );