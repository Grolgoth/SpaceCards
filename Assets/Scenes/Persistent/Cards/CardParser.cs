using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public static class CardParser
{
    public static Card Parse(JObject jsonObject)
    {
        if (jsonObject == null)
        {
            Debug.LogError("Cannot parse null Card JObject.");
            return null;
        }

        string id = JsonParser.GetStringFromJSON(jsonObject, "name");

        Card card = new Card(id);

        card.cost = JsonParser.GetIntFromJSON(jsonObject, "cost");
        card.yield = JsonParser.GetIntFromJSON(jsonObject, "yield");
        card.price = JsonParser.GetIntFromJSON(jsonObject, "price");
        card.rarity = JsonParser.GetIntFromJSON(jsonObject, "rarity");
        card.description = JsonParser.GetStringFromJSON(jsonObject, "description");
        card.tags = JsonParser.GetStringListFromJSON(jsonObject, "type");

        JArray effectsArray = JsonParser.GetJArrayFromJSON(jsonObject, "effects");

        if (effectsArray != null)
        {
            foreach (JToken token in effectsArray)
            {
                if (token is JObject effectJObject)
                {
                    CardEffect effect = CardEffectParser.Parse(effectJObject, card);
                    if (effect != null)
                        card.effects.Add(effect);
                }
                else
                {
                    Debug.Log("Error parsing " + token.ToString() + " from" + effectsArray.ToString() + " in Card constructor. This is not a JObject");
                }
            }
        }

        return card;
    }
}
