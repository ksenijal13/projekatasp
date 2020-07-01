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
    public class FragranceTypeController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public FragranceTypeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/FragranceType
        [HttpGet]
        public IActionResult Get([FromBody] FragranceSearch search, [FromServices] IGetFragranceTypes query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
        // GET: api/FragranceType/5
        [HttpGet("{id}", Name = "GetFP")]
        public IActionResult Get(int id, [FromBody] PerfumeSearch search, [FromServices] IGetPerfumesByFragranceType query)
        {
            search.FragranceTypeId = id;
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
