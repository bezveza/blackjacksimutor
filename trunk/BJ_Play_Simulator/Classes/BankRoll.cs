using System;
using System.Collections.Generic;
using System.Text;

public class BankRoll
{
    //members
    double mCash;

    //properties
    public double Value
    {
        get
        {
            return mCash;
        }
    }
    //contructors
    public BankRoll(double Cash)
    {
        mCash = Cash;
    }

    //methods
    public Bet getBet(int betValue)
    {
        if (betValue > mCash)
            throw new Exception("Cannot create bet, bet is larger than bankroll");
        Bet b = new Bet(betValue);
        mCash -= betValue;
        return b;
    }
    public void AddCash(double Cash)
    {
        mCash += Cash;
    }
}

public class Bet 
{
    //members
    private int mCash;

    //properties
    public int Value
    {
        get
        {
            return mCash;
        }
    }
    //contructors
    public Bet(int Cash)
    {
        mCash = Cash;
    }
}

