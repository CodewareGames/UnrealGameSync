// Copyright Epic Games, Inc. All Rights Reserved.
// Modifications Copyright CodeWareGames. All Rights Reserved.

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MetadataServer.Connectors;
using MetadataServer.Models;

namespace MetadataServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public TelemetryController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpPost]
        public async Task<long> Post([FromBody] TelemetryTimingData Data, string Version, string IpAddress)
        {
            return await _MySqlConnector.PostTelemetryData(Data, Version, IpAddress);
        }
    }
}
