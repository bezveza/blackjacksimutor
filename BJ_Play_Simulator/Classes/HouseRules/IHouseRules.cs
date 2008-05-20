using System;
using System.Collections;
public interface IHouseRules
{
    HandDecision DetermineNextMove(Hand CurrentHand);
}


