using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workshop2022.API.Models;
using Workshop2022.API.Models.Features;
using Workshop2022.API.Services;

namespace Workshop2022.API.Controllers
{
    [ApiController]
    [Route("API")]
    public class FeatureApiController : ControllerBase
    {
        private readonly ILogger<FeatureApiController> _logger;
        private readonly IFeatureDataService _data;


        public FeatureApiController(ILogger<FeatureApiController> logger, IFeatureDataService data)
        {
            _logger = logger;
            _data = data;
        }

        #region -- standard status query --
        [HttpGet]
        [Route("service-status")]
        public string GetServiceStatus()
        {
            return "OK";
        }
        #endregion

        [HttpPost]
        [Route("features")]
        public IActionResult RetrieveFeatures(FeaturesRequest model)
        {
            // -- SAMPLE ONLY - populate filter(s) from request 
            var features = _data.GetFeatures(x => x.App == "TestApp01" && x.FeatureCode == "Config");

            // -- add code as needed

            var result = new FeaturesResponse()
            {
              // populate as needed
            };
            
            return Ok(result);
        }
    }
}
