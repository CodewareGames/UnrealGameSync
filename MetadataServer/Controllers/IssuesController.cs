// Copyright Epic Games, Inc. All Rights Reserved.
// Modifications Copyright CodeWareGames. All Rights Reserved.

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MetadataServer.Connectors;
using MetadataServer.Models;
using MetadataServer.ActionConstraints;

namespace MetadataServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public IssuesController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<IssueData>> Get([FromQuery] bool IncludeResolved = false, [FromQuery] int MaxResults = -1)
        {
            return await _MySqlConnector.GetIssues(IncludeResolved, MaxResults);
        }

        [HttpGet]
        [ExactQueryParam("user")]
        public async Task<List<IssueData>> Get([FromQuery] string User)
        {
            return await _MySqlConnector.GetIssues(User);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IssueData> Get(long id)
        {
            return await _MySqlConnector.GetIssue(id);
        }

        [HttpPut]
        public async Task<long> Put(long id, IssueUpdateData Issue)
        {
            return await _MySqlConnector.UpdateIssue(id, Issue);
        }

        [HttpPost]
        public async Task<object> Post(IssueData Issue)
        {
            long IssueId = await _MySqlConnector.AddIssue(Issue);
            return new { Id = IssueId };
        }

        [HttpDelete]
        public async Task<long> Delete(long id)
        {
            return await _MySqlConnector.DeleteIssue(id);
        }

       
    }

    [Route("api/issues/{IssueId}/builds")]
    [ApiController]
    public class IssueBuildsSubController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public IssueBuildsSubController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<IssueBuildData>> Get(long IssueId)
        {
            return await _MySqlConnector.GetBuilds(IssueId);
        }

        [HttpPost]
        public async Task<object> Post(long IssueId, [FromBody] IssueBuildData Data)
        {
            long BuildId = await _MySqlConnector.AddBuild(IssueId, Data);
            return new { Id = BuildId };
        }
    }

    [Route("api/issues/{IssueId}/diagnostics")]
    [ApiController]
    public class IssueDiagnosticsSubController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public IssueDiagnosticsSubController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<IssueDiagnosticData>> Get(long IssueId)
        {
            return await _MySqlConnector.GetDiagnostics(IssueId);
        }

        [HttpPost]
        public async Task<long> Post(long IssueId, [FromBody] IssueDiagnosticData Data)
        {
            return await _MySqlConnector.AddDiagnostic(IssueId, Data);
        }
    }

    [Route("api/issuebuilds/{BuildId}")]
    [ApiController]
    public class IssueBuildsController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public IssueBuildsController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<IssueBuildData> Get(long BuildId)
        {
            return await _MySqlConnector.GetBuild(BuildId);
        }

        [HttpPut]
        public async Task<long> Put(long BuildId, [FromBody] IssueBuildUpdateData Data)
        {
            return await _MySqlConnector.UpdateBuild(BuildId, Data.Outcome);
        }
    }

    [Route("api/issues/{IssueId}/watchers")]
    [ApiController]
    public class IssueWatchersController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public IssueWatchersController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<string>> Get(long IssueId)
        {
            return await _MySqlConnector.GetWatchers(IssueId);
        }

        [HttpPost]
        public async Task<long> Post(long IssueId, [FromBody] IssueWatcherData Data)
        {
            return await _MySqlConnector.AddWatcher(IssueId, Data.UserName);
        }

        [HttpDelete]
        public async Task<long> Delete(long IssueId, [FromBody] IssueWatcherData Data)
        {
            return await _MySqlConnector.RemoveWatcher(IssueId, Data.UserName);
        }
    }
}
