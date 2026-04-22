// Copyright 2025 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Google.GenAI.Interactions.Core;

public abstract record class ParamsBase
{
    static readonly IReadOnlyDictionary<string, string> defaultHeaders;

    static ParamsBase()
    {
        defaultHeaders = new Dictionary<string, string> { ["User-Agent"] = GetUserAgent() };
    }

    private protected JsonDictionary _rawQueryData = new();

    private protected JsonDictionary _rawHeaderData = new();

    protected ParamsBase(ParamsBase paramsBase)
    {
        this._rawHeaderData = new(paramsBase._rawHeaderData);
        this._rawQueryData = new(paramsBase._rawQueryData);
    }

    public IReadOnlyDictionary<string, JsonElement> RawQueryData
    {
        get { return this._rawQueryData.Freeze(); }
    }

    public IReadOnlyDictionary<string, JsonElement> RawHeaderData
    {
        get { return this._rawHeaderData.Freeze(); }
    }

    public abstract Uri Url(ClientOptions options);

    protected static void AddQueryElementToCollection(
        NameValueCollection collection,
        string key,
        JsonElement element
    )
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
                collection.Add(key, "");
                break;
            case JsonValueKind.String:
            case JsonValueKind.Number:
                collection.Add(key, element.ToString());
                break;
            case JsonValueKind.True:
                collection.Add(key, "true");
                break;
            case JsonValueKind.False:
                collection.Add(key, "false");
                break;
            case JsonValueKind.Object:
                foreach (var item in element.EnumerateObject())
                {
                    AddQueryElementToCollection(
                        collection,
                        string.Format("{0}[{1}]", key, item.Name),
                        item.Value
                    );
                }
                break;
            case JsonValueKind.Array:
                collection.Add(
                    key,
                    string.Join(
                        ",",
                        Enumerable.Select(
                            element.EnumerateArray(),
                            x =>
                                x.ValueKind switch
                                {
                                    JsonValueKind.Null => "",
                                    JsonValueKind.True => "true",
                                    JsonValueKind.False => "false",
                                    _ => x.GetString(),
                                }
                        )
                    )
                );
                break;
        }
    }

    protected static void AddHeaderElementToRequest(
        HttpRequestMessage request,
        string key,
        JsonElement element
    )
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
                request.Headers.Add(key, "");
                break;
            case JsonValueKind.String:
            case JsonValueKind.Number:
                request.Headers.Add(key, element.ToString());
                break;
            case JsonValueKind.True:
                request.Headers.Add(key, "true");
                break;
            case JsonValueKind.False:
                request.Headers.Add(key, "false");
                break;
            case JsonValueKind.Object:
                foreach (var item in element.EnumerateObject())
                {
                    AddHeaderElementToRequest(
                        request,
                        string.Format("{0}.{1}", key, item.Name),
                        item.Value
                    );
                }
                break;
            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                {
                    request.Headers.Add(
                        key,
                        item.ValueKind switch
                        {
                            JsonValueKind.Null => "",
                            JsonValueKind.True => "true",
                            JsonValueKind.False => "false",
                            _ => item.GetString(),
                        }
                    );
                }
                break;
        }
    }

    internal string QueryString(ClientOptions options)
    {
        NameValueCollection collection = new();
        foreach (var item in this.RawQueryData)
        {
            ParamsBase.AddQueryElementToCollection(collection, item.Key, item.Value);
        }
        StringBuilder sb = new();
        bool first = true;
        foreach (var key in collection.AllKeys)
        {
            foreach (var value in collection.GetValues(key) ?? Enumerable.Empty<string>())
            {
                if (!first)
                {
                    sb.Append('&');
                }
                first = false;
                sb.Append(HttpUtility.UrlEncode(key));
                sb.Append('=');
                sb.Append(HttpUtility.UrlEncode(value));
            }
        }
        return sb.ToString();
    }

    internal abstract void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options);

    internal virtual HttpContent? BodyContent()
    {
        return null;
    }

    internal static void AddDefaultHeaders(HttpRequestMessage request, ClientOptions options)
    {
        foreach (var header in defaultHeaders)
        {
            request.Headers.Add(header.Key, header.Value);
        }

        if (options.ApiKey != null)
        {
            request.Headers.Add("x-goog-api-key", options.ApiKey);
        }
    }

    static string GetUserAgent() =>
        $"{typeof(GeminiNextGenApiClient).Name}/C# {GetPackageVersion()}";

    static string GetPackageVersion() =>
        Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion
        ?? "unknown";
}
