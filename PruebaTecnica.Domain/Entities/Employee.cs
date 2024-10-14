
namespace PruebaTecnica.Domain.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CurrentPosition { get; set; } = null!;

    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }

    public int? ProjectId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<PositionHistory> PositionHistories { get; set; } = new List<PositionHistory>();

    public virtual Project? Project { get; set; }
}
