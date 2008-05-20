using System;


public struct Card
{
    //members
    private int mRank;
    private Suit mSuit;

    //properties
    public int Value{
        get
        {
            if(mRank >10) return 10;
            else return mRank;
        }
    }
    public Suit suit{
        get
        {
            return mSuit;
        }
    }

    //constructors
    public Card(int Rank, Suit suit)
    {
        if (Rank >= 1 || Rank <= 13)
        {
            mRank = Rank;
            mSuit = suit;
        }
        else throw new Exception("Cannot create card.  Card Rank out of bounds");
    }

    //methods
    public override string ToString()
    {
        switch(mRank)
        {
            case 11 :
                return "J";
            case 12 :
                return "Q";
            case 13 :
                return "K";
            case 1 :
                return "A";
            default :
                return mRank.ToString(); 
        }
    }
}

public enum Suit { Hearts, Spades, Clubs, Diamonds }
