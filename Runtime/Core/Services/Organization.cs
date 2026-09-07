#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Organization : Service
    {
        public Organization(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// List app installations on the organization. Any organization member can
        /// read installations.
        /// </para>
        /// </summary>
        public UniTask<Models.AppInstallationList> ListInstallations(List<string>? queries = null, bool? total = null)
        {
            var apiPath = "/organization/installations";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries },
                { "total", total }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
            };


            static Models.AppInstallationList Convert(Dictionary<string, object> it) =>
                Models.AppInstallationList.From(map: it);

            return _client.Call<Models.AppInstallationList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Install an app on the organization. Only organization members with the
        /// owner role can install apps. The installation is granted the scopes the app
        /// currently requests.
        /// </para>
        /// </summary>
        public UniTask<Models.AppInstallation> CreateInstallation(string appId, string? authorizationDetails = null)
        {
            var apiPath = "/organization/installations";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "appId", appId },
                { "authorizationDetails", authorizationDetails }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static Models.AppInstallation Convert(Dictionary<string, object> it) =>
                Models.AppInstallation.From(map: it);

            return _client.Call<Models.AppInstallation>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get an app installation on the organization by its unique ID. Any
        /// organization member can read installations.
        /// </para>
        /// </summary>
        public UniTask<Models.AppInstallation> GetInstallation(string installationId)
        {
            var apiPath = "/organization/installations/{installationId}"
                .Replace("{installationId}", installationId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
            };


            static Models.AppInstallation Convert(Dictionary<string, object> it) =>
                Models.AppInstallation.From(map: it);

            return _client.Call<Models.AppInstallation>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Update an app installation on the organization. Only organization members
        /// with the owner role can update installations. The installation's granted
        /// scopes are refreshed to the scopes the app currently requests; previously
        /// issued installation access tokens are revoked.
        /// </para>
        /// </summary>
        public UniTask<Models.AppInstallation> UpdateInstallation(string installationId, string? authorizationDetails = null)
        {
            var apiPath = "/organization/installations/{installationId}"
                .Replace("{installationId}", installationId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "authorizationDetails", authorizationDetails }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static Models.AppInstallation Convert(Dictionary<string, object> it) =>
                Models.AppInstallation.From(map: it);

            return _client.Call<Models.AppInstallation>(
                method: "PUT",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Uninstall an app from the organization by its installation ID. Only
        /// organization members with the owner role can remove installations.
        /// Previously issued installation access tokens are revoked.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteInstallation(string installationId)
        {
            var apiPath = "/organization/installations/{installationId}"
                .Replace("{installationId}", installationId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
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
