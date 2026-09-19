using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

public static class JsonParser
{
    public static JTokenType GetJSONType(JObject o, string name)
    {
        if (o != null && o.TryGetValue(name, System.StringComparison.OrdinalIgnoreCase, out JToken token))
        {
            return token.Type;
        }

        Debug.Log($"Argument '{name}' not found in JSON object.");
        return JTokenType.None;
    }

    public static bool GetBoolFromJSON(JObject o, string name)
    {
        if (o == null || o[name] == null)
        {
            Debug.Log("Error parsing " + o?.ToString() + ". " + name + " argument not found");
            return false;
        }
        try
        {
            return (bool)o[name];
        }
        catch
        {
            Debug.Log("Error parsing bool for " + name + " argument in: " + o.ToString());
            return false;
        }
    }

    public static int GetIntFromJSON(JObject o, string name)
    {
        if (o == null || o[name] == null)
        {
            Debug.Log("Error parsing " + o?.ToString() + ". " + name + " argument not found");
            return 0;
        }
        try
        {
            return (int)o[name];
        }
        catch
        {
            Debug.Log("Error parsing int for " + name + " argument in: " + o.ToString());
            return 0;
        }
    }

    public static float GetFloatFromJSON(JObject o, string name)
    {
        if (o == null || o[name] == null)
        {
            Debug.Log("Error parsing " + o?.ToString() + ". " + name + " argument not found");
            return 0;
        }
        try
        {
            return (float)o[name];
        }
        catch
        {
            Debug.Log("Error parsing int for " + name + " argument in: " + o.ToString());
            return 0;
        }
    }

    public static string GetStringFromJSON(JObject o, string name)
    {
        if (o == null || o[name] == null)
        {
            Debug.Log("Error parsing " + o?.ToString() + ". " + name + " argument not found");
            return null;
        }
        return o[name]?.ToString();
    }

    public static List<string> GetStringListFromJSON(JObject o, string name)
    {
        if (o == null || o[name] == null)
        {
            Debug.Log("Error parsing " + o?.ToString() + ". " + name + " argument not found");
            return null;
        }

        if (o[name].Type != JTokenType.Array)
        {
            Debug.Log("Error parsing " + o.ToString() + ". " + name + " is not a list.");
            return null;
        }

        JArray jArray = o[name] as JArray;

        // Verify all items are primitive values (not nested objects or arrays)
        if (!jArray.All(item => item is JValue))
        {
            Debug.Log($"Error parsing. {name} contains complex nested structures instead of strings.");
            return null;
        }

        // Convert everything to its string representation
        return jArray.Select(item => item.ToString()).ToList();
    }

    public static JArray GetJArrayFromJSON(JObject o, string name)
    {
        if (o == null || o[name] == null)
        {
            Debug.Log("Error parsing " + o?.ToString() + ". " + name + " argument not found");
            return null;
        }

        if (o[name].Type != JTokenType.Array)
        {
            Debug.Log("Error parsing " + o.ToString() + ". " + name + " is not a JArray type.");
            return null;
        }

        return o[name] as JArray;
    }
}
