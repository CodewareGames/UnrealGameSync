// Copyright Epic Games, Inc. All Rights Reserved.
// Modifications Copyright CodeWareGames. All Rights Reserved.

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetadataServer.Connectors;
using MetadataServer.Models;

namespace MetadataServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public ErrorController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<TelemetryErrorData>> Get(int Records = 10)
        {
            return await _MySqlConnector.GetErrorData(Records);
        }

        [HttpPost]
        public async Task<long> Post([FromBody] TelemetryErrorData Data, string Version, string IpAddress)
        {
            return await _MySqlConnector.PostErrorData(Data, Version, IpAddress);
        }
    }
}
