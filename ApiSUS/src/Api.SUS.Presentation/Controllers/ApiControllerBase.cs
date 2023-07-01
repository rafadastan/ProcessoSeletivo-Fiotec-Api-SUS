using Api.SUS.Domain.Notifications;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.SUS.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();
        private readonly NotificationContext _notificationHandler;
        private readonly ValidationResult _validationResult;

        public ApiControllerBase(NotificationContext notificationHandler, ValidationResult validationResult)
        {
            _notificationHandler = notificationHandler;
            _validationResult = validationResult;
        }

        protected ActionResult CustomResponse(object result = null)
        {
            AddNotifications();

            if (IsOperationValid())
            {
                if (result == null || result is ValidationResult) return Ok();
                return Ok(result);
            }

            return BadRequest(_notificationHandler.Notifications);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(DevExpress.XtraReports.UI.XtraReport report)
        {
            AddNotifications();

            if (IsOperationValid())
            {
                if (report == null!) return Ok();

                MemoryStream stream;
                using (MemoryStream ms = new MemoryStream())
                {
                    report.ExportToPdf(ms);
                    stream = ms;
                }

                byte[] byteArray = stream.ToArray();
                stream.Flush();
                stream.Close();

                return File(byteArray, "application/pdf", "Report.pdf");
            }

            return BadRequest(_notificationHandler.Notifications);
        }

        protected void AddNotifications()
        {
            if (!_validationResult.IsValid)
            {
                _notificationHandler.AddNotifications(_validationResult);
            }
        }

        protected bool IsOperationValid()
        {
            return !_notificationHandler.HasNotifications;
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
