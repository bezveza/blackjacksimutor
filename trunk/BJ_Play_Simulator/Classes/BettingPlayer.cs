using System;
using System.Collections;

 public class BettingPlayer
{
    //members
    private IBettingStrategy mBettingStrategy;
    private ICountingStrategy mCountingStrategy;
    private IPlayingStrategy mPlayingStrategy;
    private BankRoll mBankRoll;
    private int mCurrentBaseBet;

    private CardPlayedDelegate mCardPlayed;
    private ShoeReloadedDelegate mShoeReloaded;

    protected ArrayList mHands = new ArrayList();
    protected int mCurrentHandIndex = 0;
    
    //properties
    public BettingHand[] BettingHands
    {
        get
        {
            return (BettingHand[])mHands.ToArray(typeof(BettingHand));
        }
    }
    public BettingHand CurrentHand
    {
        get
        {
            return (BettingHand)mHands[mCurrentHandIndex];
        }
    }
     public BankRoll bankRoll
     {
         get
         {
             return mBankRoll;
         }
     }

    //contructors
    public BettingPlayer(IPlayingStrategy PlayingStrategy
                        , IBettingStrategy BettingStrategy
                        ,ICountingStrategy CountingStrategy
                        , double Cash)
    {
        mPlayingStrategy = PlayingStrategy;
        mBettingStrategy = BettingStrategy;
        mCountingStrategy = CountingStrategy;
        mBankRoll = new BankRoll(Cash);
        ResetCount();
    }

    //methods

     public HandDecision DetermineNextMove(Card HouseUpCard)
     {
         bool AvailableBankRoll = (mCurrentBaseBet <= mBankRoll.Value);
         return mPlayingStrategy.DetermineNextMove(CurrentHand,
             HouseUpCard,
             mCountingStrategy.getCountingObjects(),
             AvailableBankRoll);
     }

    public void RegisterForDealerEvents(Dealer d)
    {
        mCardPlayed = new CardPlayedDelegate(UpdateCount);
        d.CardPlayed += mCardPlayed;

        mShoeReloaded = new ShoeReloadedDelegate(ResetCount);
        d.ShoeReloaded += mShoeReloaded;
    }

     public Bet MakeFirstBet(GameSettings GS, int CardsRemaining)
    {
        mCurrentBaseBet = mBettingStrategy.DetermineBettingAmount(GS
            ,mBankRoll.Value
            , CardsRemaining
            ,mCountingStrategy.getCountingObjects());
        return mBankRoll.getBet(mCurrentBaseBet);
    }
    public Bet MakeSubsequentBet()
    {
        return mBankRoll.getBet(mCurrentBaseBet);
    }
    public void RecieveWinnings(double Cash)
    {
        mBankRoll.AddCash(Cash);
    }

    private void UpdateCount(Card c,GameSettings GameSetting,int CardsRemaining)
    {
        mCountingStrategy.UpdateCount(GameSetting, CardsRemaining, c);
    }
    private void ResetCount()
    {
        mCountingStrategy.setBeginngingCount();
    }

    public void AddHand(BettingHand h)
    {
        mHands.Add(h);
    }
    public void ClearHands()
    {
        mHands.Clear();
        mCurrentBaseBet = 0;
        mCurrentHandIndex = 0;
    }
    public void ReplaceHand(BettingHand ReplacingHand, BettingHand CurrentHand)
    {
        if (mHands.Contains(CurrentHand))
            mHands[mHands.IndexOf(CurrentHand)] = ReplacingHand;
        else throw new Exception("Cannot replace hand, Player doesn't have current hand");
    }
    public void ReplaceHand(BettingHand ReplacingHand, int HandPosition)
    {
        if (HandPosition >= 0 && HandPosition < mHands.Count)
            mHands[HandPosition] = ReplacingHand;
        else throw new Exception("Cannot replace hand, index out of bounds");
    }
    public bool goToNextHand()
    {
        if (mCurrentHandIndex < mHands.Count - 1)
        {
            mCurrentHandIndex++;
            return true;
        }
        else return false;
    }


}
