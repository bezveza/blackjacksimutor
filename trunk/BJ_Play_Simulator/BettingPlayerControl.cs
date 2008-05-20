using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace BJ_Play_Simulator
{
    public partial class BettingPlayerControl : UserControl
    {
        private BettingPlayer Gambler;
        public bool ActiveChecked;

        public BettingPlayerControl(bool Active, int bankroll,string playerName)
        {
            InitializeComponent();
            chb_Active.Checked = Active;
            ActiveChecked = Active;
            txt_Bankroll.Text = bankroll.ToString();
            lbl_playerName.Text = playerName;
        }

        private void chb_Active_CheckedChanged(object sender, EventArgs e)
        {
            ActiveChecked= chb_Active.Checked;
            cmb_bet.Enabled = ActiveChecked;
            cmb_play.Enabled = ActiveChecked;
            cmb_count.Enabled = ActiveChecked;
            txt_Bankroll.Enabled = ActiveChecked;
        }

        public void ValidateControls()
        {
            if (this.chb_Active.Checked)
            {
                ValidationHelpers.ValidatePositiveInt(txt_Bankroll.Text,"Bankroll");
            }
        }
        public void BindStrategyControls(DataSet ds)
        {
            cmb_bet.DataSource = ds.Tables["BettingStrategy"];
            cmb_bet.DisplayMember = "DisplayName";
            cmb_bet.ValueMember = "ClassName";

            cmb_play.DataSource = ds.Tables["PlayingStrategy"];
            cmb_play.DisplayMember = "DisplayName";
            cmb_play.ValueMember = "ClassName";

            cmb_count.DataSource = ds.Tables["CountingStrategy"];
            cmb_count.DisplayMember = "DisplayName";
            cmb_count.ValueMember = "ClassName";
        }

        public BettingPlayer CreateBettingPlayer()
        {
            IBettingStrategy IBS;
            ICountingStrategy ICS;
            IPlayingStrategy IPS;

            Type t = Type.GetType(cmb_bet.SelectedValue.ToString());
            IBS = (IBettingStrategy)Activator.CreateInstance(t);

            t = Type.GetType(cmb_play.SelectedValue.ToString());
            IPS = (IPlayingStrategy)Activator.CreateInstance(t);

            t = Type.GetType(cmb_count.SelectedValue.ToString());
            ICS = (ICountingStrategy)Activator.CreateInstance(t);
            
            Gambler = new BettingPlayer(IPS, IBS, ICS, int.Parse(txt_Bankroll.Text));
            return Gambler;
        }
        public void UpdateBankrollDisplay()
        {
            if (Gambler != null)
                txt_Bankroll.Text = Gambler.bankRoll.Value.ToString();
        }
    }
}