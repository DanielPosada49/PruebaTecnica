namespace PruebaTecnica.Application.Contracts;

public interface IPositionHistoryUseCase
{
    void AddHistory(int employeeId, string position);
    void UpdateHistoryEndDate(int employeeId);
}
