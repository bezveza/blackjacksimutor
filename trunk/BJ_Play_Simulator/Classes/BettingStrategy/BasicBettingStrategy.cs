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
        if (trueCount < 1)
            return 10;
        else if (trueCount < 2)
            return 37;
        else if (trueCount < 3)
            return 64;
        else if (trueCount < 4)
            return 91;
        else
            return 120;
    }
}
