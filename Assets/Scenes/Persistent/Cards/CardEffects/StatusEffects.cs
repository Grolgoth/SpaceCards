using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public abstract class StatusEffect : CardEffect
{
    public int turns = 0;
    public int delay = 0;

    public StatusEffect(Card Rootarg, JObject o, string type) : base(Rootarg, o, type)
    {
        if (o["duration"] != null)
            turns = JsonParser.GetIntFromJSON(o, "duration");
        if (o["delay"] != null)
            delay = JsonParser.GetIntFromJSON(o, "delay");
    }
}

public class TetherEffect : CardEffect
{

    public TetherEffect(Card Rootarg, JObject o) : base(Rootarg, o, "Tether")
    {

    }

    public override void Execute()
    {

    }
}

public class DebuffEffect : StatusEffect
{
    public string debuffType;

    public DebuffEffect(Card Rootarg, JObject o, string DebuffType) : base(Rootarg, o, "Debuff")
    {
        debuffType = DebuffType;

        if (turns == 0)
            turns = 1;
    }

    public override void Execute()
    {

    }
}

public class NullDefenseEffect : CardEffect
{

    public NullDefenseEffect(Card Rootarg, JObject o) : base(Rootarg, o, "NullDefense")
    {
        
    }

    public override void Execute()
    {

    }
}

public class LoseForceFieldEffect : CardEffect
{
    public bool percentage = false;
    public int damage;
    public float percent;

    public LoseForceFieldEffect(Card Rootarg, JObject o) : base(Rootarg, o, "LoseForceField")
    {
        if (o["damage"] != null)
            damage = JsonParser.GetIntFromJSON(o, "damage");
        else
        {
            percentage = true;
            percent = JsonParser.GetFloatFromJSON(o, "percent");
        }
    }

    public override void Execute()
    {

    }
}

public class RepairEffect : CardEffect
{
    public int repair;

    public RepairEffect(Card Rootarg, JObject o) : base(Rootarg, o, "Repair")
    {
        repair = JsonParser.GetIntFromJSON(o, "repair");
    }

    public override void Execute()
    {

    }
}