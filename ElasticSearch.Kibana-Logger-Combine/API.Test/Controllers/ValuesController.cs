using Custom.Logger;
using ElasticSearch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace API.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IElasticSearchHelper _esHelper;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger, IElasticSearchHelper esHelper)
        {
            _esHelper = esHelper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //CustomActionLog actionLog = new CustomActionLog
            //{
            //    UserId = "123",
            //    UserEmail = "naadydev@gmail.com",
            //    Message = "Hallo"
            //};

            //var result = _esHelper.AddNewDocument(actionLog);

            _logger.LogError(CustomLoggerEvents.Error,"My LogError {k1} {k2} {k3}", 1, 2, 3);
            //_logger.Log(LogLevel.Information, CustomLoggerEvents.CreateItem, "CreateItem item {Id} {blakey}", 22, 33);
            //_logger.LogInformation(CustomLoggerEvents.ResourceNotFound, "Getting item {Id}", 22);




            //_logger.LogInformation("My LogInformation {0} {1} {2}", 1, 2, 3);
            //_logger.LogWarning("My LogWarning {0} {1} {2}", 1, 2, 3);
            //_logger.LogCritical("My LogCritical {0} {1} {2}", 1, 2, 3);
            //_logger.LogDebug("My LogDebug {0} {1} {2}", 1, 2, 3);
            //_logger.LogTrace("My LogTrace {0} {1} {2}", 1, 2, 3);

            return Ok();
        }




    }
}
