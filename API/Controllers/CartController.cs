using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public CartController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
       

        // GET: api/Cart/5
        [HttpGet("{id}", Name = "GetCart")]
        public IActionResult Get(int id, [FromServices] IGetYourCartQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Cart
        [HttpPost]
        public IActionResult Post([FromBody] CartDto dto, [FromServices] IAddInCartCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CartDto dto, [FromServices] IUpdateCartQuantity command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteFromCartCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
