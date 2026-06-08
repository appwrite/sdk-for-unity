#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Graphql : Service
    {
        public Graphql(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// Execute a GraphQL mutation.
        /// </para>
        /// </summary>
        public UniTask<object> Query(object query)
        {
            var apiPath = "/graphql";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "query", query }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "x-sdk-graphql", "true" },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static object Convert(Dictionary<string, object> it) =>
                it;

            return _client.Call<object>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Execute a GraphQL mutation.
        /// </para>
        /// </summary>
        public UniTask<object> Mutation(object query)
        {
            var apiPath = "/graphql/mutation";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "query", query }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "X-Appwrite-Project", _client.GetConfig("project") },
                { "x-sdk-graphql", "true" },
                { "content-type", "application/json" },
                { "accept", "application/json" }
            };


            static object Convert(Dictionary<string, object> it) =>
                it;

            return _client.Call<object>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

    }
}
#endif