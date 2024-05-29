using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace JitLiveCoding.DTOs;

public record CreateVisitDTO(
    [Required] string ReserverName,
    [Required] string ReserverSurname ,
    [Required] string CatName,
    [Required] int CatAgeInMonths,
    [Required] string CatColor,
    [Required] DateTime VisitDate
    );