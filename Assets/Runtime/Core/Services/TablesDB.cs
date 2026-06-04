#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class TablesDB : Service
    {
        public TablesDB(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// List transactions across all databases.
        /// </para>
        /// </summary>
        public UniTask<Models.TransactionList> ListTransactions(List<string>? queries = null)
        {
            var apiPath = "/tablesdb/transactions";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.TransactionList Convert(Dictionary<string, object> it) =>
                Models.TransactionList.From(map: it);

            return _client.Call<Models.TransactionList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Create a new transaction.
        /// </para>
        /// </summary>
        public UniTask<Models.Transaction> CreateTransaction(long? ttl = null)
        {
            var apiPath = "/tablesdb/transactions";

            var apiParameters = new Dictionary<string, object?>()
            {
                { "ttl", ttl }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Transaction Convert(Dictionary<string, object> it) =>
                Models.Transaction.From(map: it);

            return _client.Call<Models.Transaction>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get a transaction by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<Models.Transaction> GetTransaction(string transactionId)
        {
            var apiPath = "/tablesdb/transactions/{transactionId}"
                .Replace("{transactionId}", transactionId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.Transaction Convert(Dictionary<string, object> it) =>
                Models.Transaction.From(map: it);

            return _client.Call<Models.Transaction>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Update a transaction, to either commit or roll back its operations.
        /// </para>
        /// </summary>
        public UniTask<Models.Transaction> UpdateTransaction(string transactionId, bool? commit = null, bool? rollback = null)
        {
            var apiPath = "/tablesdb/transactions/{transactionId}"
                .Replace("{transactionId}", transactionId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "commit", commit },
                { "rollback", rollback }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Transaction Convert(Dictionary<string, object> it) =>
                Models.Transaction.From(map: it);

            return _client.Call<Models.Transaction>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Delete a transaction by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteTransaction(string transactionId)
        {
            var apiPath = "/tablesdb/transactions/{transactionId}"
                .Replace("{transactionId}", transactionId);

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
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
        /// Create multiple operations in a single transaction.
        /// </para>
        /// </summary>
        public UniTask<Models.Transaction> CreateOperations(string transactionId, List<object>? operations = null)
        {
            var apiPath = "/tablesdb/transactions/{transactionId}/operations"
                .Replace("{transactionId}", transactionId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "operations", operations }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Transaction Convert(Dictionary<string, object> it) =>
                Models.Transaction.From(map: it);

            return _client.Call<Models.Transaction>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get a list of all the user's rows in a given table. You can use the query
        /// params to filter your results.
        /// </para>
        /// </summary>
        public UniTask<Models.RowList> ListRows(string databaseId, string tableId, List<string>? queries = null, string? transactionId = null, bool? total = null, long? ttl = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries },
                { "transactionId", transactionId },
                { "total", total },
                { "ttl", ttl }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.RowList Convert(Dictionary<string, object> it) =>
                Models.RowList.From(map: it);

            return _client.Call<Models.RowList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Create a new Row. Before using this route, you should create a new table
        /// resource using either a [server
        /// integration](https://appwrite.io/docs/references/cloud/server-dart/tablesDB#createTable)
        /// API or directly from your database console.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> CreateRow(string databaseId, string tableId, string rowId, object data, List<string>? permissions = null, string? transactionId = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "rowId", rowId },
                { "data", data },
                { "permissions", permissions },
                { "transactionId", transactionId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "POST",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Get a row by its unique ID. This endpoint response returns a JSON object
        /// with the row data.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> GetRow(string databaseId, string tableId, string rowId, List<string>? queries = null, string? transactionId = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "queries", queries },
                { "transactionId", transactionId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Create or update a Row. Before using this route, you should create a new
        /// table resource using either a [server
        /// integration](https://appwrite.io/docs/references/cloud/server-dart/tablesDB#createTable)
        /// API or directly from your database console.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> UpsertRow(string databaseId, string tableId, string rowId, object? data = null, List<string>? permissions = null, string? transactionId = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "data", data },
                { "permissions", permissions },
                { "transactionId", transactionId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PUT",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Update a row by its unique ID. Using the patch method you can pass only
        /// specific fields that will get updated.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> UpdateRow(string databaseId, string tableId, string rowId, object? data = null, List<string>? permissions = null, string? transactionId = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "data", data },
                { "permissions", permissions },
                { "transactionId", transactionId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Delete a row by its unique ID.
        /// </para>
        /// </summary>
        public UniTask<object> DeleteRow(string databaseId, string tableId, string rowId, string? transactionId = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "transactionId", transactionId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
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
        /// Decrement a specific column of a row by a given value.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> DecrementRowColumn(string databaseId, string tableId, string rowId, string column, double? @value = null, double? min = null, string? transactionId = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}/{column}/decrement"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId)
                .Replace("{column}", column);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "value", @value },
                { "min", min },
                { "transactionId", transactionId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// Increment a specific column of a row by a given value.
        /// </para>
        /// </summary>
        public UniTask<Models.Row> IncrementRowColumn(string databaseId, string tableId, string rowId, string column, double? @value = null, double? max = null, string? transactionId = null)
        {
            var apiPath = "/tablesdb/{databaseId}/tables/{tableId}/rows/{rowId}/{column}/increment"
                .Replace("{databaseId}", databaseId)
                .Replace("{tableId}", tableId)
                .Replace("{rowId}", rowId)
                .Replace("{column}", column);

            var apiParameters = new Dictionary<string, object?>()
            {
                { "value", @value },
                { "max", max },
                { "transactionId", transactionId }
            };

            var apiHeaders = new Dictionary<string, string>()
            {
                { "content-type", "application/json" }
            };


            static Models.Row Convert(Dictionary<string, object> it) =>
                Models.Row.From(map: it);

            return _client.Call<Models.Row>(
                method: "PATCH",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

    }
}
#endif