using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Domain.Request;

public class EmployeeRequest : DocumentRequest
{
    [Required(ErrorMessage = "{0} es requerido")]
    [StringLength(100, MinimumLength = 3)]
    [RegularExpression(@"^([a-zA-Z\s])+$", ErrorMessage = "La cadena no tiene el formato correcto")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "{0} es requerido")]
    [StringLength(100, MinimumLength = 3)]
    [RegularExpression(@"^([a-zA-Z0-9\s])+$", ErrorMessage = "La cadena no tiene el formato correcto")]
    public string CurrentPosition { get; set; } = null!;

    [Required(ErrorMessage = "{0} es requerido")]
    [RegularExpression("([0-9])+", ErrorMessage = "La cadena no tiene el formato correcto")]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "{0} es requerido")]
    [RegularExpression("([0-9])+", ErrorMessage = "La cadena no tiene el formato correcto")]
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "{0} es requerido")]
    [RegularExpression("([0-9])+", ErrorMessage = "La cadena no tiene el formato correcto")]
    public int? ProjectId { get; set; }
}
