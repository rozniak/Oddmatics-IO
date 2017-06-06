/**
 * Oddmatics.Util.Web.HttpUtilityEx -- HTTP Utility Extensions
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System.Collections.Specialized;
using System.Web;

namespace Oddmatics.Util.Web
{
    /// <summary>
    /// Provides additional functions for HTTP as an extension of the HttpUtility class.
    /// </summary>
    public static class HttpUtilityEx
    {
        /// <summary>
        /// Parses a query string into a NameValueCollection using System.Text.Encoding.UTF8 encoding, with all keys as lowercase.
        /// </summary>
        /// <param name="query">The query string to parse.</param>
        /// <returns>A NameValueCollection of query parameters in lowercase and their values.</returns>
        public static NameValueCollection InsensitiveParseQuery(string query)
        {
            NameValueCollection queries = HttpUtility.ParseQueryString(query.ToLower());
            NameValueCollection origQueries = HttpUtility.ParseQueryString(query);

            foreach (string key in origQueries.AllKeys)
            {
                queries[key.ToLower()] = origQueries[key];
            }

            return queries;
        }
    }
}
