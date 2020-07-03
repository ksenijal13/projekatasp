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
        [HttpGet("{userid}", Name = "GetCart")]
        public IActionResult Get(int userid, [FromServices] IGetYourCartQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, userid));
        }

        // POST: api/Cart
        [HttpPost]
        public IActionResult Post([FromBody] AddInCartDto dto, [FromServices] IAddInCartCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Cart/5
        [HttpPut]
        public IActionResult Put([FromQuery] CartDto dto, [FromServices] IUpdateCartQuantity command)
        {
           
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
