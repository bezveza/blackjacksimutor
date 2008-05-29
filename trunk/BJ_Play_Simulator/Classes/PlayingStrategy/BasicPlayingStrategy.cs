using System;
using System.Collections;

public class BasicPlayingStrategy : IPlayingStrategy
{
    //members

    //these arrays are too large.... but done so that array positions
    //match card values
    private HandDecision[,] SplittingDecision = new HandDecision[11, 11];
    private HandDecision[,] SoftTotalDecision = new HandDecision[10, 11];
    private HandDecision[,] BaseDecision = new HandDecision[21, 11];

    //properties

    //constructors
    public BasicPlayingStrategy()
    {
        BuildSplittingArray();
        BuildBaseArray();
        BuildSoftTotalArray();
    }



    //methods
    public HandDecision DetermineNextMove(BettingHand CurrentHand, 
        Card HouseUpCard,
        Hashtable CoutingObjects,
        bool DoubleSplitBankRollAvailable)
    {
        HandDecision HD;
        if (CurrentHand.SoftTotal == 21)
            HD = HandDecision.Stand;
        else if (CurrentHand.isSplittable && DoubleSplitBankRollAvailable)
        {
            HD = SplittingDecision[CurrentHand.Cards[0].Value, HouseUpCard.Value];
        }
        else if (CurrentHand.HasAce && CurrentHand.HardTotal <= 10)
        {
            HD = SoftTotalDecision[CurrentHand.HardTotal - 1, HouseUpCard.Value];
            if (HD == HandDecision.Double && (!CurrentHand.AllowDouble || !DoubleSplitBankRollAvailable))
            {
                if (CurrentHand.HardTotal - 1 == 7)
                    HD = HandDecision.Stand;
                else
                    HD = HandDecision.Hit;
            }
        }
        else
        {
            HD = BaseDecision[CurrentHand.SoftTotal, HouseUpCard.Value];
            if (HD == HandDecision.Double && (!CurrentHand.AllowDouble || !DoubleSplitBankRollAvailable))
                HD = HandDecision.Hit;
        }
        return HD;

    }
    private void BuildSoftTotalArray()
    {
        int i, j;
        for (i = 2; i <= 6; i++)
        {
            for (j=1; j<=10;j++)
            {
                if ((j == 5 || j == 6)
                    || (j == 4 && i >= 4)
                    || (j == 3 && i == 6))
                    SoftTotalDecision[i, j] = HandDecision.Double;
                else SoftTotalDecision[i, j] = HandDecision.Hit;
            }
        }
        SoftTotalDecision[7, 1] = HandDecision.Hit;
        SoftTotalDecision[7, 2] = HandDecision.Stand;
        SoftTotalDecision[7, 3] = HandDecision.Double;
        SoftTotalDecision[7, 4] = HandDecision.Double;
        SoftTotalDecision[7, 5] = HandDecision.Double;
        SoftTotalDecision[7, 6] = HandDecision.Double;
        SoftTotalDecision[7, 7] = HandDecision.Stand;
        SoftTotalDecision[7, 8] = HandDecision.Stand;
        SoftTotalDecision[7, 9] = HandDecision.Hit;
        SoftTotalDecision[7, 10] = HandDecision.Hit;

        for (i = 8; i <= 9; i++)
        {
            for (j = 1; j <= 10; j++)
            {
                 SoftTotalDecision[i, j] = HandDecision.Stand;
            }
        }

    }

    private void BuildBaseArray()
    {
        int i, j;
        for (i = 5; i <= 9; i++)
        {
            for (j = 1; j <= 10; j++)
            {
                if ((j >= 4 && i >= 4)
                    || (j == 3 && i == 6))
                    SoftTotalDecision[i, j] = HandDecision.Double;
                else SoftTotalDecision[i, j] = HandDecision.Hit;
            }
        }

    }

    private void BuildSplittingArray()
    {
        int i, j;
        for (j = 1; j <= 10; j++)
        {
            SplittingDecision[1, j] = HandDecision.Split;
        }

        for (i = 2; i <= 3; i++)
        {
            {
                for (j = 1; j <= 10; j++)
                {
                    if(j >=8 || j ==1)
                        SplittingDecision[1, j] = HandDecision.Split;
                    else SplittingDecision[1, j] = HandDecision.Hit;
                }
            }
        }

        SplittingDecision[4, 1] = HandDecision.Hit;
        SplittingDecision[4, 2] = HandDecision.Hit;
        SplittingDecision[4, 3] = HandDecision.Hit;
        SplittingDecision[4, 4] = HandDecision.Hit;
        SplittingDecision[4, 5] = HandDecision.Split;
        SplittingDecision[4, 6] = HandDecision.Split;
        SplittingDecision[4, 7] = HandDecision.Hit;
        SplittingDecision[4, 8] = HandDecision.Hit;
        SplittingDecision[4, 9] = HandDecision.Hit;
        SplittingDecision[4, 10] = HandDecision.Hit;

        for (j = 1; j <= 10; j++)
        {
            if(j ==1 || j == 10)
                SplittingDecision[5, j] = HandDecision.Hit;
            else
                SplittingDecision[5, j] = HandDecision.Double;
        }

        for (j = 1; j <= 10; j++)
        {
            if (j == 1 || j >= 7)
                SplittingDecision[6, j] = HandDecision.Hit;
            else
                SplittingDecision[6, j] = HandDecision.Split;
        }

        for (j = 1; j <= 10; j++)
        {
            if (j == 1 || j >= 8)
                SplittingDecision[7, j] = HandDecision.Hit;
            else
                SplittingDecision[7, j] = HandDecision.Split;
        }

        for (j = 1; j <= 10; j++)
        {
           SplittingDecision[8, j] = HandDecision.Split;
        }

        for (j = 1; j <= 10; j++)
        {
            if (j == 7 || j == 10 || j == 1)
                SplittingDecision[9, j] = HandDecision.Stand;
            else
                SplittingDecision[9, j] = HandDecision.Split;
        }

        for (j = 1; j <= 10; j++)
        {
            SplittingDecision[10, j] = HandDecision.Stand;
        }
    }
}
