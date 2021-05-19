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
    public class EventController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public EventController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<EventData>> Get(string Project, long LastEventId)
        {
            return await _MySqlConnector.GetUserVotes(Project, LastEventId);
        }

        [HttpPost]
        public async Task<long> Post([FromBody] EventData Event)
        {
            return await _MySqlConnector.PostEvent(Event);
        }
    }
}
