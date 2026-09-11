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

        int id = JsonParser.GetIntFromJSON(jsonObject, "id");

        Card card = new Card(id);

        card.name = JsonParser.GetStringFromJSON(jsonObject, "name");
        card.cost = JsonParser.GetIntFromJSON(jsonObject, "cost");
        card.yield = JsonParser.GetIntFromJSON(jsonObject, "yield");
        card.price = JsonParser.GetIntFromJSON(jsonObject, "price");
        card.description = JsonParser.GetStringFromJSON(jsonObject, "description");
        card.tag = JsonParser.GetStringFromJSON(jsonObject, "tag");

        JArray effectsArray = jsonObject["effects"] as JArray;

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
