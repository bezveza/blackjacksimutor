using System;
using System.Collections;
public interface IPlayingStrategy
{
    HandDecision DetermineNextMove(BettingHand CurrentHand, 
        Card HouseUpCard,
        Hashtable CoutingObjects,
        bool DoubleSplitBankRollAvailable);
}

public enum HandDecision { Hit, Stand, Split, Double }

