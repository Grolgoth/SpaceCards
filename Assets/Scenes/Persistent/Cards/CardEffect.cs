using Newtonsoft.Json.Linq;

public abstract class CardEffect
{
    public Card Root;
    public string type;

    bool area = false;
    string target = "";
    public int repeat = 0;

    public CardEffect(Card Rootarg, JObject o, string Typearg)
    {
        Root = Rootarg;
        type = Typearg;

        if (o["area"] != null)
            area = JsonParser.GetBoolFromJSON(o, "area");
        if (o["target"] != null)
            target = JsonParser.GetStringFromJSON(o, "target");
        if (o["repeat"] != null)
            repeat = JsonParser.GetIntFromJSON(o, "repeat");
    }

    public abstract void Execute();
}
