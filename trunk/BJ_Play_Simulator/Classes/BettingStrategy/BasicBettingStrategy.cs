using System;
using System.Collections;

public class BasicBettingStrategy : IBettingStrategy
{
    public int DetermineBettingAmount(GameSettings GameSetting
        ,double CurrentBankRoll
        ,int CardsInShoeRemaining
        ,Hashtable CountingObjects)
    {
        double trueCount = (double)CountingObjects["TrueCount"];
        int bet;
        if (trueCount < 1)
            bet = 10;
        else if (trueCount < 2)
            bet = 37;
        else if (trueCount < 3)
            bet = 64;
        else if (trueCount < 4)
            bet = 91;
        else
            bet = 120;
        if (bet > CurrentBankRoll)
            bet = (int)Math.Floor(CurrentBankRoll);
        return bet;
    }
}
