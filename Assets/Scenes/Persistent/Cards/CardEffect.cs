
public abstract class CardEffect
{
    public Card Root;
    public string type;

    public CardEffect(Card Rootarg, string Typearg)
    {
        Root = Rootarg;
        type = Typearg;
    }

    public abstract void Execute();
}
