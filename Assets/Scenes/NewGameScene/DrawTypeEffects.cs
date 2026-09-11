using UnityEngine;

public class DrawEffect : CardEffect
{
    public int amount;
    public string FromSource;

    public DrawEffect(Card Rootarg, int amountarg, string fromsourcearg) : base(Rootarg)
    {
        amount = amountarg;
        FromSource = fromsourcearg;
    }

    public override void Execute(string target)
    {

    }
}

public class DiscardEffect : CardEffect
{
    public int amount;
    public string FromSource;

    public DiscardEffect(Card Rootarg, int amountarg, string fromsourcearg) : base(Rootarg)
    {
        amount = amountarg;
        FromSource = fromsourcearg;
    }

    public override void Execute(string target)
    {

    }
}

public class ToDrawPileEffect : CardEffect
{
    public int amount;
    public string FromSource;

    public ToDrawPileEffect(Card Rootarg, int amountarg, string fromsourcearg) : base(Rootarg)
    {
        amount = amountarg;
        FromSource = fromsourcearg;
    }

    public override void Execute(string target)
    {

    }
}
