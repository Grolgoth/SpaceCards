using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public abstract class Condition
{
    public class Repeat
    {
        // if either turns or count == 0, nothing will happen.
        // turns positive, count positive, for X turns keep checking up until X count
        // turns negative, count negative: every turn forever, every tick check.
        // turns positive, count negative: for X tuns, every tick check
        // turns negative, count positive: every turn keep checking up until X count
        // Standard 1-time check therefore is turns 1, count 1, which is why these are the default values.
        public int turns = 1;
        public int count = 1;
        public bool endofcard = false;
    }

    public Card Root;
    public Repeat repeat;
    public List<CardEffect> results = new();

    public Condition(Card Rootarg, JObject o)
    {
        Root = Rootarg;
        repeat = new Repeat();

        JArray effectsArray = JsonParser.GetJArrayFromJSON(o, "result");

        if (effectsArray != null)
        {
            foreach (JToken token in effectsArray)
            {
                if (token is JObject effectJObject)
                {
                    CardEffect effect = CardEffectParser.Parse(effectJObject, Root);
                    if (effect != null)
                       results.Add(effect);
                }
                else
                {
                    Debug.Log("Error parsing " + token.ToString() + " from" + effectsArray.ToString() + " in Condition constructor. This is not a JObject");
                }
            }
        }

        if (o["repeat"] != null)
        {
            List<string> repeatList = JsonParser.GetStringListFromJSON(o, "repeat");
            if (repeatList.Count == 0)
                return;

            if (repeatList[0] == "-")
                repeat.count = -1;
            else
            {
                int count;
                int.TryParse(repeatList[0], out count);
                repeat.count = count;
            }

            if (repeatList.Count == 1)
                return;

            if (repeatList[1] == "-")
                repeat.turns = -1;
            else if (repeatList[1] == "endofcard")
                repeat.endofcard = true;
            else
            {
                int count;
                int.TryParse(repeatList[1], out count);
                repeat.turns = count;
            }
        }
    }

    public abstract bool Check();

    public bool JustOnce()
    {
        return repeat.count == 1 && repeat.turns == 1;
    }
}

public class NotBlockedCondition : Condition
{

    public DamageEffect damage;

    public NotBlockedCondition(Card Rootarg, JObject o, DamageEffect e) : base(Rootarg, o)
    {
        damage = e;
    }

    public override bool Check()
    {
        return !damage.WasBlocked;
    }
}

public class DistanceToTargetCondition : Condition
{
    public int distance;

    public DistanceToTargetCondition(Card Rootarg, JObject o) : base(Rootarg, o)
    {
        distance = JsonParser.GetIntFromJSON(o, "distance");
    }

    public override bool Check()
    {
        return false;
    }
}
