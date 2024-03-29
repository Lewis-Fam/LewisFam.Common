﻿/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LewisFam.Http
{
    internal sealed class HttpClient : System.Net.Http.HttpClient
    {
        private readonly System.Net.Http.HttpClient _client;

        private readonly IList<KeyValuePair<string, string>> _headers;

        public HttpClient() : base()
        {
            _client = new System.Net.Http.HttpClient();
        }

        public HttpClient(IList<KeyValuePair<string, string>> customHeaders) : this()
        {
            _headers = customHeaders ?? throw new ArgumentNullException(nameof(customHeaders));
            setCustomHeaders();
        }

        public async Task<T> GetAsync<T>(Uri uri) where T : new()
        {
            using var request = await _client.GetAsync(uri);
            var strg = await request.Content.ReadAsStringAsync();
            return JToken.Parse(strg).ToObject<T>();
        }

        public async Task<string> GetJsonAsync(Uri uri, string selectToken = "", Formatting format = Formatting.None)
        {
            try
            {
                //await Task.CompletedTask;
                var strg = await _client.GetStringAsync(uri);
                var json = JToken.Parse(strg).SelectToken(selectToken);
                return json?.ToString(format);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                throw;
            }
            finally
            {
                //_client?.Dispose();
            }
        }

        public async Task<byte[]> ReadAsByteArrayAsync(Uri uri)
        {
            using var request = await _client.GetAsync(uri);
            return await request.Content.ReadAsByteArrayAsync();
        }

        public async Task<Stream> ReadAsStreamAsync(Uri uri)
        {
            using var request = await _client.GetAsync(uri);
            return await request.Content.ReadAsStreamAsync();
        }

        public async Task<string> ReadAsStringAsync(Uri uri)
        {
            using var request = await _client.GetAsync(uri);
            return await request.Content.ReadAsStringAsync();
        }

        ///<inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _client?.Dispose();    
            }
        }

        private void setCustomHeaders()
        {
            for (var i = 0; i < _headers.Count - 1; i++)
            {
                Debug.Assert(_client.DefaultRequestHeaders != null, "_client.DefaultRequestHeaders != null");
                _client.DefaultRequestHeaders.Add(_headers[i].Key, _headers[i].Value);
            }
        }

        public void AddTokenHeader(string token)
        {
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue();
        }
    }
}