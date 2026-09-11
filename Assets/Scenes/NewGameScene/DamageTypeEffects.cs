using UnityEngine;

public class DamageEffect : CardEffect
{
    public int amount;
    public string FromSource;

    public DamageEffect(Card Rootarg, int amountarg) : base(Rootarg)
    {
        amount = amountarg;
    }

    public override void Execute(string target)
    {

    }
}
