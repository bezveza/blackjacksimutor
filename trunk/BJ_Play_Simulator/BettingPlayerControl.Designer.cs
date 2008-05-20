namespace BJ_Play_Simulator
{
    partial class BettingPlayerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chb_Active = new System.Windows.Forms.CheckBox();
            this.cmb_bet = new System.Windows.Forms.ComboBox();
            this.cmb_count = new System.Windows.Forms.ComboBox();
            this.cmb_play = new System.Windows.Forms.ComboBox();
            this.lbl_bet = new System.Windows.Forms.Label();
            this.lbl_Count = new System.Windows.Forms.Label();
            this.lbl_play = new System.Windows.Forms.Label();
            this.lbl_bankroll = new System.Windows.Forms.Label();
            this.txt_Bankroll = new System.Windows.Forms.TextBox();
            this.lbl_playerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chb_Active
            // 
            this.chb_Active.AutoSize = true;
            this.chb_Active.Checked = true;
            this.chb_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_Active.Location = new System.Drawing.Point(14, 3);
            this.chb_Active.Name = "chb_Active";
            this.chb_Active.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chb_Active.Size = new System.Drawing.Size(56, 17);
            this.chb_Active.TabIndex = 0;
            this.chb_Active.Text = "Active";
            this.chb_Active.UseVisualStyleBackColor = true;
            this.chb_Active.CheckedChanged += new System.EventHandler(this.chb_Active_CheckedChanged);
            // 
            // cmb_bet
            // 
            this.cmb_bet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_bet.FormattingEnabled = true;
            this.cmb_bet.Location = new System.Drawing.Point(56, 24);
            this.cmb_bet.Name = "cmb_bet";
            this.cmb_bet.Size = new System.Drawing.Size(174, 21);
            this.cmb_bet.TabIndex = 1;
            // 
            // cmb_count
            // 
            this.cmb_count.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_count.FormattingEnabled = true;
            this.cmb_count.Location = new System.Drawing.Point(56, 49);
            this.cmb_count.Name = "cmb_count";
            this.cmb_count.Size = new System.Drawing.Size(174, 21);
            this.cmb_count.TabIndex = 2;
            // 
            // cmb_play
            // 
            this.cmb_play.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_play.FormattingEnabled = true;
            this.cmb_play.Location = new System.Drawing.Point(56, 74);
            this.cmb_play.Name = "cmb_play";
            this.cmb_play.Size = new System.Drawing.Size(174, 21);
            this.cmb_play.TabIndex = 3;
            // 
            // lbl_bet
            // 
            this.lbl_bet.AutoSize = true;
            this.lbl_bet.Location = new System.Drawing.Point(14, 32);
            this.lbl_bet.Name = "lbl_bet";
            this.lbl_bet.Size = new System.Drawing.Size(40, 13);
            this.lbl_bet.TabIndex = 4;
            this.lbl_bet.Text = "Betting";
            // 
            // lbl_Count
            // 
            this.lbl_Count.AutoSize = true;
            this.lbl_Count.Location = new System.Drawing.Point(5, 57);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(49, 13);
            this.lbl_Count.TabIndex = 5;
            this.lbl_Count.Text = "Counting";
            // 
            // lbl_play
            // 
            this.lbl_play.AutoSize = true;
            this.lbl_play.Location = new System.Drawing.Point(13, 82);
            this.lbl_play.Name = "lbl_play";
            this.lbl_play.Size = new System.Drawing.Size(41, 13);
            this.lbl_play.TabIndex = 6;
            this.lbl_play.Text = "Playing";
            // 
            // lbl_bankroll
            // 
            this.lbl_bankroll.AutoSize = true;
            this.lbl_bankroll.Location = new System.Drawing.Point(9, 107);
            this.lbl_bankroll.Name = "lbl_bankroll";
            this.lbl_bankroll.Size = new System.Drawing.Size(45, 13);
            this.lbl_bankroll.TabIndex = 7;
            this.lbl_bankroll.Text = "Bankroll";
            // 
            // txt_Bankroll
            // 
            this.txt_Bankroll.Location = new System.Drawing.Point(56, 99);
            this.txt_Bankroll.Name = "txt_Bankroll";
            this.txt_Bankroll.Size = new System.Drawing.Size(174, 20);
            this.txt_Bankroll.TabIndex = 8;
            // 
            // lbl_playerName
            // 
            this.lbl_playerName.AutoSize = true;
            this.lbl_playerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_playerName.Location = new System.Drawing.Point(152, 3);
            this.lbl_playerName.Name = "lbl_playerName";
            this.lbl_playerName.Size = new System.Drawing.Size(78, 13);
            this.lbl_playerName.TabIndex = 9;
            this.lbl_playerName.Text = "Player Name";
            this.lbl_playerName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BettingPlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_playerName);
            this.Controls.Add(this.txt_Bankroll);
            this.Controls.Add(this.lbl_bankroll);
            this.Controls.Add(this.lbl_play);
            this.Controls.Add(this.lbl_Count);
            this.Controls.Add(this.lbl_bet);
            this.Controls.Add(this.cmb_play);
            this.Controls.Add(this.cmb_count);
            this.Controls.Add(this.cmb_bet);
            this.Controls.Add(this.chb_Active);
            this.Name = "BettingPlayerControl";
            this.Size = new System.Drawing.Size(249, 137);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chb_Active;
        private System.Windows.Forms.ComboBox cmb_bet;
        private System.Windows.Forms.ComboBox cmb_count;
        private System.Windows.Forms.ComboBox cmb_play;
        private System.Windows.Forms.Label lbl_bet;
        private System.Windows.Forms.Label lbl_Count;
        private System.Windows.Forms.Label lbl_play;
        private System.Windows.Forms.Label lbl_bankroll;
        private System.Windows.Forms.TextBox txt_Bankroll;
        private System.Windows.Forms.Label lbl_playerName;
    }
}
