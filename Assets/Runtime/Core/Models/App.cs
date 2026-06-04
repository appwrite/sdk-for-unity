
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Appwrite.Enums;
using Appwrite.Extensions;

namespace Appwrite.Models
{
    public class App
    {
        [JsonPropertyName("$id")]
        public string Id { get; private set; }

        [JsonPropertyName("$createdAt")]
        public string CreatedAt { get; private set; }

        [JsonPropertyName("$updatedAt")]
        public string UpdatedAt { get; private set; }

        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("redirectUris")]
        public List<string> RedirectUris { get; private set; }

        [JsonPropertyName("internal")]
        public bool Internal { get; private set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; private set; }

        [JsonPropertyName("type")]
        public string Type { get; private set; }

        [JsonPropertyName("teamId")]
        public string TeamId { get; private set; }

        [JsonPropertyName("userId")]
        public string UserId { get; private set; }

        [JsonPropertyName("secrets")]
        public List<AppSecret> Secrets { get; private set; }

        public App(
            string id,
            string createdAt,
            string updatedAt,
            string name,
            List<string> redirectUris,
            bool @internal,
            bool enabled,
            string type,
            string teamId,
            string userId,
            List<AppSecret> secrets
        )
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Name = name;
            RedirectUris = redirectUris;
            Internal = @internal;
            Enabled = enabled;
            Type = type;
            TeamId = teamId;
            UserId = userId;
            Secrets = secrets;
        }

        public static App From(Dictionary<string, object> map) => new App(
            id: map["$id"].ToString(),
            createdAt: map["$createdAt"].ToString(),
            updatedAt: map["$updatedAt"].ToString(),
            name: map["name"].ToString(),
            redirectUris: map["redirectUris"].ConvertToList<string>(),
            @internal: (bool)map["internal"],
            enabled: (bool)map["enabled"],
            type: map["type"].ToString(),
            teamId: map["teamId"].ToString(),
            userId: map["userId"].ToString(),
            secrets: map["secrets"].ConvertToList<Dictionary<string, object>>().Select(it => Appwrite.Models.AppSecret.From(map: it)).ToList()
        );

        public Dictionary<string, object?> ToMap() => new Dictionary<string, object?>()
        {
            { "$id", Id },
            { "$createdAt", CreatedAt },
            { "$updatedAt", UpdatedAt },
            { "name", Name },
            { "redirectUris", RedirectUris },
            { "internal", Internal },
            { "enabled", Enabled },
            { "type", Type },
            { "teamId", TeamId },
            { "userId", UserId },
            { "secrets", Secrets?.Select(it => it.ToMap()).ToList() }
        };
    }
}
