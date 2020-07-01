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
        // GET: api/UseCase
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogSearch search, [FromServices] IGetAuditLogs query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


        // POST: api/UseCase
        [HttpPost]
        public IActionResult Post([FromBody] UserUseCaseDto dto, [FromServices] IAddUserUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] UserUseCaseDto dto, [FromServices] IUserUseCaseDeleteCommand command)
        {
            dto.UseCaseId = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
