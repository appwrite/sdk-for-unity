#if UNI_TASK
using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Appwrite.Models;

namespace Appwrite.Services
{
    public class Locale : Service
    {
        public Locale(Client client) : base(client)
        {
        }

        /// <summary>
        /// <para>
        /// Get the current user location based on IP. Returns an object with user
        /// country code, country name, continent name, continent code, ip address and
        /// suggested currency. You can use the locale header to get the data in a
        /// supported language.
        /// 
        /// ([IP Geolocation by DB-IP](https://db-ip.com))
        /// </para>
        /// </summary>
        public UniTask<Models.Locale> Get()
        {
            var apiPath = "/locale";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.Locale Convert(Dictionary<string, object> it) =>
                Models.Locale.From(map: it);

            return _client.Call<Models.Locale>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List of all locale codes in [ISO
        /// 639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes).
        /// </para>
        /// </summary>
        public UniTask<Models.LocaleCodeList> ListCodes()
        {
            var apiPath = "/locale/codes";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.LocaleCodeList Convert(Dictionary<string, object> it) =>
                Models.LocaleCodeList.From(map: it);

            return _client.Call<Models.LocaleCodeList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List of all continents. You can use the locale header to get the data in a
        /// supported language.
        /// </para>
        /// </summary>
        public UniTask<Models.ContinentList> ListContinents()
        {
            var apiPath = "/locale/continents";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.ContinentList Convert(Dictionary<string, object> it) =>
                Models.ContinentList.From(map: it);

            return _client.Call<Models.ContinentList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List of all countries. You can use the locale header to get the data in a
        /// supported language.
        /// </para>
        /// </summary>
        public UniTask<Models.CountryList> ListCountries()
        {
            var apiPath = "/locale/countries";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.CountryList Convert(Dictionary<string, object> it) =>
                Models.CountryList.From(map: it);

            return _client.Call<Models.CountryList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List of all countries that are currently members of the EU. You can use the
        /// locale header to get the data in a supported language.
        /// </para>
        /// </summary>
        public UniTask<Models.CountryList> ListCountriesEU()
        {
            var apiPath = "/locale/countries/eu";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.CountryList Convert(Dictionary<string, object> it) =>
                Models.CountryList.From(map: it);

            return _client.Call<Models.CountryList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List of all countries phone codes. You can use the locale header to get the
        /// data in a supported language.
        /// </para>
        /// </summary>
        public UniTask<Models.PhoneList> ListCountriesPhones()
        {
            var apiPath = "/locale/countries/phones";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.PhoneList Convert(Dictionary<string, object> it) =>
                Models.PhoneList.From(map: it);

            return _client.Call<Models.PhoneList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List of all currencies, including currency symbol, name, plural, and
        /// decimal digits for all major and minor currencies. You can use the locale
        /// header to get the data in a supported language.
        /// </para>
        /// </summary>
        public UniTask<Models.CurrencyList> ListCurrencies()
        {
            var apiPath = "/locale/currencies";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.CurrencyList Convert(Dictionary<string, object> it) =>
                Models.CurrencyList.From(map: it);

            return _client.Call<Models.CurrencyList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

        /// <summary>
        /// <para>
        /// List of all languages classified by ISO 639-1 including 2-letter code, name
        /// in English, and name in the respective language.
        /// </para>
        /// </summary>
        public UniTask<Models.LanguageList> ListLanguages()
        {
            var apiPath = "/locale/languages";

            var apiParameters = new Dictionary<string, object?>()
            {
            };

            var apiHeaders = new Dictionary<string, string>()
            {
            };


            static Models.LanguageList Convert(Dictionary<string, object> it) =>
                Models.LanguageList.From(map: it);

            return _client.Call<Models.LanguageList>(
                method: "GET",
                path: apiPath,
                headers: apiHeaders,
                parameters: apiParameters.Where(it => it.Value != null).ToDictionary(it => it.Key, it => it.Value)!,
                convert: Convert);

        }

    }
}
#endif