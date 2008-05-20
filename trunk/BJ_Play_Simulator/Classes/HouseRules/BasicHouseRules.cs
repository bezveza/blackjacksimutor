using System;

public class BasicHouseRules : IHouseRules
{
    public HandDecision DetermineNextMove(Hand CurrentHand)
    {
        if (CurrentHand.SoftTotal >= 17) return HandDecision.Stand;
        else return HandDecision.Hit;
    }
}
