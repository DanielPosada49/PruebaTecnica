
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.Common;
using PruebaTecnica.Application.Contracts;
using Newtonsoft.Json;
using PruebaTecnica.Domain.Request;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployessController(IEmployeeUseCase employeeUseCase) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployees(){
            var employess = await employeeUseCase.GetEmployees();
            var result = Utilities.CreateResponse(StatusCodes.Status200OK, JsonConvert.SerializeObject(employess));
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }

        [HttpGet]
        [Route("GetEmployessByID")]
        public async Task<IActionResult> GetEmployeesByID([FromQuery] int id){

            var employess = await employeeUseCase.GetEmployeeById(id);
            var result = Utilities.CreateResponse(StatusCodes.Status200OK, JsonConvert.SerializeObject(employess));
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }

        [HttpGet]
        [Route("GetEmployessByDepartmenId")]
        public async Task<IActionResult> GetEmployessByDepartmenId([FromQuery] int id){

            var employess = await employeeUseCase.GetEmployeeByDepartmenId(id);
            var result = Utilities.CreateResponse(StatusCodes.Status200OK, JsonConvert.SerializeObject(employess));
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }

        [HttpPost("CreateEmployee", Name = "CreateEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeRequest employee){
             var create = await employeeUseCase.CreateEmployee(employee);
             var result = Utilities.CreateResponse(StatusCodes.Status201Created, JsonConvert.SerializeObject(create));
             return await Task.FromResult(StatusCode(StatusCodes.Status201Created, result));
        }

        [HttpDelete("DeleteEmployee", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee([FromBody] DeleteEmployeeRequest employee){
            var delete = await employeeUseCase.DeleteEmployee(int.Parse(employee.Document));
            var result = Utilities.CreateResponse(StatusCodes.Status200OK, JsonConvert.SerializeObject(delete));
             return await Task.FromResult(StatusCode(StatusCodes.Status200OK, result));
        }

        [HttpPut("UpdateEmployee", Name = "UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeRequest employee){

            int statusCodes;
            var update = await employeeUseCase.UpdateEmployee(employee);
            if((bool)update){
                statusCodes = StatusCodes.Status200OK;
            }else{
                statusCodes = StatusCodes.Status204NoContent;
            }
            var result = Utilities.CreateResponse(statusCodes, JsonConvert.SerializeObject(update));
             return await Task.FromResult(StatusCode(statusCodes, result));
        }
    }
}