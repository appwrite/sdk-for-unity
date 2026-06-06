#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Apps : Service
    {
        public Apps(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// List applications.
        /// </para>
        /// </summary>
        public UniTask<Models.AppsList> List(List<string>? queries = null, bool? total = null)
        {
            var apiPath = "/apps";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries },
                { "total", total }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") }
            };


            static Models.AppsList Convert(Dictionary<string, object> it) =>
                Models.AppsList.From(map: it);

            return _client.Call<Models.AppsList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Create a new application.
        /// </para>
        /// </summary>
        public UniTask<Models.App> Create(string appId, string name, List<string> redirectUris, bool? enabled = null, string? type = null, bool? deviceFlow = null, string? teamId = null)
        {
            var apiPath = "/apps";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "appId", appId },
                { "name", name },
                { "redirectUris", redirectUris },
                { "enabled", enabled },
                { "type", type },
                { "deviceFlow", deviceFlow },
                { "teamId", teamId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" }
            };


            static Models.App Convert(Dictionary<string, object> it) =>
                Models.App.From(map: it);

            return _client.Call<Models.App>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get an application by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.App> Get(string appId)
        {
            var apiPath = "/apps/{appId}"
                .Replace("{appId}", appId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") }
            };


            static Models.App Convert(Dictionary<string, object> it) =>
                Models.App.From(map: it);

            return _client.Call<Models.App>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Update an application by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.App> Update(string appId, string name, bool? enabled = null, List<string>? redirectUris = null, string? type = null, bool? deviceFlow = null)
        {
            var apiPath = "/apps/{appId}"
                .Replace("{appId}", appId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "name", name },
                { "enabled", enabled },
                { "redirectUris", redirectUris },
                { "type", type },
                { "deviceFlow", deviceFlow }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" }
            };


            static Models.App Convert(Dictionary<string, object> it) =>
                Models.App.From(map: it);

            return _client.Call<Models.App>(
                method: "PUT",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Delete an application by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> Delete(string appId)
        {
            var apiPath = "/apps/{appId}"
                .Replace("{appId}", appId);

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

        /// <summary>
        /// <para>
        /// List client secrets for an application.
        /// </para>
        /// </summary>
        public UniTask<Models.AppSecretList> ListSecrets(string appId, List<string>? queries = null, bool? total = null)
        {
            var apiPath = "/apps/{appId}/secrets"
                .Replace("{appId}", appId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries },
                { "total", total }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") }
            };


            static Models.AppSecretList Convert(Dictionary<string, object> it) =>
                Models.AppSecretList.From(map: it);

            return _client.Call<Models.AppSecretList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Create a new client secret for an application.
        /// </para>
        /// </summary>
        public UniTask<Models.AppSecretPlaintext> CreateSecret(string appId)
        {
            var apiPath = "/apps/{appId}/secrets"
                .Replace("{appId}", appId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" }
            };


            static Models.AppSecretPlaintext Convert(Dictionary<string, object> it) =>
                Models.AppSecretPlaintext.From(map: it);

            return _client.Call<Models.AppSecretPlaintext>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get an application client secret by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.AppSecret> GetSecret(string appId, string secretId)
        {
            var apiPath = "/apps/{appId}/secrets/{secretId}"
                .Replace("{appId}", appId)
                .Replace("{secretId}", secretId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") }
            };


            static Models.AppSecret Convert(Dictionary<string, object> it) =>
                Models.AppSecret.From(map: it);

            return _client.Call<Models.AppSecret>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Delete an application client secret by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteSecret(string appId, string secretId)
        {
            var apiPath = "/apps/{appId}/secrets/{secretId}"
                .Replace("{appId}", appId)
                .Replace("{secretId}", secretId);

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

        /// <summary>
        /// <para>
        /// Transfer an application to another team by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.App> UpdateTeam(string appId, string teamId)
        {
            var apiPath = "/apps/{appId}/team"
                .Replace("{appId}", appId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "teamId", teamId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" }
            };


            static Models.App Convert(Dictionary<string, object> it) =>
                Models.App.From(map: it);

            return _client.Call<Models.App>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Revoke all tokens for an application by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteTokens(string appId)
        {
            var apiPath = "/apps/{appId}/tokens"
                .Replace("{appId}", appId);

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