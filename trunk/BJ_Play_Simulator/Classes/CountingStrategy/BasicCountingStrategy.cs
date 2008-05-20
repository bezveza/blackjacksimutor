using System;
using System.Collections;
public class BasicCountingStrategy : ICountingStrategy
{
    private Hashtable mCountingObjects;

    public void UpdateCount(GameSettings GameSetting
                          , int CardsRemaining
                          , Card card)
    {
        int CountIncrementer;
        switch (card.Value)
        {
            case 1 :    
            case 10 :
                CountIncrementer = -1;
                break;
            case 2 :
            case 3 :
            case 4 :
            case 5 :
            case 6 :
                CountIncrementer = 1;
                break;
            default :
                CountIncrementer = 0;
                break;
        }
        int decksRemaining =
            (int)Math.Min(Math.Floor((double)(CardsRemaining) / 52)
                          ,(double)1);
        mCountingObjects["RunningCount"] = (int)mCountingObjects["RunningCount"] + CountIncrementer;
        mCountingObjects["TrueCount"] = (double)((int)mCountingObjects["RunningCount"] / decksRemaining);
    }

    public void setBeginngingCount()
    {
        mCountingObjects = new Hashtable();
        mCountingObjects.Add("TrueCount",(double)0);
        mCountingObjects.Add("RunningCount", (int)0);
    }

    public Hashtable getCountingObjects()
    {
        return mCountingObjects;
    }
}