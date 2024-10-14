using System;

namespace PruebaTecnica.Application.DataTransferObjects;

public class ServiceResponseDto
{
    public int StatusCode { get; set; }
    public object Message { get; set; }
}
