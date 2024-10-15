using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Domain.Request;

public class DeleteEmployeeRequest
{
    [Required(ErrorMessage = "{0} es requerido")]
    [StringLength(11, MinimumLength = 3)]
    [RegularExpression(@"^([0-9])+$", ErrorMessage = "La cadena no tiene el formato correcto")]
    public string? Document { get; set; }
}
