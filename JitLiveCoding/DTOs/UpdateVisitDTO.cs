using System.ComponentModel.DataAnnotations;

namespace JitLiveCoding.DTOs;

public record UpdateVisitDTO(
    string ReserverName,
    string ReserverSurname ,
    string CatName,
    int CatAgeInMonths,
    string CatColor,
    [Required] DateTime VisitDate
    );