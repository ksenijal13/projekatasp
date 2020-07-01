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
    public class GenderPerfumeController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public GenderPerfumeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
       
        // GET: api/GenderPerfume/5
        [HttpGet("{id}", Name = "GetGP")]
        public IActionResult Get(int id, [FromQuery] PerfumeSearch search, [FromServices] IGetPerfumesByGender query)
        {
            search.GenderId = id;
            
            return Ok(_executor.ExecuteQuery(query, search));
        }

    }
}
