using System;
using System.Collections;
using System.Text;

public class Table
{
    //members
    private House mHouse;
    private ArrayList mGamblers;

    //properties
    public BettingPlayer[] Gamblers
    {
        get
        {
            return (BettingPlayer[])mGamblers.ToArray(typeof(BettingPlayer));
        }
    }
    public House house
    {
        get
        {
            return mHouse;
        }
    }

    //constructors
    public Table(House h)
    {
        mHouse = h;
        mGamblers = new ArrayList();
    }
    public Table(House h, BettingPlayer[] Gamblers)
    {
        mHouse = h;
        mGamblers = new ArrayList();
        foreach(BettingPlayer Gambler in Gamblers)
        {
            this.addGambler(Gambler);
        }
    }
    //methods
    public void addGambler(BettingPlayer Gambler)
    {
        mGamblers.Add(Gambler);
    }

    public void RemoveGambler(BettingPlayer Gambler)
    {
        if (mGamblers.Contains(Gambler))
        {
            mGamblers.Remove(Gambler);
        }
        else throw new Exception("Cannot remove betting player.  Betting Player doesn't belong to table");
    }

    public void RemoveBankruptPlayers(int MinimumBet)
    {
        foreach (BettingPlayer Gambler in Gamblers)
        {
            if (Gambler.bankRoll.Value < MinimumBet)
                RemoveGambler(Gambler);
        }
    }

}
