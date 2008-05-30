using System;

public struct GameSettings
{
    //members
    private int mDecksInShoe;
    private int mReloadShoeDeckCount;
    private int mMinimumBet;
    private int mMaximumBet;
    private int mBettingRounds;

    //properties
    public int DecksInShoe
    {
        get
        {
            return mDecksInShoe;
        }
    }
    public int ReloadShoeDeckCount
    {
        get
        {
            return mReloadShoeDeckCount;
        }
    }
    public int MinimumBet
    {
        get
        {
            return mMinimumBet;
        }
    }
    public int MaximumBet
    {
        get
        {
            return mMaximumBet;
        }
    }
    public int BettingRounds
    {
        get
        {
            return mBettingRounds;
        }
    }


    //constructors
    public GameSettings(int DecksInShoe,
        int ReloadShoeDeckCount
        , int MinimumBet
        , int MaximumBet
        , int BettingRounds)
    {
        if (MaximumBet < 1
            || MinimumBet <= 0
            || MinimumBet > MaximumBet
            || ReloadShoeDeckCount >= DecksInShoe
            || BettingRounds <= 0) throw new Exception("Cannot create game settings.");
        mDecksInShoe = DecksInShoe;
        mReloadShoeDeckCount = ReloadShoeDeckCount;
        mMinimumBet = MinimumBet;
        mMaximumBet = MaximumBet;
        mBettingRounds = BettingRounds;
    }

}

