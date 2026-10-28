#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Analytics : Service
    {
        public Analytics(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// Send a tracking event from a browser, native app, or server-side SDK.
        /// </para>
        /// </summary>
        public UniTask<object> CreateEvent(string propertyId, string name, string url, string? domain = null, string? referrer = null, long? screenWidth = null, string? sessionHash = null, long? scrollDepth = null, long? engagementTime = null, List<string>? props = null, string? userId = null, string? ip = null, string? userAgent = null)
        {
            if (propertyId == "")
            {
                throw new AppwriteException("Missing required parameter: \"propertyId\"");
            }

            var apiPath = "/analytics/properties/{propertyId}/events"
                .Replace("{propertyId}", Client.EncodePath(propertyId));

            var apiParameters = new Dictionary<string, object?>()
            {
                { "name", name },
                { "url", url },
                { "domain", domain },
                { "referrer", referrer },
                { "screenWidth", screenWidth },
                { "sessionHash", sessionHash },
                { "scrollDepth", scrollDepth },
                { "engagementTime", engagementTime },
                { "props", props },
                { "userId", userId },
                { "ip", ip },
                { "userAgent", userAgent }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };



            return _client.Call<object>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!);

        }

    }
}
#endif
