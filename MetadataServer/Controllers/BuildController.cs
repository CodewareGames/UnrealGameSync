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
    public class BuildController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public BuildController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<BuildData>> Get(string Project, long LastBuildId)
        {
            return await _MySqlConnector.GetBuilds(Project, LastBuildId);
        }

        [HttpPost]
        public async Task<long> Post([FromBody]BuildData Build)
        {
            return await _MySqlConnector.PostBuild(Build);
        }
    }
}
