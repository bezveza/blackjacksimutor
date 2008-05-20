using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BJ_Play_Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dealer Casino;
        Player House;
        BettingPlayer Gambler;
        private void Form1_Load(object sender, EventArgs e)
        {
            Casino = new Dealer(6);
            House = new Player(new DealerPlayingStrategy());
            Gambler = new BettingPlayer(new BasicPlayingStrategy()
                                        , new BasicBettingStrategy()
                                        , new BasicCountingStrategy()
                                        ,500);
            Gambler.RegisterForDealerEvents(Casino);
            Casino.PlayRound(ref House,ref Gambler);
        }
    }
}