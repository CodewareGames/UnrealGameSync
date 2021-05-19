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
    public class CommentController : ControllerBase
    {
        private readonly IMySqlConnector _MySqlConnector;
        public CommentController(IMySqlConnector MySqlConnector)
        {
            _MySqlConnector = MySqlConnector;
        }

        [HttpGet]
        public async Task<List<CommentData>> Get(string Project, long LastCommentId)
        {
            return await _MySqlConnector.GetComments(Project, LastCommentId);
        }

        [HttpPost]
        public async Task<long> Post([FromBody] CommentData Comment)
        {
            return await _MySqlConnector.PostComment(Comment);
        }
    }
}
