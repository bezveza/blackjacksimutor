using System;

public class BettingHand :Hand
{
    //members
    Bet mBet;

    //properties
    public bool AllowDouble
    {
        get
        {
            return (base.Count == 2);
        }
    }
    public bool isSplittable
    {
        get
        {
            return (base.Count == 2
                && base.Cards[0].ToString() == base.Cards[1].ToString());
        }
    }
    public double BetValue
    {
        get
        {
            return mBet.Value;
        }
    }

    //constructors
    public BettingHand(Card c1, Card c2, Bet b) : base(c1 , c2)
    {
        mBet = b;
    }
    //methods

    public void DoubleBet(Bet b)
    {
        if (b.Value != BetValue)
            throw new Exception("Bet value must be same as orignal bet when doubling");
        if (!AllowDouble)
            throw new Exception("This hand is not allowed to double");
        Bet bet = new Bet(b.Value * 2);
        mBet = bet;
    }
}
