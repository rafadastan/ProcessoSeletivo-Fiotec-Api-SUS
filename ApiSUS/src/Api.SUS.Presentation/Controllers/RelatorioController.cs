using Api.SUS.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.SUS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioAppService _appService;

        public RelatorioController(IRelatorioAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appService.GetAll();

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }
    }
}
