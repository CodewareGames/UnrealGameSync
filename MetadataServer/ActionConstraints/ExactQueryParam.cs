// Copyright CodeWareGames. All Rights Reserved.

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MetadataServer.ActionConstraints
{
    public class ExactQueryParamAttribute : Attribute, IActionConstraint
    {
        private readonly string[] keys;

        public ExactQueryParamAttribute(params string[] keys)
        {
            this.keys = keys;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var query = context.RouteContext.HttpContext.Request.Query;
            return query.Count == keys.Length && keys.All(key => query.ContainsKey(key));
        }
    }
}
