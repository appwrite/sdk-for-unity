#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Messaging : Service
    {
        public Messaging(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// Create a new subscriber.
        /// </para>
        /// </summary>
        public UniTask<Models.Subscriber> CreateSubscriber(string topicId, string subscriberId, string targetId)
        {
            var apiPath = "/messaging/topics/{topicId}/subscribers"
                .Replace("{topicId}", topicId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "subscriberId", subscriberId },
                { "targetId", targetId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static Models.Subscriber Convert(Dictionary<string, object> it) =>
                Models.Subscriber.From(map: it);

            return _client.Call<Models.Subscriber>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Delete a subscriber by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteSubscriber(string topicId, string subscriberId)
        {
            var apiPath = "/messaging/topics/{topicId}/subscribers/{subscriberId}"
                .Replace("{topicId}", topicId)
                .Replace("{subscriberId}", subscriberId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" }
            };



            return _client.Call<object>(
                method: "DELETE",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!);

        }

    }
}
#endif