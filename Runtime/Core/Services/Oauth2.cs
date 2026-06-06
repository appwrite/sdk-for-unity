#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Oauth2 : Service
    {
        public Oauth2(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// Approve an OAuth2 grant after the user gives consent. Returns the
        /// `redirectUrl` the end user should be sent to. The consent screen may
        /// optionally pass enriched `authorization_details` to record the concrete
        /// resources the user selected. You can pass Accept header of
        /// `application/json` to receive a JSON response instead of a redirect.
        /// </para>
        /// </summary>
        public UniTask<Models.Oauth2Approve> Approve(string projectId, string grantId, string? authorizationDetails = null)
        {
            var apiPath = "/oauth2/{project_id}/approve"
                .Replace("{project_id}", projectId);
            apiPath += "?project=" + Uri.EscapeDataString(_client.GetConfig("project"));


            var apiParameters = new Dictionary<string, object?>()
            {
                { "grant_id", grantId },
                { "authorization_details", authorizationDetails }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Oauth2Approve Convert(Dictionary<string, object> it) =>
                Models.Oauth2Approve.From(map: it);

            return _client.Call<Models.Oauth2Approve>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Begin the OAuth2 authorization flow. When called without a session, the
        /// user is redirected to the consent screen without grant ID. When called with
        /// a session, the redirect URL includes param for grant ID. You can pass
        /// Accept header of `application/json` to receive a JSON response instead of a
        /// redirect.
        /// </para>
        /// </summary>
        public UniTask<Models.Oauth2Authorize> Authorize(string projectId, string clientId, string redirectUri, string responseType, string scope, string? state = null, string? nonce = null, string? codeChallenge = null, string? codeChallengeMethod = null, string? prompt = null, long? maxAge = null, string? authorizationDetails = null)
        {
            var apiPath = "/oauth2/{project_id}/authorize"
                .Replace("{project_id}", projectId);
            apiPath += "?project=" + Uri.EscapeDataString(_client.GetConfig("project"));


            var apiParameters = new Dictionary<string, object?>()
            {
                { "client_id", clientId },
                { "redirect_uri", redirectUri },
                { "response_type", responseType },
                { "scope", scope },
                { "state", state },
                { "nonce", nonce },
                { "code_challenge", codeChallenge },
                { "code_challenge_method", codeChallengeMethod },
                { "prompt", prompt },
                { "max_age", maxAge },
                { "authorization_details", authorizationDetails }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.Oauth2Authorize Convert(Dictionary<string, object> it) =>
                Models.Oauth2Authorize.From(map: it);

            return _client.Call<Models.Oauth2Authorize>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Exchange a device flow user code for an OAuth2 grant. The authenticated
        /// user is bound to the pending grant. Pass the returned grant ID to the get
        /// grant endpoint to render the consent screen, then to the approve or reject
        /// endpoint to complete the flow.
        /// </para>
        /// </summary>
        public UniTask<Models.Oauth2Grant> CreateGrant(string projectId, string userCode)
        {
            var apiPath = "/oauth2/{project_id}/grants"
                .Replace("{project_id}", projectId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "user_code", userCode }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" }
            };


            static Models.Oauth2Grant Convert(Dictionary<string, object> it) =>
                Models.Oauth2Grant.From(map: it);

            return _client.Call<Models.Oauth2Grant>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get an OAuth2 grant by its ID. Used by the consent screen to display the
        /// details of the authorization the user is being asked to approve. A grant
        /// can only be read by the user it belongs to, or by server SDK.
        /// </para>
        /// </summary>
        public UniTask<Models.Oauth2Grant> GetGrant(string projectId, string grantId)
        {
            var apiPath = "/oauth2/{project_id}/grants/{grant_id}"
                .Replace("{project_id}", projectId)
                .Replace("{grant_id}", grantId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") }
            };


            static Models.Oauth2Grant Convert(Dictionary<string, object> it) =>
                Models.Oauth2Grant.From(map: it);

            return _client.Call<Models.Oauth2Grant>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Reject an OAuth2 grant when the user denies consent. Returns the
        /// `redirectUrl` the end user should be sent to with an `access_denied` error.
        /// You can pass Accept header of `application/json` to receive a JSON response
        /// instead of a redirect.
        /// </para>
        /// </summary>
        public UniTask<Models.Oauth2Reject> Reject(string projectId, string grantId)
        {
            var apiPath = "/oauth2/{project_id}/reject"
                .Replace("{project_id}", projectId);
            apiPath += "?project=" + Uri.EscapeDataString(_client.GetConfig("project"));


            var apiParameters = new Dictionary<string, object?>()
            {
                { "grant_id", grantId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Oauth2Reject Convert(Dictionary<string, object> it) =>
                Models.Oauth2Reject.From(map: it);

            return _client.Call<Models.Oauth2Reject>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

    }
}
#endif