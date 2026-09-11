using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public static class CardEffectParser
{
    static readonly List<string> EffectsWithAmount = new() { "DrawEffect", "DamageEffect", "DefenseEffect", "ArmorEffect", "SpeedEffect", "AddCardEffect", "PlayCardEffect" };

    public static CardEffect Parse(JObject jsonObject, Card Root)
    {
        string type = JsonParser.GetStringFromJSON(jsonObject, "type");

        if (type == null)
        {
            Debug.Log("Error: type argument cannot be null");
            return null;
        }

        int amount = 0;

        //optimising
        if (EffectsWithAmount.Contains(type))
            amount = JsonParser.GetIntFromJSON(jsonObject, "amount");

        if (type == "DrawEffect")
        {
            string FromSource = JsonParser.GetStringFromJSON(jsonObject, "source");
            return new DrawEffect(Root, amount, FromSource);
        }
        else if (type == "DamageEffect")
        {
            return new DamageEffect(Root, amount);
        }
        else
            return null;
    }
}
