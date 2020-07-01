using System;
using System.Collections.Generic;
using System.IO;
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
    public class PerfumeController : ControllerBase
    {
        private UseCaseExecutor _executor;
        public PerfumeController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // GET: api/Perfume
        [HttpGet]
        public IActionResult Get([FromQuery] PerfumeSearch search, [FromServices] IGetPerfumesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET: api/Perfume/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id, [FromServices] IGetPerfume query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST: api/Perfume
        [HttpPost]
        public IActionResult Post([FromForm] CreatePerfumeDto dto, [FromServices] ICreatePerfumeCommand command)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.ImageFile.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.ImageFile.CopyTo(fileStream);
            }
            dto.Image = path;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Perfume/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdatePerfumeDto dto, [FromServices] IUpdatePerfumeCommand command)
        {
            dto.Id = id;
            if (dto.ImageFile != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.ImageFile.FileName);

                var newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.ImageFile.CopyTo(fileStream);
                }
                dto.Image = path;
            }
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePerfumeCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
