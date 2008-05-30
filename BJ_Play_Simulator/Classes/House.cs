using System;

public class House
{
    //members
    protected IHouseRules mHouseRules;
    private Hand mHand;

    //properties
    public Hand CurrentHand
    {
         get
        {
            return mHand;
        }
    }

    //constructors
    public House(IHouseRules HouseRules)
    {
        mHouseRules = HouseRules;
    }

    //methods
    public HandDecision DetermineNextMove()
    {
        return mHouseRules.DetermineNextMove(CurrentHand);
    }
    public void AddHand(Hand h)
    {
        if (mHand == null) mHand = h;
        else throw new Exception("Cannot add second hand to player.  Hand must be cleared first");
    }
    public void ClearHands()
    {
        mHand = null;
    }
 
}

