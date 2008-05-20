using System;
public delegate void CardPlayedDelegate(Card C,GameSettings GameSetting,int CardsRemaining);
public delegate void ShoeReloadedDelegate();
public class Dealer
{
    //members
    private Shoe mShoe;
    private GameSettings mGameSetting;
    private Card HouseUpCard;
    public event CardPlayedDelegate CardPlayed;
    public event ShoeReloadedDelegate ShoeReloaded;
    //properties

    //contructors

    public Dealer(GameSettings GameSetting)
    {
        mGameSetting = GameSetting;
        mShoe = new Shoe(mGameSetting.DecksInShoe);
    }

    public void PlayRound(House house,BettingPlayer[] Gamblers)

    {
        CheckForShoeReload();
        DealInitialCards(house,Gamblers);
        
        //check for House BlackJack, "push" for any player also with blackjack
        if (house.CurrentHand.isBlackJack)
        {
            foreach (BettingPlayer Gambler in Gamblers)
            {
                if (Gambler.CurrentBettingHand.isBlackJack)
                    Gambler.RecieveWinnings(Gambler.CurrentBettingHand.BetValue);
            }
            CardPlayed(house.CurrentHand.Cards[0], mGameSetting, mShoe.CardsRemaining);
            ClearHands(house, Gamblers);
            return;
        }
        playBettingHands(Gamblers);
        playHouseHand(house);
        DisburseWinnings(house.CurrentHand, Gamblers);
        

        //Allow everyone to add house "down" card to the count
        CardPlayed(house.CurrentHand.Cards[0], mGameSetting, mShoe.CardsRemaining);
        ClearHands(house, Gamblers);
    }
    private void CheckForShoeReload()
    {
        // if the count of cards remaining is under the reload threshhold, reload it and fire the event to notify players
        if (mShoe.CardsRemaining < (mGameSetting.ReloadShoeDeckCount * 52))
        {
            mShoe = new Shoe(mGameSetting.DecksInShoe);
            ShoeReloaded();
        }
    }
    private void DealInitialCards(House house,BettingPlayer[] Gamblers)
    {
        /*
        for the house hand, the first card is not available until after the round
        */
        Hand h = new Hand(mShoe.GetNextCard(), DealCard());
        house.AddHand(h);
        HouseUpCard = house.CurrentHand.Cards[1];

        Bet b;
        BettingHand bettingHand;
        foreach (BettingPlayer Gambler in Gamblers)
        {
            b = Gambler.MakeFirstBet(mGameSetting,mShoe.CardsRemaining);
            if (b.Value > mGameSetting.MaximumBet || b.Value < mGameSetting.MinimumBet)
                throw new Exception("Bet is outside betting range");
            bettingHand = new BettingHand(DealCard(), DealCard(), b);
            Gambler.AddHand(bettingHand);
        }
    }
    private void playBettingHands(BettingPlayer[] Gamblers)
    {
        //play the gambler hands
        foreach (BettingPlayer Gambler in Gamblers)
        {
            do
            {
                playBettingHand(Gambler, HouseUpCard);
            } while (Gambler.goToNextHand());
        }
    }
    private void ClearHands(House house, BettingPlayer[] Gamblers)
    {
        //clear the gambler hands
        foreach (BettingPlayer Gambler in Gamblers)
        {
            Gambler.ClearHands();
        }
        //clear the house's hand
        house.ClearHands();
    }
    private void playBettingHand(BettingPlayer p,Card HouseUpCard)
        {
        HandDecision HD;
        do
        {
            HD = p.DetermineNextMove(HouseUpCard);
            switch (HD)
            {
                case HandDecision.Hit:
                    p.CurrentHand.Add(DealCard());
                    break;
                case HandDecision.Split:
                    if (p.CurrentHand.Count > 2)
                        throw new Exception("Cannot split hand with more than 2 cards");
                    if (p.CurrentHand.GetType() != typeof(BettingHand))
                        throw new Exception("Cannot split non betting hand");
                    else SplitHand((BettingPlayer)p);
                    break;
                case HandDecision.Double:
                    if (p.CurrentHand.Count > 2)
                        throw new Exception("Cannot double hand with more than 2 cards");
                    if (p.CurrentHand.GetType() != typeof(BettingHand))
                        throw new Exception("Cannot double non betting hand");
                    (p.CurrentHand).DoubleBet(p.MakeSubsequentBet());
                    p.CurrentHand.Add(DealCard());
                    break;
            }
        } while (HD != HandDecision.Stand &&
                    HD != HandDecision.Double &&
                   !p.CurrentHand.isBusted);
    }
    private void playHouseHand(House h)
    {   
     HandDecision HD;
     do
        {
            HD = h.DetermineNextMove();
            switch (HD)
            {
                case HandDecision.Hit:
                    h.CurrentHand.Add(DealCard());
                    break;
                case HandDecision.Split:
                        throw new Exception("House Cannot Split Hand");
                case HandDecision.Double:
                        throw new Exception("House Cannot Double Hand");
            }
        } while (HD != HandDecision.Stand &&
                   !h.CurrentHand.isBusted);
    }
    private void DisburseWinnings(Hand HouseHand, BettingPlayer[] Gamblers)
    {
        //play the gambler hands
        foreach (BettingPlayer Gambler in Gamblers)
        {
            foreach (BettingHand bh in Gambler.BettingHands)
            {
                //check for player blackjack
                if (bh.isBlackJack)
                    Gambler.RecieveWinnings(bh.BetValue * 2.5);
                //check for house bust
                else if (HouseHand.isBusted && !bh.isBusted)
                    Gambler.RecieveWinnings(bh.BetValue * 2);
                //check for push
                else if (HouseHand.SoftTotal == bh.SoftTotal && !bh.isBusted)
                    Gambler.RecieveWinnings(bh.BetValue);
                //check for player win
                else if (HouseHand.SoftTotal < bh.SoftTotal && !bh.isBusted)
                    Gambler.RecieveWinnings(bh.BetValue);
            }
        }
    }
    private void SplitHand(BettingPlayer p)
    {
        Card c1 = p.CurrentHand.Cards[0];
        Card c2 = p.CurrentHand.Cards[1];
        p.CurrentHand.Remove(c2);
        p.CurrentHand.Add(DealCard());

        BettingHand b = new BettingHand(c2, DealCard(), p.MakeSubsequentBet());
        p.AddHand(b);

    }
    private Card DealCard()
    {   
        /* gets a card and returns a card from the shoe
      raises a cardPlayed event so event subscribers can update their count
    */
        Card c = mShoe.GetNextCard();
        CardPlayed(c, mGameSetting, mShoe.CardsRemaining);
        return c;
    }
}
