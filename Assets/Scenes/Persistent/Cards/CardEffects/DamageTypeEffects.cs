using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class DamageEffect : CardEffect
{
    public long Damage;
    bool Area = false;
    List<string> DType;

    public int Repeat = 0;
    public int ArmorDamageMultiplier = 1;
    public int DefenseDamageMultiplier = 1;
    public int Acid = 0;

    //after execution variables
    public bool WasBlocked = true;

    public DamageEffect(Card Rootarg, JObject o) : base(Rootarg, "Damage")
    {
        Damage = (long)JsonParser.GetIntFromJSON(o, "damage");
        if (o["area"] != null)
            Area = JsonParser.GetBoolFromJSON(o, "area");
        if (o["dtype"] != null)
        {
            DType = JsonParser.GetStringListFromJSON(o, "dtype");
            if (DType.Contains("Acid"))
            {
                Acid = JsonParser.GetIntFromJSON(o, "acid");
            }
        }
        if (o["repeat"] != null)
            Repeat = JsonParser.GetIntFromJSON(o, "repeat");
        if (o["ArmorDamageMultiplier"] != null)
            ArmorDamageMultiplier = JsonParser.GetIntFromJSON(o, "ArmorDamageMultiplier");
        if (o["DefenseDamageMultiplier"] != null)
            DefenseDamageMultiplier = JsonParser.GetIntFromJSON(o, "DefenseDamageMultiplier");

    }

    public override void Execute()
    {
        for (int i = 0; i < Repeat + 1; i++)
        {

        }
    }
}

public class DefenseLeechEffect : CardEffect
{
    public int amount;
    bool area = false;

    public DefenseLeechEffect(Card Rootarg, JObject o) : base(Rootarg, "DefenseLeech")
    {
        amount = JsonParser.GetIntFromJSON(o, "leech");

        if (o["area"] != null)
            area = JsonParser.GetBoolFromJSON(o, "area");
    }

    public override void Execute()
    {

    }
}