using PruebaTecnica.Application.DataTransferObjects;

namespace PruebaTecnica.Application.Common;

public class Utilities
{
    public static ServiceResponseDto CreateResponse(int StatusCode, object message){

        ServiceResponseDto serviceResponse = new ServiceResponseDto{
            StatusCode = StatusCode,
            Message = message
        };
        return serviceResponse;
    }
}
