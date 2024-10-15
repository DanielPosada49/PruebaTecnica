using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Domain.Request;

public class UpdateEmployeeRequest : DocumentRequest
{
    [RegularExpression(@"^([a-zA-Z\s])+$", ErrorMessage = "La cadena no tiene el formato correcto")]
    public string? Name { get; set; }

    [RegularExpression(@"^([a-zA-Z0-9\s])+$", ErrorMessage = "La cadena no tiene el formato correcto")]
    public string? CurrentPosition { get; set; }

    [RegularExpression("([0-9])+", ErrorMessage = "La cadena no tiene el formato correcto")]
    public decimal Salary { get; set; }

    [RegularExpression("([0-9])+", ErrorMessage = "La cadena no tiene el formato correcto")]
    public int DepartmentId { get; set; }

    [RegularExpression("([0-9])+", ErrorMessage = "La cadena no tiene el formato correcto")]
    public int? ProjectId { get; set; }
}
