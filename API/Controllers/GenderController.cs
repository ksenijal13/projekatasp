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
    public class GenderController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public GenderController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Gender
        [HttpGet]
        public IActionResult Get([FromBody] GenderSearch search, [FromServices] IGetGenders query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

      
        
    }
}
