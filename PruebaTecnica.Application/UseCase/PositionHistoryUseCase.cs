using PruebaTecnica.Application.Common;
using PruebaTecnica.Application.Contracts;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;

namespace PruebaTecnica.Application.UseCase;

public class PositionHistoryUseCase(IUnitOfWork unitOfWork) : IPositionHistoryUseCase
{
    public void AddHistory(int employeeId, string position)
    {
        TblPositionHistory positionHistory = new TblPositionHistory(){
            DocumentId = employeeId,
            Position = position,
            StartDate = Utilities.ObtenerFecha()
        };

        unitOfWork.PositionHistory.Insert(positionHistory);
        unitOfWork.save();
    }

    public void UpdateHistoryEndDate(int employeeId)
    {
        TblPositionHistory history = unitOfWork.GetPositionByEmployeeId(employeeId);
        history.EndDate = Utilities.ObtenerFecha();

        unitOfWork.PositionHistory.Update(history);
        unitOfWork.save();
    }
}
