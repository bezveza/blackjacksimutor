using System;

public class Shoe
{
    //members
    private int mIndex = 0;
    private Card[] mCards;
    private CryptoStongRandom mRandomNumberGenerator;

    //properties
    public int CardsRemaining
    {
        get
        {
            return mCards.Length - mIndex;
        }
    }
    //constructors
    public Shoe(int NumberOfDecks, CryptoStongRandom RandomNumberGenerator)
    {
        if (NumberOfDecks < 1) 
            throw new Exception("Cannot create shoe, number of decks must be positive");

        mRandomNumberGenerator = RandomNumberGenerator;

        mCards = new Card[NumberOfDecks * 52];
        int currArrayPos = 0;
        Card c;
        
        for (int i = 0; i < NumberOfDecks; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                //TODO: re-implement, this is horribly redundant

                c = new Card(j, Suit.Clubs);
                mCards[currArrayPos] = c;
                currArrayPos++;

                c = new Card(j, Suit.Hearts);
                mCards[currArrayPos] = c;
                currArrayPos++;

                c = new Card(j, Suit.Spades);
                mCards[currArrayPos] = c;
                currArrayPos++;

                c = new Card(j, Suit.Diamonds);
                mCards[currArrayPos] = c;
                currArrayPos++;
            }
        }
        shuffle();
    }

    //methods
    private void shuffle()
    {
     //see http://en.wikipedia.org/wiki/Fisher-Yates_shuffle for implementaion details


        int n = mCards.Length;
        int k;
        Card c;
        while (n > 1)
        {
            k = mRandomNumberGenerator.Next(n);
            n--;
            c = mCards[n];
            mCards[n] = mCards[k];
            mCards[k] = c;
        }
        
    }
    public Card GetNextCard()
    {
        if (mIndex >= mCards.Length)
            throw new Exception("Cannot deal card. Out of Cards");
        Card c = mCards[mIndex];
        mIndex++;
        return c;
    }

}

