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
    public class LatestController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public LatestController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<LatestData> Get(string Project = null)
        {
            return await _MySqlConnector.GetLastIds(Project);
        }
    }
}
