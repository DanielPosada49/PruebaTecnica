
namespace PruebaTecnica.Domain.Entities;

public partial class PositionHistory
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Position { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
