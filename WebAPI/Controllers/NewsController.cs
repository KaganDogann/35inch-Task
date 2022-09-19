
using Business.Handlers.News.Commands;
using Business.Handlers.News.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateNewsCommand createNewsCommand)
        {
         var addedNews= await Mediator.Send(createNewsCommand);
            if (addedNews.Success)
            {
                return Ok(addedNews);
            }
            return BadRequest(addedNews);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteNewsCommand deleteNewsCommand)
        {
            var deletedNews = await Mediator.Send(deleteNewsCommand);
            if (deletedNews != null)
            {
                return Ok(deletedNews);
            }
            return BadRequest(deletedNews);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNewsCommand updateNewsCommand)
        {
            var updatedNews = await Mediator.Send(updateNewsCommand);
            return Ok(updatedNews);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll([FromQuery] GetListNewsQuery getListNewsQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getListNewsQuery);
            return Ok(result);
        }
        [HttpGet("getAllNewsDetails")]
        public async Task<ActionResult> GetNewsDetails([FromQuery] GetAllNewsDetails getAllNewsDetails, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getAllNewsDetails);
            return Ok(result);
        }
        [HttpGet("getById")]
        public async Task<ActionResult> GetById([FromQuery] GetByIdNewsQuery getByIdNewsQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getByIdNewsQuery);
            return Created("", result);
        }

        [HttpGet("getNewsTotalPages")]
        public async Task<ActionResult> GetNewsTotalPages([FromQuery] GetNewsTotalPageQuery getNewsTotalPageQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getNewsTotalPageQuery);
            return Ok(result);
        }
    }
}
