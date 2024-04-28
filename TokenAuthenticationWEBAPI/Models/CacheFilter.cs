﻿using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace TokenAuthenticationWEBAPI.Models
{
    public class CacheFilter : ActionFilterAttribute
    {
        public int TimeDuration { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(TimeDuration),
                MustRevalidate = true,
                Public = true
            };
        
        }
    }
}