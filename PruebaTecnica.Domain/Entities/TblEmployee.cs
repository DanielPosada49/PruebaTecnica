
namespace PruebaTecnica.Domain.Entities;

public partial class TblEmployee
{
    public int DocumentId { get; set; }

    public string Name { get; set; } = null!;

    public string CurrentPosition { get; set; } = null!;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public int? ProjectId { get; set; }

    public virtual TblDepartment Department { get; set; } = null!;

    public virtual TblProject? Project { get; set; }
}
