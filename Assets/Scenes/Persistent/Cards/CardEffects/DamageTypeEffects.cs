using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public abstract class AttackEffect : CardEffect
{
    //after execution variables
    public bool WasBlocked = true;

    public AttackEffect(Card Rootarg, JObject o, string type) : base(Rootarg, o, type)
    {

    }
}

public class DamageEffect : AttackEffect
{
    public long Damage;
    List<string> DType;

    public int ArmorDamageMultiplier = 1;
    public int DefenseDamageMultiplier = 1;
    public int Acid = 0;

    public DamageEffect(Card Rootarg, JObject o) : base(Rootarg, o, "Damage")
    {
        Damage = (long)JsonParser.GetIntFromJSON(o, "damage");
        if (o["dtype"] != null)
        {
            DType = JsonParser.GetStringListFromJSON(o, "dtype");
            if (DType.Contains("Acid"))
            {
                Acid = JsonParser.GetIntFromJSON(o, "acid");
            }
        }
        if (o["ArmorDamageMultiplier"] != null)
            ArmorDamageMultiplier = JsonParser.GetIntFromJSON(o, "ArmorDamageMultiplier");
        if (o["DefenseDamageMultiplier"] != null)
            DefenseDamageMultiplier = JsonParser.GetIntFromJSON(o, "DefenseDamageMultiplier");

    }

    public override void Execute()
    {
        for (int i = 0; i < repeat + 1; i++)
        {

        }
    }
}

public class DefenseLeechEffect : CardEffect
{
    public int amount;

    public DefenseLeechEffect(Card Rootarg, JObject o) : base(Rootarg, o, "DefenseLeech")
    {
        amount = JsonParser.GetIntFromJSON(o, "leech");

    }

    public override void Execute()
    {

    }
}

public class ForceFieldDamageEffect: AttackEffect
{

    public ForceFieldDamageEffect(Card Rootarg, JObject o) : base(Rootarg, o, "ForceFieldDamage")
    {

    }

    public override void Execute()
    {

    }
}