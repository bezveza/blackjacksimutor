using System;
using System.Collections;
public interface IPlayingStrategy
{
    HandDecision DetermineNextMove(Hand CurrentHand, Card HouseUpCard,Hashtable CoutingObjects);
}

public enum HandDecision { Hit, Stand, Split, Double }

