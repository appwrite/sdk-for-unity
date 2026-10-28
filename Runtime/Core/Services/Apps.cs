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
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
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
        public UniTask<Models.App> Create(string appId, string name, List<string> redirectUris, string? description = null, string? clientUri = null, string? logoUri = null, string? privacyPolicyUrl = null, string? termsUrl = null, List<string>? contacts = null, string? tagline = null, List<string>? tags = null, List<string>? images = null, string? supportUrl = null, string? dataDeletionUrl = null, List<string>? postLogoutRedirectUris = null, bool? enabled = null, string? type = null, bool? deviceFlow = null, string? teamId = null)
        {
            var apiPath = "/apps";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "appId", appId },
                { "name", name },
                { "description", description },
                { "clientUri", clientUri },
                { "logoUri", logoUri },
                { "privacyPolicyUrl", privacyPolicyUrl },
                { "termsUrl", termsUrl },
                { "contacts", contacts },
                { "tagline", tagline },
                { "tags", tags },
                { "images", images },
                { "supportUrl", supportUrl },
                { "dataDeletionUrl", dataDeletionUrl },
                { "redirectUris", redirectUris },
                { "postLogoutRedirectUris", postLogoutRedirectUris },
                { "enabled", enabled },
                { "type", type },
                { "deviceFlow", deviceFlow },
                { "teamId", teamId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
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
        /// List scopes an application can request when installed on a team.
        /// </para>
        /// </summary>
        public UniTask<Models.AppScopeList> ListInstallationScopes()
        {
            var apiPath = "/apps/scopes/installations";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
            };


            static Models.AppScopeList Convert(Dictionary<string, object> it) =>
                Models.AppScopeList.From(map: it);

            return _client.Call<Models.AppScopeList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List scopes an application can request during the OAuth2 flow.
        /// </para>
        /// </summary>
        public UniTask<Models.AppScopeList> ListOAuth2Scopes()
        {
            var apiPath = "/apps/scopes/oauth2";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
            };


            static Models.AppScopeList Convert(Dictionary<string, object> it) =>
                Models.AppScopeList.From(map: it);

            return _client.Call<Models.AppScopeList>(
                method: "GET",
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
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}"
                .Replace("{appId}", Client.EncodePath(appId));

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
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
        public UniTask<Models.App> Update(string appId, string name, string? description = null, string? clientUri = null, string? logoUri = null, string? privacyPolicyUrl = null, string? termsUrl = null, List<string>? contacts = null, string? tagline = null, List<string>? tags = null, List<string>? images = null, string? supportUrl = null, string? dataDeletionUrl = null, bool? enabled = null, List<string>? redirectUris = null, List<string>? postLogoutRedirectUris = null, string? type = null, bool? deviceFlow = null, List<string>? installationScopes = null, string? installationRedirectUrl = null)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}"
                .Replace("{appId}", Client.EncodePath(appId));

            var apiParameters = new Dictionary<string, object?>()
            {
                { "name", name },
                { "description", description },
                { "clientUri", clientUri },
                { "logoUri", logoUri },
                { "privacyPolicyUrl", privacyPolicyUrl },
                { "termsUrl", termsUrl },
                { "contacts", contacts },
                { "tagline", tagline },
                { "tags", tags },
                { "images", images },
                { "supportUrl", supportUrl },
                { "dataDeletionUrl", dataDeletionUrl },
                { "enabled", enabled },
                { "redirectUris", redirectUris },
                { "postLogoutRedirectUris", postLogoutRedirectUris },
                { "type", type },
                { "deviceFlow", deviceFlow },
                { "installationScopes", installationScopes },
                { "installationRedirectUrl", installationRedirectUrl }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
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
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}"
                .Replace("{appId}", Client.EncodePath(appId));

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

        /// <summary>
        /// <para>
        /// List installations of an application. Requires an app key sent in the
        /// `X-Appwrite-Key` header alongside the `X-Appwrite-App` header, or a caller
        /// with update access to the app.
        /// </para>
        /// </summary>
        public UniTask<Models.AppInstallationList> ListInstallations(string appId, List<string>? queries = null, bool? total = null)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}/installations"
                .Replace("{appId}", Client.EncodePath(appId));

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
        /// Get an installation of an application by its unique ID. Requires an app key
        /// sent in the `X-Appwrite-Key` header alongside the `X-Appwrite-App` header,
        /// or a caller with update access to the app.
        /// </para>
        /// </summary>
        public UniTask<Models.AppInstallation> GetInstallation(string appId, string installationId)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            if (installationId == "")
            {
                throw new AppwriteException("Missing required parameter: \"installationId\"");
            }

            var apiPath = "/apps/{appId}/installations/{installationId}"
                .Replace("{appId}", Client.EncodePath(appId))
                .Replace("{installationId}", Client.EncodePath(installationId));

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
        /// Delete an installation of an application by its unique ID. Requires a
        /// caller with update access to the app. Previously issued installation access
        /// tokens are revoked.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteInstallation(string appId, string installationId)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            if (installationId == "")
            {
                throw new AppwriteException("Missing required parameter: \"installationId\"");
            }

            var apiPath = "/apps/{appId}/installations/{installationId}"
                .Replace("{appId}", Client.EncodePath(appId))
                .Replace("{installationId}", Client.EncodePath(installationId));

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

        /// <summary>
        /// <para>
        /// Create a token for an installation of an application. Requires an app key
        /// sent in the `X-Appwrite-Key` header alongside the `X-Appwrite-App` header,
        /// or a caller with update access to the app. The returned token carries the
        /// scopes and authorization details granted to the installation, and can be
        /// used as an `Authorization: Bearer` header everywhere OAuth2 access tokens
        /// are accepted. Multiple tokens can be active for the same installation at
        /// once; each token stays valid until it expires or the installation is
        /// updated or deleted.
        /// </para>
        /// </summary>
        public UniTask<Models.Oauth2Token> CreateInstallationToken(string appId, string installationId)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            if (installationId == "")
            {
                throw new AppwriteException("Missing required parameter: \"installationId\"");
            }

            var apiPath = "/apps/{appId}/installations/{installationId}/tokens"
                .Replace("{appId}", Client.EncodePath(appId))
                .Replace("{installationId}", Client.EncodePath(installationId));

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static Models.Oauth2Token Convert(Dictionary<string, object> it) =>
                Models.Oauth2Token.From(map: it);

            return _client.Call<Models.Oauth2Token>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List app keys for an application.
        /// </para>
        /// </summary>
        public UniTask<Models.AppKeyList> ListKeys(string appId, List<string>? queries = null, bool? total = null)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}/keys"
                .Replace("{appId}", Client.EncodePath(appId));

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


            static Models.AppKeyList Convert(Dictionary<string, object> it) =>
                Models.AppKeyList.From(map: it);

            return _client.Call<Models.AppKeyList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Create a new app key for an application. App keys carry no scopes; send one
        /// in the `X-Appwrite-Key` header alongside the `X-Appwrite-App` header to
        /// list the application's installations and create installation access tokens.
        /// </para>
        /// </summary>
        public UniTask<Models.AppKey> CreateKey(string appId)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}/keys"
                .Replace("{appId}", Client.EncodePath(appId));

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static Models.AppKey Convert(Dictionary<string, object> it) =>
                Models.AppKey.From(map: it);

            return _client.Call<Models.AppKey>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get an app key by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.AppKey> GetKey(string appId, string keyId)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            if (keyId == "")
            {
                throw new AppwriteException("Missing required parameter: \"keyId\"");
            }

            var apiPath = "/apps/{appId}/keys/{keyId}"
                .Replace("{appId}", Client.EncodePath(appId))
                .Replace("{keyId}", Client.EncodePath(keyId));

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
            };


            static Models.AppKey Convert(Dictionary<string, object> it) =>
                Models.AppKey.From(map: it);

            return _client.Call<Models.AppKey>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Delete an app key by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteKey(string appId, string keyId)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            if (keyId == "")
            {
                throw new AppwriteException("Missing required parameter: \"keyId\"");
            }

            var apiPath = "/apps/{appId}/keys/{keyId}"
                .Replace("{appId}", Client.EncodePath(appId))
                .Replace("{keyId}", Client.EncodePath(keyId));

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

        /// <summary>
        /// <para>
        /// List client secrets for an application.
        /// </para>
        /// </summary>
        public UniTask<Models.AppSecretList> ListSecrets(string appId, List<string>? queries = null, bool? total = null)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}/secrets"
                .Replace("{appId}", Client.EncodePath(appId));

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
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}/secrets"
                .Replace("{appId}", Client.EncodePath(appId));

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
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
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            if (secretId == "")
            {
                throw new AppwriteException("Missing required parameter: \"secretId\"");
            }

            var apiPath = "/apps/{appId}/secrets/{secretId}"
                .Replace("{appId}", Client.EncodePath(appId))
                .Replace("{secretId}", Client.EncodePath(secretId));

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "accept", "application/json" }
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
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            if (secretId == "")
            {
                throw new AppwriteException("Missing required parameter: \"secretId\"");
            }

            var apiPath = "/apps/{appId}/secrets/{secretId}"
                .Replace("{appId}", Client.EncodePath(appId))
                .Replace("{secretId}", Client.EncodePath(secretId));

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

        /// <summary>
        /// <para>
        /// Transfer an application to another team by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.App> UpdateTeam(string appId, string teamId)
        {
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}/team"
                .Replace("{appId}", Client.EncodePath(appId));

            var apiParameters = new Dictionary<string, object?>()
            {
                { "teamId", teamId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "content-type", "application/json" },
                { "accept", "application/json" }
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
            if (appId == "")
            {
                throw new AppwriteException("Missing required parameter: \"appId\"");
            }

            var apiPath = "/apps/{appId}/tokens"
                .Replace("{appId}", Client.EncodePath(appId));

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
