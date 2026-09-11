using UnityEngine;

public abstract class CardEffect
{
    public Card Root;
    public CardEffect(Card Rootarg)
    {
        Root = Rootarg;
    }

    public abstract void Execute(string target);
}
