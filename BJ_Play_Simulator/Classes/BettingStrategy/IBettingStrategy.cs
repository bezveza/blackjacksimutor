using System;
using System.Collections;

public interface IBettingStrategy
{
    int DetermineBettingAmount(GameSettings GameSetting
        ,double CurrentBankRoll
        ,int CardsInShoeRemaining
        ,Hashtable CountingObjects);
}
