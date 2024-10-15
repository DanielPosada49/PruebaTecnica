
namespace PruebaTecnica.Domain.Entities;

public partial class TblPositionHistory
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public string Position { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
