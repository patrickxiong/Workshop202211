using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLib;
using Workshop2022.API.Models;
using Workshop2022.API.Models.Features;
using Workshop2022.API.Models.Services;
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
        public IActionResult RetrieveFeatures(FeaturesRequest request)
        {
            // -- SAMPLE ONLY - populate filter(s) from request 
            //var features = _data.GetFeatures(x => x.App == "TestApp01" && x.FeatureCode == "Config");

            var features = _data.GetFeatures(x =>
                request.App == x.App &&
                x.IsUserSelected(request.UserId) &&
                x.IsIpSelected(request.Ip) &&
                x.IsDeviceSelected(request.Device));

            // -- add code as needed

            var result = new FeaturesResponse()
            {
                // populate as needed
                Features = features.Select(f => new FeatureItem(f.FeatureCode, f.Version, f.Enabled)).ToArray()
            };
            
            return Ok(result);
        }
    }
}
