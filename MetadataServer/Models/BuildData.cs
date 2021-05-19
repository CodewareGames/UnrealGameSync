// Copyright Epic Games, Inc. All Rights Reserved.

namespace MetadataServer.Models
{
    public class BuildData
    {
		public enum BuildDataResult
		{
			Starting,
			Failure,
			Warning,
			Success,
			Skipped,
		}

		public long Id;
		public int ChangeNumber;
		public string BuildType;
		public BuildDataResult Result;
		public string Url;
		public string Project;
		public string ArchivePath;

		public bool IsSuccess
		{
			get { return Result == BuildDataResult.Success || Result == BuildDataResult.Warning; }
		}

		public bool IsFailure
		{
			get { return Result == BuildDataResult.Failure; }
		}
	}
}
