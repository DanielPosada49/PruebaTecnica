namespace PruebaTecnica.Domain.Entities;

public partial class TblDepartment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TblEmployee> Employees { get; set; } = new List<TblEmployee>();
}
