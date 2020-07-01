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
    public class BrandController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public BrandController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/Brand/5
        [HttpGet("{id}", Name = "GetBrand")]
        public IActionResult Get(int id, [FromServices] IGetBrandWithPerfumesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Brand
        [HttpPost]
        public IActionResult Post([FromBody] InsertBrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Brand/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto, [FromServices] IUpdateBrandCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
