﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using static Cloudtoid.Contract;
using Method = System.Net.Http.HttpMethod;

namespace Cloudtoid
{
    [DebuggerStepThrough]
    public static class HttpMethod
    {
        private static readonly IReadOnlyDictionary<string, Method> HttpMethods = new Dictionary<string, Method>(StringComparer.OrdinalIgnoreCase)
        {
            { Method.Get.Method, Method.Get },
            { Method.Post.Method, Method.Post },
            { Method.Options.Method, Method.Options },
            { Method.Head.Method, Method.Head },
            { Method.Delete.Method, Method.Delete },
            { "PATCH", new("PATCH") },
            { Method.Put.Method, Method.Put },
            { Method.Trace.Method, Method.Trace },
        };

        public static Method Parse(string method)
        {
            CheckNonEmpty(method, nameof(method));
            return HttpMethods.TryGetValue(method, out var m) ? m : new Method(method);
        }
    }
}
