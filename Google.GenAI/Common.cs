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
            currentObject[keyName] = new JsonArray(new JsonObject());
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

      currentObject[path[path.Length - 1]] = ToJsonNode(value);
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
                result.Add(node);
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

      return false;
    }

    private static JsonNode? ToJsonNode(object value)
    {
      // TODO: evaluate using System.Text.Json to handle conversion of object to JSON.
      switch (value)
      {
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
  }
}
