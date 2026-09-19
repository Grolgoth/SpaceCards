using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class NProjectileEffect : AttackEffect
{
    public int count = 1;

    public List<CardEffect> Effects;

    public NProjectileEffect(Card Rootarg, JObject o) : base(Rootarg, o, "NProjectile")
    {
        count = JsonParser.GetIntFromJSON(o, "count");

        JArray effectsArray = JsonParser.GetJArrayFromJSON(o, "effects");

        if (effectsArray != null)
        {
            foreach (JToken token in effectsArray)
            {
                if (token is JObject effectJObject)
                {
                    CardEffect effect = CardEffectParser.Parse(effectJObject, Rootarg);
                    if (effect != null)
                        Effects.Add(effect);
                }
                else
                {
                    Debug.Log("Error parsing " + token.ToString() + " from" + effectsArray.ToString() + " in Card constructor. This is not a JObject");
                }
            }
        }
    }

    public override void Execute()
    {

    }
}
