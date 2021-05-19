// Copyright Epic Games, Inc. All Rights Reserved.
// Modifications Copyright CodeWareGames. All Rights Reserved.

using MetadataServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MetadataServer.Connectors
{
    public interface IMySqlConnector
    {
        Task<LatestData> GetLastIds(string Project);
        Task<List<EventData>> GetUserVotes(string Project, long LastEventId);
        Task<List<CommentData>> GetComments(string Project, long LastCommentId);
        Task<List<BuildData>> GetBuilds(string Project, long LastBuildId);
        Task<List<TelemetryErrorData>> GetErrorData(int Records);
        Task<long> PostBuild(BuildData Build);
        Task<long> PostEvent(EventData Event);
        Task<long> PostComment(CommentData Comment);
        Task<long> PostTelemetryData(TelemetryTimingData Data, string Version, string IpAddress);
        Task<long> PostErrorData(TelemetryErrorData Data, string Version, string IpAddress);
        Task<long> FindOrAddUserId(string Name);
        Task<long> AddIssue(IssueData Issue);
        Task<IssueData> GetIssue(long IssueId);
        Task<List<IssueData>> GetIssues(bool IncludeResolved, int NumResults);
        Task<List<IssueData>> GetIssues(string UserName);
        Task<long> UpdateIssue(long IssueId, IssueUpdateData Issue);
        string SanitizeText(string Text, int Length);
        Task<long> DeleteIssue(long IssueId);
        Task<long> AddDiagnostic(long IssueId, IssueDiagnosticData Diagnostic);
        Task<List<IssueDiagnosticData>> GetDiagnostics(long IssueId);
        Task<long> AddWatcher(long IssueId, string UserName);
        Task<List<string>> GetWatchers(long IssueId);
        Task<long> RemoveWatcher(long IssueId, string UserName);
        Task<long> AddBuild(long IssueId, IssueBuildData Build);
        Task<List<IssueBuildData>> GetBuilds(long IssueId);
        Task<IssueBuildData> GetBuild(long BuildId);
        Task<long> UpdateBuild(long BuildId, int Outcome);

    }
}
