﻿// Copyright Epic Games, Inc. All Rights Reserved.

namespace MetadataServer.Models
{
    public class EventData
    {
		public enum EventType
		{
			Syncing,

			// Reviews
			Compiles,
			DoesNotCompile,
			Good,
			Bad,
			Unknown,

			// Starred builds
			Starred,
			Unstarred,

			// Investigating events
			Investigating,
			Resolved,
		}

		public long Id;
		public int Change;
		public string UserName;
		public EventType Type;
		public string Project;
	}
}
