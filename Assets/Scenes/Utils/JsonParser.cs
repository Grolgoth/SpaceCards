using UnityEngine;
using Newtonsoft.Json.Linq;

public static class JsonParser
{
    public static int GetIntFromJSON(JObject o, string name)
    {
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

    public static string GetStringFromJSON(JObject o, string name)
    {
        if (o[name] == null)
        {
            Debug.Log("Error parsing " + o.ToString() + ". " + name + " argument not found");
            return null;
        }
        return o[name]?.ToString();
    }
}
