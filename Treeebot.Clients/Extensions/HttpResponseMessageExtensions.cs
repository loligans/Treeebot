using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Treeebot.Clients.Extensions
{
    /// <summary>
    /// Provides useful extensions for <see cref="HttpResponseMessage"/>'s
    /// </summary>
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Parses an <see cref="HttpResponseMessage"/> into the specified <typeparamref name="TResponse"/>
        /// </summary>
        /// <typeparam name="TResponse">The data type to deserialize the <see cref="HttpResponseMessage.Content"/> into.</typeparam>
        public static async Task<TResponse?> ParseAsync<TResponse>(this HttpResponseMessage response) 
            where TResponse : class
        {
            if (response == null) { throw new ArgumentNullException(nameof(response)); }

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false) ?? string.Empty;

            if (string.IsNullOrWhiteSpace(responseBody)) { return default; }

            return JsonSerializer.Deserialize<TResponse?>(responseBody);
        }
    }
}
