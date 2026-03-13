/*
 * Copyright 2025 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      https://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Text.Json;
using System.Text.Json.Nodes;

namespace Google.GenAI
{

  /// <summary>
  /// Common utility methods for the GenAI SDK to work with JSON.
  /// </summary>
  // TODO(b/413510963): make this method internal to only be used in converters.
  public static class Common
  {
    /// <summary>
    /// Sets the value of an object by a path.
    ///
    /// <para>Common.SetValueByPath(containerJsonObject, new string[]{"secondMember", "childMember"}, 42);</para>
    /// </summary>
    // TODO(b/413510963): make this method internal to only be used in converters.
    public static void SetValueByPath(JsonObject jsonObject, string[] path, object value)
    {
      if (path == null || path.Length == 0)
      {
        throw new ArgumentException("Path cannot be empty.");
      }
      if (jsonObject == null)
      {
        throw new ArgumentException("JsonObject cannot be null.");
      }

      JsonObject currentObject = jsonObject;
      for (int i = 0; i < path.Length - 1; i++)
      {
        string key = path[i];

        if (key.EndsWith("[]"))
        {
          string keyName = key.Substring(0, key.Length - 2);
          if (!currentObject.ContainsKey(keyName))
          {
            currentObject[keyName] = new JsonArray();
          }
          JsonArray arrayNode = (JsonArray)currentObject[keyName];
          if (value is System.Collections.IList listValue)
          {
            if (arrayNode.Count != listValue.Count)
            {
              arrayNode.Clear();
              for (int j = 0; j < listValue.Count; j++)
              {
                arrayNode.Add(new JsonObject());
              }
            }
            for (int j = 0; j < arrayNode.Count; j++)
            {
              SetValueByPath(
                  (JsonObject)arrayNode[j],
                  path.Skip(i + 1).ToArray(),
                  listValue[j]);
            }
          }
          else
          {
            if (arrayNode.Count == 0)
            {
              arrayNode.Add(new JsonObject());
            }
            for (int j = 0; j < arrayNode.Count; j++)
            {
              SetValueByPath(
                  (JsonObject)arrayNode[j], path.Skip(i + 1).ToArray(), value);
            }
          }
          return;
        }
        else if (key.EndsWith("[0]"))
        {
          string keyName = key.Substring(0, key.Length - 3);
          if (!currentObject.ContainsKey(keyName))
          {
            currentObject[keyName] = new JsonArray(new[] { (JsonNode)new JsonObject() });
          }
          currentObject = (JsonObject)((JsonArray)currentObject[keyName])[0];
        }
        else
        {
          if (!currentObject.ContainsKey(key))
          {
            currentObject[key] = new JsonObject();
          }
          currentObject = (JsonObject)currentObject[key];
        }
      }

      string finalKey = path[path.Length - 1];
      if (finalKey.Equals("_self") && value is JsonObject selfNode)
      {
          foreach (var property in selfNode.ToList())
          {
              currentObject[property.Key] = property.Value == null ? null : JsonNode.Parse(property.Value.ToJsonString());
          }
          return;
      }
      JsonNode? newNode = ToJsonNode(value);

      if (currentObject.ContainsKey(finalKey) && currentObject[finalKey] is JsonObject existingObject && newNode is JsonObject newObject)
      {
          foreach (KeyValuePair<string, JsonNode?> property in newObject)
          {
              existingObject[property.Key] = property.Value == null ? null : JsonNode.Parse(property.Value.ToJsonString());
          }
      }
      else if(currentObject.ContainsKey(finalKey) && IsZero(value))
      {
          return;
      }
      else
      {
          currentObject[finalKey] = newNode;
      }
    }

    /// <summary>
    /// Gets the value of an object by a path.
    ///
    /// <para>Common.GetValueByPath(containerJsonNode, new string[]{"secondMember", "childMember"})</para>
    /// </summary>
    // TODO(b/413510963): make this method internal to only be used in converters.
    public static JsonNode? GetValueByPath(JsonNode obj, string[] keys)
    {
      if (obj == null || keys == null)
      {
        return null;
      }
      if (keys.Length == 1 && keys[0].Equals("_self"))
      {
        return obj;
      }

      JsonNode? currentObject = obj;
      for (int i = 0; i < keys.Length; i++)
      {
        string key = keys[i];

        if (currentObject == null)
        {
          return null;
        }

        if (key.EndsWith("[]"))
        {
          string keyName = key.Substring(0, key.Length - 2);
          if (currentObject is JsonObject objNode
              && objNode.ContainsKey(keyName)
              && objNode[keyName] is JsonArray arrayNode)
          {
            if (keys.Length - 1 == i)
            {
              return arrayNode;
            }
            JsonArray result = new JsonArray();
            foreach (JsonNode? element in arrayNode)
            {
              JsonNode? node =
                  GetValueByPath(element, keys.Skip(i + 1).ToArray());
              if (node != null)
              {
                result.Add(JsonNode.Parse(node.ToJsonString()));
              }
            }
            return result;
          }
          else
          {
            return null;
          }
        }
        else if (key.EndsWith("[0]"))
        {
          string keyName = key.Substring(0, key.Length - 3);
          if (currentObject is JsonObject objNode
              && objNode.ContainsKey(keyName)
              && objNode[keyName] is JsonArray arrayNode
              && arrayNode.Count > 0)
          {
            currentObject = arrayNode[0];
          }
          else
          {
            return null;
          }
        }
        else
        {
          if (currentObject is JsonObject objNode && objNode.ContainsKey(key))
          {
            currentObject = objNode[key];
          }
          else
          {
            return null;
          }
        }
      }

      return currentObject;
    }

    internal static string FormatQuery(JsonObject queryParams)
    {
      var queryParts = new List<string>();
      foreach (var param in queryParams)
      {
        if (param.Value != null)
        {
          queryParts.Add($"{param.Key}={Uri.EscapeDataString(param.Value.ToString())}");
        }
      }
      return string.Join("&", queryParts);
    }

    internal static string FormatMap(string template, JsonNode? data)
    {
      if (data is not JsonObject jsonObject)
      {
        return template;
      }

      foreach (var field in jsonObject)
      {
        string key = field.Key;
        string placeholder = "{" + key + "}";
        if (template.Contains(placeholder))
        {
          template = template.Replace(placeholder, field.Value?.GetValue<string>() ?? string.Empty);
        }
      }
      return template;
    }

    /// <summary>
    /// Converts a JsonObject into a URL-encoded query string.
    /// </summary>
    /// <param name="paramsNode">The JsonObject containing the parameters to encode.</param>
    /// <returns>A URL-encoded string (e.g., "key1=value1&amp;key2=value2").</returns>
    internal static string UrlEncode(JsonObject? paramsNode)
    {
      if (paramsNode == null || paramsNode.Count == 0)
      {
        return string.Empty;
      }

      var queryParts = new List<string>();

      foreach (var field in paramsNode)
      {
        string encodedKey = Uri.EscapeDataString(field.Key);
        var valueNode = field.Value;

        if (valueNode == null)
        {
          queryParts.Add($"{encodedKey}=");
        }
        else
        {
          string valueStr = valueNode.GetValueKind() == JsonValueKind.String
              ? valueNode.GetValue<string>()
              : valueNode.ToJsonString().Trim('"');
          // In Python (and replay files), "*" is encoded as "%2A" although it is not required.
          // So we keep the same behavior here.
          string encodedValue = Uri.EscapeDataString(valueStr).Replace("*", "%2A");
          queryParts.Add($"{encodedKey}={encodedValue}");
        }
      }

      return string.Join("&", queryParts);
    }

    internal static bool IsZero(object? obj)
    {
      if (obj == null)
      {
        return true;
      }

      if (obj is int i)
      {
        return i == 0;
      }
      else if (obj is long l)
      {
        return l == 0L;
      }
      else if (obj is float f)
      {
        return f == 0.0f;
      }
      else if (obj is double d)
      {
        return d == 0.0;
      }
      else if (obj is char ch)
      {
        return ch == '\0';
      }
      else if (obj is bool b)
      {
        return !b;
      }
      else if (obj is System.Collections.ICollection c)
      {
        return c.Count == 0;
      }
      else if (obj is JsonArray a)
      {
        return a.Count == 0;
      }
      else if (obj is JsonObject jo)
      {
        return jo.Count == 0;
      }

      return false;
    }

    private static JsonNode? ToJsonNode(object value)
    {
      // TODO: evaluate using System.Text.Json to handle conversion of object to JSON.
      switch (value)
      {
        case null:
          return null;
        case string s:
          return JsonValue.Create(s);
        case int i:
          return JsonValue.Create(i);
        case long l:
          return JsonValue.Create(l);
        case double d:
          return JsonValue.Create(d);
        case bool b:
          return JsonValue.Create(b);
        case JsonNode node:
          return JsonNode.Parse(node.ToJsonString());
        case System.Collections.IEnumerable enumerable:
          JsonArray array = new JsonArray();
          foreach (var item in enumerable)
          {
            array.Add(ToJsonNode(item));
          }
          return array;
        default:
          return JsonNode.Parse(JsonSerializer.Serialize(value));
      }
    }

    /// <summary>
    /// Moves values from source paths to destination paths.
    /// <para>Example: MoveValueByPath( {'requests': [{'content': v1}, {'content': v2}]}, {'requests[].*': 'requests[].request.*'} ) -> {'requests': [{'request': {'content': v1}}, {'request': {'content': v2}}]}</para>
    /// </summary>
    public static void MoveValueByPath(JsonNode data, IDictionary<string, string> paths)
    {
        if (data == null || paths == null)
        {
            return;
        }

        foreach (KeyValuePair<string, string> entry in paths)
        {
            string sourcePath = entry.Key;
            string destPath = entry.Value;

            string[] sourceKeys = sourcePath.Split('.');
            string[] destKeys = destPath.Split('.');

            HashSet<string> excludeKeys = new HashSet<string>();
            int wildcardIdx = -1;

            for (int i = 0; i < sourceKeys.Length; i++)
            {
                if (sourceKeys[i].Equals("*"))
                {
                    wildcardIdx = i;
                    break;
                }
            }

            if (wildcardIdx != -1 && destKeys.Length > wildcardIdx)
            {
                // Extract the intermediate key between source and dest paths
                // Example: source=['requests[]', '*'], dest=['requests[]', 'request', '*']
                // We want to exclude 'request'
                for (int i = wildcardIdx; i < destKeys.Length; i++)
                {
                    string key = destKeys[i];
                    if (!key.Equals("*") && !key.EndsWith("[]") && !key.EndsWith("[0]"))
                    {
                        excludeKeys.Add(key);
                    }
                }
            }

            MoveValueRecursive(data, sourceKeys, destKeys, 0, excludeKeys);
        }
    }

    private static void MoveValueRecursive(
        JsonNode data,
        string[] sourceKeys,
        string[] destKeys,
        int keyIdx,
        HashSet<string> excludeKeys)
    {
        if (keyIdx >= sourceKeys.Length || data == null)
        {
            return;
        }

        string key = sourceKeys[keyIdx];

        if (key.EndsWith("[]"))
        {
            string keyName = key.Substring(0, key.Length - 2);
            if (data is JsonObject dataObj && dataObj.ContainsKey(keyName) && dataObj[keyName] is JsonArray arrayNode)
            {
                foreach (JsonNode item in arrayNode)
                {
                    MoveValueRecursive(item, sourceKeys, destKeys, keyIdx + 1, excludeKeys);
                }
            }
        }
        else if (key.Equals("*"))
        {
            if (data is JsonObject objectNode)
            {
                List<string> keysToMove = new List<string>();
                foreach (var property in objectNode)
                {
                    string fieldName = property.Key;
                    if (!fieldName.StartsWith("_") && !excludeKeys.Contains(fieldName))
                    {
                        keysToMove.Add(fieldName);
                    }
                }

                Dictionary<string, JsonNode> valuesToMove = new Dictionary<string, JsonNode>();
                foreach (string k in keysToMove)
                {
                    valuesToMove.Add(k, objectNode[k]);
                }

                foreach (KeyValuePair<string, JsonNode> valueEntry in valuesToMove)
                {
                    string k = valueEntry.Key;
                    JsonNode v = valueEntry.Value;

                    List<string> newDestKeysList = new List<string>();
                    for (int i = keyIdx; i < destKeys.Length; i++)
                    {
                        string dk = destKeys[i];
                        if (dk.Equals("*"))
                        {
                            newDestKeysList.Add(k);
                        }
                        else
                        {
                            newDestKeysList.Add(dk);
                        }
                    }

                    string[] newDestKeys = newDestKeysList.ToArray();
                    SetValueByPath(objectNode, newDestKeys, v);
                }

                foreach (string k in keysToMove)
                {
                    objectNode.Remove(k);
                }
            }
        }
        else
        {
            if (data is JsonObject dataObj && dataObj.ContainsKey(key))
            {
                JsonNode nextNode = dataObj[key];
                MoveValueRecursive(nextNode, sourceKeys, destKeys, keyIdx + 1, excludeKeys);
            }
        }
    }
  }
}
