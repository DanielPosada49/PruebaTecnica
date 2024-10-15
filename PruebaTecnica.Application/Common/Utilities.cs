using PruebaTecnica.Application.DataTransferObjects;
using TimeZoneConverter;

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

    public static DateTime ObtenerFecha(){
        var utc = DateTime.UtcNow;
        TimeZoneInfo zone = TZConvert.GetTimeZoneInfo("SA Pacific Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(utc, zone);
    }
}
