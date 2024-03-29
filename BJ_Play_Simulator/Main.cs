using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace BJ_Play_Simulator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        Dealer Casino;
        House house;
        GameSettings GameSetting;
        DataSet AvailableInterfaces = new DataSet("AvailableInterfaces");
        BettingPlayerControl[] GamblerControls = new BettingPlayerControl[4];
        Configuration config = new Configuration();

        struct Configuration
        {
            public int MaximumShoeSize;
            public int MinimumShoeSize;
            public int DefaultShoeSize;
            public int DefaultReloadSize;
            public int MaximumPlayingRound;
            public int MinimumPlayingRound;
            public int DefaultPlayingRound;
            public int DefaultBankroll;
            public bool DefaultActive;
            public int DefaultMinimumBet;
            public int DefaultMaximumBet;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConfigurationValues();
            LoadAvailableInterfaces();
            LoadGamblerControls();
            SetFormValuesAndDefaults();           
            
            //Casino = new Dealer(6);
            //House = new Player(new DealerPlayingStrategy());
            //Gambler = new BettingPlayer(new BasicPlayingStrategy()
             //                           , new BasicBettingStrategy()
               //                         , new BasicCountingStrategy()
                 //                       ,500);
          //  Gambler.RegisterForDealerEvents(Casino);
           // Casino.PlayRound(ref House,ref Gambler);
        }
        private void LoadAvailableInterfaces()
        {
            XmlTextReader InterfaceReader = new XmlTextReader("Resources\\Interfaces.xml");
            AvailableInterfaces.ReadXml(InterfaceReader);
        }
        private void LoadGamblerControls()
        {
            int Hpos = 0;
            int VPos = 179;
            BettingPlayerControl BC;
            for (int i = 0; i < 4; i++)
            {
                BC = new BettingPlayerControl(config.DefaultActive
                    ,config.DefaultBankroll
                    , "Player " + (i +1).ToString());
                BC.Location = new Point(Hpos, VPos);
                BC.BindStrategyControls(AvailableInterfaces);
                GamblerControls[i] = BC;
                this.Controls.Add(BC);
                Hpos += 250;
                if (Hpos == 500)
                {
                    VPos += 140;
                    Hpos = 0;
                }
            }

        }
        private void LoadConfigurationValues()
        {
            //XmlTextReader ConfigReader = new XmlTextReader("Resources\\Configuration.xml");
            XPathDocument doc = new XPathDocument("Resources\\Configuration.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            config.MaximumShoeSize = Convert.ToInt32(navigator.SelectSingleNode("//Configs/Shoe/MaximumShoeSize").InnerXml);
            config.MinimumShoeSize = Convert.ToInt32(navigator.SelectSingleNode("//Configs/Shoe/MinimumShoeSize").InnerXml);
            config.DefaultShoeSize = Convert.ToInt32(navigator.SelectSingleNode("//Configs/Shoe/DefaultShoeSize").InnerXml);
            config.DefaultReloadSize = Convert.ToInt32(navigator.SelectSingleNode("//Configs/Shoe/DefaultReloadSize").InnerXml);
            config.MaximumPlayingRound = Convert.ToInt32(navigator.SelectSingleNode("//Configs/PlayingRound/MaximumPlayingRound").InnerXml);
            config.MinimumPlayingRound = Convert.ToInt32(navigator.SelectSingleNode("//Configs/PlayingRound/MinimumPlayingRound").InnerXml);
            config.DefaultPlayingRound = Convert.ToInt32(navigator.SelectSingleNode("//Configs/PlayingRound/DefaultPlayingRound").InnerXml);
            config.DefaultBankroll = Convert.ToInt32(navigator.SelectSingleNode("//Configs/Player/DefaultBankroll").InnerXml);
            config.DefaultActive = (Convert.ToInt32(navigator.SelectSingleNode("//Configs/Player/DefaultActive").InnerXml) != 0);
            config.DefaultMinimumBet = Convert.ToInt32(navigator.SelectSingleNode("//Configs/Betting/DefaultMinimumBet").InnerXml);
            config.DefaultMaximumBet = Convert.ToInt32(navigator.SelectSingleNode("//Configs/Betting/DefaultMaximumBet").InnerXml);
        }
        private void LoadGameSetting()
        {
            GameSetting = new GameSettings((int)cmb_ShoeSize.SelectedItem
                ,(int)cmb_ShoeReload.SelectedItem
                ,int.Parse(txt_MinimumBet.Text)
                ,int.Parse(txt_MaximumBet.Text)
                ,int.Parse(txt_NumberofHands.Text));
        }
        private void SetFormValuesAndDefaults()
        {
            cmb_HouseRules.DataSource = AvailableInterfaces.Tables["HouseRule"];
            cmb_HouseRules.DisplayMember = "DisplayName";
            cmb_HouseRules.ValueMember = "ClassName";

            txt_MaximumBet.Text = config.DefaultMaximumBet.ToString();
            txt_MinimumBet.Text = config.DefaultMinimumBet.ToString();
            txt_NumberofHands.Text = config.DefaultPlayingRound.ToString();

            for (int i = config.MinimumShoeSize; i <= config.MaximumShoeSize; i++)
            {
                cmb_ShoeReload.Items.Add(i);
                cmb_ShoeSize.Items.Add(i);
                if (i == config.DefaultReloadSize) cmb_ShoeReload.SelectedIndex = i - 1;
                if (i == config.DefaultShoeSize) cmb_ShoeSize.SelectedIndex = i - 1;
            }
        }
        private void UpdateBankrollDisplays()
        {
            foreach(BettingPlayerControl BPC in GamblerControls)
            {
                BPC.UpdateBankrollDisplay();
            }
        }
        private bool ValidateFormInputs()
        {
            try
            {
               ValidationHelpers.ValidatePositiveInt(txt_MaximumBet.Text,"Maximum Bet");
               ValidationHelpers.ValidatePositiveInt(txt_MinimumBet.Text, "Minimum Bet");
               ValidationHelpers.ValidatePositiveInt(txt_NumberofHands.Text, "# of hands");

               ValidationHelpers.IntInRange(int.Parse(txt_NumberofHands.Text),config.MinimumPlayingRound,config.MaximumPlayingRound, "# of hands");
               ValidationHelpers.IntInRange(int.Parse(txt_MinimumBet.Text), 1, int.Parse(txt_MaximumBet.Text), "Minimum Bet");

               ValidationHelpers.IntInRange((int)cmb_ShoeReload.SelectedItem, config.MinimumShoeSize, (int)cmb_ShoeSize.SelectedItem - 1, "Shoe Reload");

               foreach (BettingPlayerControl bc in GamblerControls)
               {
                   bc.ValidateControls();
               }
               
                return true;
            }
            catch (ArgumentException e)
            {
                //MessageBox.Show(string.Format("'{0}': '{1}'", e.ParamName., e.Message));
                MessageBox.Show(e.Message);
                return false;
            }
        }
        private void ToggleSystemEnabled(bool enabled)
        {
            if (enabled)
                this.Cursor = Cursors.Arrow;
            else
                this.Cursor = Cursors.WaitCursor;

            lbl_working.Visible = !enabled;
            lbl_roundCount.Visible = !enabled;
               
            
            foreach(Control c in this.Controls)
            {
                if (c.Name != "lbl_working" && c.Name != "lbl_roundCount")
                    c.Enabled = enabled;
            }

            this.Refresh();
        }
        private void btn_Simulate_Click(object sender, EventArgs e)
        {
            if (ValidateFormInputs())
            {
                try
                {
                    ToggleSystemEnabled(false);
                    IHouseRules IHR;
                    Type t = Type.GetType(cmb_HouseRules.SelectedValue.ToString());
                    IHR = (IHouseRules)Activator.CreateInstance(t);
                    house = new House(IHR);

                    Table table = new Table(house);
                    foreach (BettingPlayerControl bc in GamblerControls)
                    {
                        if (bc.ActiveChecked)
                        {
                            table.addGambler(bc.CreateBettingPlayer());
                        }
                    }
                    if (table.Gamblers.Length > 0)
                    {
                        LoadGameSetting();
                        Casino = new Dealer(GameSetting);

                        foreach (BettingPlayer Gambler in table.Gamblers)
                        {
                            Gambler.RegisterForDealerEvents(Casino);
                        }



                        for (int i = 1; i <= GameSetting.BettingRounds; i++)
                        {
                            //give the user a rounds play count
                            if (i % 2500 == 0 || i == GameSetting.BettingRounds)
                            {
                                lbl_roundCount.Text = i.ToString();
                                lbl_roundCount.Refresh();
                            }
                            Casino.PlayRound(table);
                            table.RemoveBankruptPlayers(GameSetting.MinimumBet);
                        }
                        UpdateBankrollDisplays();
                    }
                    else MessageBox.Show("Please select at least one player");

                }
                finally
                {
                    ToggleSystemEnabled(true);
                    lbl_roundCount.Text = "0";
                }
                }
            }

        private void lbl_ReloadBankrolls_Click(object sender, EventArgs e)
        {
            foreach (BettingPlayerControl BC in GamblerControls)
            {
                BC.ResetDefaultBankroll();
            }
        }
      }
}