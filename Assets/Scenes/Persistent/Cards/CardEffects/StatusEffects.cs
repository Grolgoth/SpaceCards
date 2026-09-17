using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class TetherEffect : CardEffect
{

    public TetherEffect(Card Rootarg, JObject o) : base(Rootarg, "Tether")
    {

    }

    public override void Execute()
    {

    }
}

public class InefficiencyEffect : CardEffect
{
    public int turns = 1;

    public InefficiencyEffect(Card Rootarg, JObject o) : base(Rootarg, "Inefficiency")
    {
        if (o["duration"] != null)
            turns = JsonParser.GetIntFromJSON(o, "duration");
    }

    public override void Execute()
    {

    }
}

public class NullDefenseEffect : CardEffect
{
    public NullDefenseEffect(Card Rootarg, JObject o) : base(Rootarg, "NullDefense")
    {

    }

    public override void Execute()
    {

    }
}