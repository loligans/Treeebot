using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Treeebot.Clients.Extensions
{
    /// <summary>
    /// Provides useful extensions for typed <see cref="HttpClient"/>'s
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Sends a GET request to the specified <paramref name="route"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type to use as the response model.</typeparam>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        public static async Task<HttpResponseMessage> GetAsync(
            this HttpClient httpClient,
            string route,
            CancellationToken cancellationToken = default)
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            return await httpClient
                .GetAsync(route, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a GET request to the specified <paramref name="route"/> and maps the result to a <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type to use as the response model.</typeparam>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        public static async Task<TResponse?> GetAsync<TResponse>(
            this HttpClient httpClient, 
            string route, 
            CancellationToken cancellationToken = default) 
            where TResponse : class
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            var httpResponseMessage = await httpClient
                .GetAsync(route, cancellationToken)
                .ConfigureAwait(false);

            return await httpResponseMessage
                .ParseAsync<TResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a POST request to the specified <paramref name="route"/> with the specified <typeparamref name="TBody"/>.
        /// </summary>
        /// <typeparam name="TBody">The type to use as the request body.</typeparam>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        /// <param name="content">The body of the request</param>
        public static async Task<HttpResponseMessage> PostAsync<TBody>(
            this HttpClient httpClient,
            string route,
            TBody content,
            CancellationToken cancellationToken = default)
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            using var stringContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(
                    route,
                    stringContent,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a POST request to the specified <paramref name="route"/> with the specified <typeparamref name="TBody"/>
        /// and maps the result to a <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TBody">The type to use as the request body.</typeparam>
        /// <typeparam name="TResponse">The type to use as the response model.</typeparam>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        /// <param name="content">The body of the request</param>
        public static async Task<TResponse?> PostAsync<TBody, TResponse>(
            this HttpClient httpClient,
            string route,
            TBody content,
            CancellationToken cancellationToken = default) 
            where TResponse : class
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            using var stringContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            using var httpResponseMessage = await httpClient.PostAsync(
                    route,
                    stringContent,
                    cancellationToken)
                .ConfigureAwait(false);

            return await httpResponseMessage.ParseAsync<TResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a PUT request to the specified <paramref name="route"/> with the specified <typeparamref name="TBody"/>
        /// </summary>
        /// <typeparam name="TBody">The type to use as the request body.</typeparam>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        /// <param name="content">The body of the request</param>
        public static async Task<HttpResponseMessage> PutAsync<TBody>(
            this HttpClient httpClient,
            string route,
            TBody content,
            CancellationToken cancellationToken = default)
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            using var stringContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            return await httpClient
                .PutAsync(route, stringContent, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a PUT request to the specified <paramref name="route"/> with the specified <typeparamref name="TBody"/>
        /// and maps the result to a <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TBody">The type to use as the request body.</typeparam>
        /// <typeparam name="TResponse">The type to use as the response model.</typeparam>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        /// <param name="content">The body of the request</param>
        public static async Task<TResponse?> PutAsync<TBody, TResponse>(
            this HttpClient httpClient,
            string route,
            TBody content,
            CancellationToken cancellationToken = default) where TResponse: class
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            using var stringContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            using var httpResponseMessage = await httpClient
                .PutAsync(route, stringContent, cancellationToken)
                .ConfigureAwait(false);

            return await httpResponseMessage
                .ParseAsync<TResponse>()
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a DELETE request to the specified <paramref name="route"/>.
        /// </summary>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        public static async Task<HttpResponseMessage> DeleteAsync(
            this HttpClient httpClient,
            string route,
            CancellationToken cancellationToken = default)
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            return await httpClient
                .DeleteAsync(route, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Sends a DELETE request to the specified <paramref name="route"/> and maps the result to a <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type to use as the response model.</typeparam>
        /// <param name="route">The path relative to the <see cref="HttpClient.BaseAddress"/></param>
        public static async Task<TResponse?> DeleteAsync<TResponse>(
            this HttpClient httpClient,
            string route,
            CancellationToken cancellationToken = default) where TResponse: class
        {
            if (httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }

            using var httpResponseMessage = await httpClient
                .DeleteAsync(route, cancellationToken)
                .ConfigureAwait(false);

            return await httpResponseMessage
                .ParseAsync<TResponse>()
                .ConfigureAwait(false);
        }
    }
}
