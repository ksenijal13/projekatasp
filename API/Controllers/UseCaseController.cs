using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public UseCaseController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // POST: api/UseCase
        [HttpPost]
        public IActionResult Post([FromBody] UserUseCaseDto dto, [FromServices] IAddUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete([FromQuery] UserUseCaseDeleteDto dto, [FromServices] IUserUseCaseDeleteCommand command)
        {
           // dto.UseCaseId = useCaseId;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
