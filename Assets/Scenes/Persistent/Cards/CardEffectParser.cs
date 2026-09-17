using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public static class CardEffectParser
{

    public static CardEffect Parse(JObject jsonObject, Card Root)
    {
        string type = JsonParser.GetStringFromJSON(jsonObject, "type");

        if (type == null)
        {
            Debug.Log("Error: type argument cannot be null");
            return null;
        }

        if (type == "Draw")
        {
            return new DrawEffect(Root, jsonObject);
        }
        else if (type == "ToDrawPile")
        {
            return new ToDrawPileEffect(Root, jsonObject);
        }
        else if (type == "Damage")
        {
            return new DamageEffect(Root, jsonObject);
        }
        else if (type == "Nprojectile")
        {
            return new NProjectileEffect(Root, jsonObject);
        }
        else if (type == "Condition")
        {
            Root.conditions.Add(ConditionParser.Parse(jsonObject, Root));
            return null;
        }
        else if (type == "NullDefense")
        {
            return new NullDefenseEffect(Root, jsonObject);
        }
        else if (type == "DefenseLeech")
        {
            return new DefenseLeechEffect(Root, jsonObject);
        }
        else
            return null;
    }
}
