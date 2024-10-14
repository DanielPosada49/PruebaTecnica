
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Common;
using PruebaTecnica.Application.Contracts;
using Newtonsoft.Json;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployessController(IEmployeeUseCase employeeUseCase) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployess(){
            var employess = await employeeUseCase.GetEmployees();
            var result = Utilities.CreateResponse(StatusCodes.Status200OK, JsonConvert.SerializeObject(employess));
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }
    }
}
