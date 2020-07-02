using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Queries;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public AuditLogController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/AuditLog
        [HttpGet]
        public IActionResult Get([FromQuery] AuditLogSearch search, [FromServices] IGetAuditLogs query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }


    }
}
