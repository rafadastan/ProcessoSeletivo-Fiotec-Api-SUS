using Api.SUS.Application.Contracts;
using Api.SUS.Application.Model;
using Api.SUS.Domain.Notifications;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.SUS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitanteController : ApiControllerBase
    {
        private readonly ISolicitanteAppService _solicitanteAppService;
        public SolicitanteController(
            NotificationContext notificationHandler, 
            ValidationResult validationResult, 
            ISolicitanteAppService solicitanteAppService)
            : base(notificationHandler, validationResult)
        {
            _solicitanteAppService = solicitanteAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SolicitanteModel), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> SolicitacaoRelatorio([FromBody] SolicitanteModel model)
        {
            return !ModelState.IsValid ?
                CustomResponse(ModelState) :
                CustomResponse(await _solicitanteAppService.SendAsync(model));
        }

        [AllowAnonymous]
        [HttpGet("{dataAplicacaoVacina}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(BadHttpRequestException), 500)]
        public async Task<IActionResult> GetTotalVacinasAplicada(DateTime dataAplicacaoVacina)
        {
            var result = await _solicitanteAppService.GetTotalVacinasAplicada(dataAplicacaoVacina);

            if (result == null)
                return NoContent();

            return Ok(result);   
        }
    }
}
