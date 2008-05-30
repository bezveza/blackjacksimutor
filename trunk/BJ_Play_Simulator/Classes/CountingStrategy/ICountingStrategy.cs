using System;
using System.Collections;

    public interface ICountingStrategy
    {

        void UpdateCount(GameSettings GameSetting
                         ,int CardsRemaining
                         ,Card card);

        void setBeginngingCount();

        Hashtable getCountingObjects();


    }

