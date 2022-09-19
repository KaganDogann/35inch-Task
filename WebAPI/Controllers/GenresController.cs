using Business.Handlers.Genres.Command;
using Business.Handlers.Genres.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGenreCommand createGenreCommand)
        {
            var addedGenre = await Mediator.Send(createGenreCommand);
            return Ok(addedGenre);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGenreCommand deleteGenreCommand)
        {
            var deletedGenre = await Mediator.Send(deleteGenreCommand);
            return Ok(deletedGenre);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGenreCommand updateGenreCommand)
        {
            var updatedGenre = await Mediator.Send(updateGenreCommand);
            return Ok(updatedGenre);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll([FromQuery] GetListGenreQuery getListGenreQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getListGenreQuery);
            return Ok(result);
        }
        [HttpGet("getById")]
        public async Task<ActionResult> GetById([FromQuery] GetByIdGenreQuery getByIdGenreQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getByIdGenreQuery);
            return Ok(result);
        }

        [HttpGet("getNewsByGenreId")]
        public async Task<ActionResult> GetNewsByGenreId([FromQuery] GetNewsByGenreIdQuery newsByGenreIdQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(newsByGenreIdQuery);
            return Ok(result);
        }
    }
}
