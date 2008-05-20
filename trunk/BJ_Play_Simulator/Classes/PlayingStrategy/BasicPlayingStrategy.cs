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
    public HandDecision DetermineNextMove(Hand CurrentHand, Card HouseUpCard,Hashtable CoutingObjects)
    {
        if (CurrentHand.SoftTotal >= 17) return HandDecision.Stand;
        else return HandDecision.Hit;
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
        //throw new Exception("The method or operation is not implemented.");
    }
}
