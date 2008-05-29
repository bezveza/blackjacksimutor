using System;
using System.Collections;
using System.Text;

public class Hand
{
    //members
    ArrayList mCards = new ArrayList();
    int mHardTotal = 0;

    //properties

    public Card[] Cards
    {
        get
        {
            return (Card[])mCards.ToArray(typeof(Card));
        }
    }
    public int Count
    {
        get
        {
            return mCards.Count;
        }
    }
    public int HardTotal
    {
        get
        {
            return mHardTotal;
        }
    }
    public bool HasAce
    {
        get
        {
            foreach (Card c in this.Cards)
            {
                if (c.Value == 1) return true;
            }
            return false;
        }

    }
    public bool isBlackJack
    {
        get
        {
            return (this.Count == 2 && this.SoftTotal == 21);
        }
    }
    public bool isBusted
    {
        get
        {
            return (mHardTotal > 21);
        }
    }
    public int SoftTotal
    {
        get
        {
            if (this.HasAce && mHardTotal < 12) return mHardTotal + 10;
            else return mHardTotal;
        }
    }

    //constructors
    protected Hand()
    {
    }
    public Hand(Card c1, Card c2)
    {
        mCards.Add(c1);
        mHardTotal += c1.Value;
        mCards.Add(c2);
        mHardTotal += c2.Value;
    }

    //methods
    public void Add(Card c)
    {
        mCards.Add(c);
        mHardTotal += c.Value;

    }
    public void Remove(int Index)
    {
        if (Index >= 0 && Index < this.Count) mCards.RemoveAt(Index);
        else throw new Exception("Cannot remove card.  Index out of bounds");
    }
    public void Remove(Card c)
    {
        if (mCards.Contains(c)) mCards.Remove(c);
        else throw new Exception("Cannot remove card.  Card doesn't belong to hand");
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Card c in Cards)
        {
            sb.Append(c.ToString() + ',');
        }
        return sb.ToString();
    }
}

