using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class DrawEffect : CardEffect
{
    public int cards;
    public string FromSource = "drawpile";

    public DrawEffect(Card Rootarg, JObject o) : base(Rootarg, "Draw")
    {
        cards = JsonParser.GetIntFromJSON(o, "cards");

        if (o["source"] != null)
            FromSource = JsonParser.GetStringFromJSON(o, "source");
    }

    public override void Execute()
    {

    }
}

public class DiscardEffect : CardEffect
{
    public int amount;
    public string FromSource;

    public DiscardEffect(Card Rootarg, JObject o) : base(Rootarg, "Discard")
    {

    }

    public override void Execute()
    {

    }
}

public class ToDrawPileEffect : CardEffect
{
    public int amount = 1;
    public string target;
    public bool thisCard = false;
    public List<string> tags;

    public ToDrawPileEffect(Card Rootarg, JObject o) : base(Rootarg, "ToDrawPile")
    {
        target = JsonParser.GetStringFromJSON(o, "target");
        thisCard = target == "this";
        
        if (o["cards"] != null)
            amount = JsonParser.GetIntFromJSON(o, "cards");

        if (o["types"] != null)
            tags = JsonParser.GetStringListFromJSON(o, "types");
    }

    public override void Execute()
    {

    }
}
