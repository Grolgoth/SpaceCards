using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public static class ConditionParser
{
    public static Condition Parse(JObject jsonObject, Card Root)
    {
        string type = JsonParser.GetStringFromJSON(jsonObject, "name");

        if (type == null)
        {
            Debug.Log("Error: type argument cannot be null");
            return null;
        }

        if (type == "NotBlockedCondition")
        {
            foreach (CardEffect e in Root.effects)
            {
                if (e.type == "Damage")
                {
                    return new NotBlockedCondition(Root, jsonObject, (DamageEffect)e);
                }
            }
            return null;
        }
        else if (type == "DistanceToTarget")
        {
            return new DistanceToTargetCondition(Root, jsonObject);
        }
        else
            return null;
    }
}
