// Copyright Epic Games, Inc. All Rights Reserved.

using System;

namespace MetadataServer.Models
{
    public class TelemetryErrorData
    {
		public enum TelemetryErrorType
		{
			Crash,
		}
		public int Id;
		public TelemetryErrorType Type;
		public string Text;
		public string UserName;
		public string Project;
		public DateTime Timestamp;
		public string Version;
		public string IpAddress;
	}
}
