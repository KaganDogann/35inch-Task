using Business.Constants;
using Business.Handlers.Image.Command;
using Business.Handlers.Image.Queries;
using Core.Utilities.Helpers.FileHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsImagesController : BaseApiController
    {
        IFileHelper _fileHelper;
        public NewsImagesController(IFileHelper fileHelper)
        {

            _fileHelper = fileHelper;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateNewsImageCommand createNewsImageCommand, [FromForm] IFormFile file)
        {
            createNewsImageCommand.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            var result = await Mediator.Send(createNewsImageCommand);
            return Created("", result);
        }
        [HttpGet("getall")]
        public async Task<ActionResult> GetAll([FromQuery] GetListNewsImageQuery getListNewsImageQuery, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(getListNewsImageQuery);
            return Ok(result);
        }
    }
}
