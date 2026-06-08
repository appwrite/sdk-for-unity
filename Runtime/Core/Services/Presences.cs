#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Presences : Service
    {
        public Presences(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// List presence logs. Expired entries are filtered out automatically.
        /// 
        /// </para>
        /// </summary>
        public UniTask<Models.PresenceList> List(List<string>? queries = null, bool? total = null, long? ttl = null)
        {
            var apiPath = "/presences";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries },
                { "total", total },
                { "ttl", ttl }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
            };


            static Models.PresenceList Convert(Dictionary<string, object> it) =>
                Models.PresenceList.From(map: it);

            return _client.Call<Models.PresenceList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get a presence log by its unique ID. Entries whose `expiresAt` is in the
        /// past are treated as not found.
        /// 
        /// </para>
        /// </summary>
        public UniTask<Models.Presence> Get(string presenceId)
        {
            var apiPath = "/presences/{presenceId}"
                .Replace("{presenceId}", presenceId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
            };


            static Models.Presence Convert(Dictionary<string, object> it) =>
                Models.Presence.From(map: it);

            return _client.Call<Models.Presence>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Create or update a presence log by its user ID.
        /// 
        /// </para>
        /// </summary>
        public UniTask<Models.Presence> Upsert(string presenceId, string status, List<string>? permissions = null, string? expiresAt = null, object? metadata = null)
        {
            var apiPath = "/presences/{presenceId}"
                .Replace("{presenceId}", presenceId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "status", status },
                { "permissions", permissions },
                { "expiresAt", expiresAt },
                { "metadata", metadata }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static Models.Presence Convert(Dictionary<string, object> it) =>
                Models.Presence.From(map: it);

            return _client.Call<Models.Presence>(
                method: "PUT",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Update a presence log by its unique ID. Using the patch method you can pass
        /// only specific fields that will get updated.
        /// 
        /// </para>
        /// </summary>
        public UniTask<Models.Presence> Update(string presenceId, string? status = null, string? expiresAt = null, object? metadata = null, List<string>? permissions = null, bool? purge = null)
        {
            var apiPath = "/presences/{presenceId}"
                .Replace("{presenceId}", presenceId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "status", status },
                { "expiresAt", expiresAt },
                { "metadata", metadata },
                { "permissions", permissions },
                { "purge", purge }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static Models.Presence Convert(Dictionary<string, object> it) =>
                Models.Presence.From(map: it);

            return _client.Call<Models.Presence>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Delete a presence log by its unique ID.
        /// 
        /// </para>
        /// </summary>
        public UniTask<object> Delete(string presenceId)
        {
            var apiPath = "/presences/{presenceId}"
                .Replace("{presenceId}", presenceId);

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