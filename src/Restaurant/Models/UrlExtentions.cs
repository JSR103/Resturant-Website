﻿using Microsoft.AspNetCore.Http;

namespace Restaurant.Models
{
    public static class UrlExtentions
    {
        public static string PathAndQuery(this HttpRequest request) =>
    request.QueryString.HasValue
        ? $"{request.Path}{request.QueryString}"
        : request.Path.ToString();
    }
}
