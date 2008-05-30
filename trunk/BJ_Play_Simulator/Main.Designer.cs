namespace BJ_Play_Simulator
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Simulate = new System.Windows.Forms.Button();
            this.cmb_ShoeReload = new System.Windows.Forms.ComboBox();
            this.cmb_ShoeSize = new System.Windows.Forms.ComboBox();
            this.lbl_ShoeSize = new System.Windows.Forms.Label();
            this.lbl_ReloadShoe = new System.Windows.Forms.Label();
            this.lbl_minimumbet = new System.Windows.Forms.Label();
            this.lbl_MaximumBet = new System.Windows.Forms.Label();
            this.lbl_NumberOfHands = new System.Windows.Forms.Label();
            this.txt_NumberofHands = new System.Windows.Forms.TextBox();
            this.txt_MaximumBet = new System.Windows.Forms.TextBox();
            this.txt_MinimumBet = new System.Windows.Forms.TextBox();
            this.lbl_HouseRules = new System.Windows.Forms.Label();
            this.cmb_HouseRules = new System.Windows.Forms.ComboBox();
            this.lbl_working = new System.Windows.Forms.Label();
            this.lbl_roundCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Simulate
            // 
            this.btn_Simulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Simulate.Location = new System.Drawing.Point(298, 12);
            this.btn_Simulate.Name = "btn_Simulate";
            this.btn_Simulate.Size = new System.Drawing.Size(181, 98);
            this.btn_Simulate.TabIndex = 0;
            this.btn_Simulate.Text = "Simulate";
            this.btn_Simulate.UseVisualStyleBackColor = true;
            this.btn_Simulate.Click += new System.EventHandler(this.btn_Simulate_Click);
            // 
            // cmb_ShoeReload
            // 
            this.cmb_ShoeReload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ShoeReload.FormattingEnabled = true;
            this.cmb_ShoeReload.Location = new System.Drawing.Point(111, 38);
            this.cmb_ShoeReload.Name = "cmb_ShoeReload";
            this.cmb_ShoeReload.Size = new System.Drawing.Size(55, 21);
            this.cmb_ShoeReload.TabIndex = 1;
            // 
            // cmb_ShoeSize
            // 
            this.cmb_ShoeSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ShoeSize.FormattingEnabled = true;
            this.cmb_ShoeSize.Location = new System.Drawing.Point(111, 12);
            this.cmb_ShoeSize.Name = "cmb_ShoeSize";
            this.cmb_ShoeSize.Size = new System.Drawing.Size(55, 21);
            this.cmb_ShoeSize.TabIndex = 2;
            // 
            // lbl_ShoeSize
            // 
            this.lbl_ShoeSize.AutoSize = true;
            this.lbl_ShoeSize.Location = new System.Drawing.Point(53, 20);
            this.lbl_ShoeSize.Name = "lbl_ShoeSize";
            this.lbl_ShoeSize.Size = new System.Drawing.Size(55, 13);
            this.lbl_ShoeSize.TabIndex = 3;
            this.lbl_ShoeSize.Text = "Shoe Size";
            // 
            // lbl_ReloadShoe
            // 
            this.lbl_ReloadShoe.AutoSize = true;
            this.lbl_ReloadShoe.Location = new System.Drawing.Point(39, 46);
            this.lbl_ReloadShoe.Name = "lbl_ReloadShoe";
            this.lbl_ReloadShoe.Size = new System.Drawing.Size(69, 13);
            this.lbl_ReloadShoe.TabIndex = 4;
            this.lbl_ReloadShoe.Text = "Shoe Reload";
            // 
            // lbl_minimumbet
            // 
            this.lbl_minimumbet.AutoSize = true;
            this.lbl_minimumbet.Location = new System.Drawing.Point(41, 71);
            this.lbl_minimumbet.Name = "lbl_minimumbet";
            this.lbl_minimumbet.Size = new System.Drawing.Size(67, 13);
            this.lbl_minimumbet.TabIndex = 5;
            this.lbl_minimumbet.Text = "Minimum Bet";
            // 
            // lbl_MaximumBet
            // 
            this.lbl_MaximumBet.AutoSize = true;
            this.lbl_MaximumBet.Location = new System.Drawing.Point(38, 96);
            this.lbl_MaximumBet.Name = "lbl_MaximumBet";
            this.lbl_MaximumBet.Size = new System.Drawing.Size(70, 13);
            this.lbl_MaximumBet.TabIndex = 6;
            this.lbl_MaximumBet.Text = "Maximum Bet";
            // 
            // lbl_NumberOfHands
            // 
            this.lbl_NumberOfHands.AutoSize = true;
            this.lbl_NumberOfHands.Location = new System.Drawing.Point(48, 121);
            this.lbl_NumberOfHands.Name = "lbl_NumberOfHands";
            this.lbl_NumberOfHands.Size = new System.Drawing.Size(60, 13);
            this.lbl_NumberOfHands.TabIndex = 7;
            this.lbl_NumberOfHands.Text = "# of Hands";
            // 
            // txt_NumberofHands
            // 
            this.txt_NumberofHands.Location = new System.Drawing.Point(111, 114);
            this.txt_NumberofHands.Name = "txt_NumberofHands";
            this.txt_NumberofHands.Size = new System.Drawing.Size(100, 20);
            this.txt_NumberofHands.TabIndex = 8;
            // 
            // txt_MaximumBet
            // 
            this.txt_MaximumBet.Location = new System.Drawing.Point(111, 89);
            this.txt_MaximumBet.Name = "txt_MaximumBet";
            this.txt_MaximumBet.Size = new System.Drawing.Size(100, 20);
            this.txt_MaximumBet.TabIndex = 9;
            // 
            // txt_MinimumBet
            // 
            this.txt_MinimumBet.Location = new System.Drawing.Point(111, 64);
            this.txt_MinimumBet.Name = "txt_MinimumBet";
            this.txt_MinimumBet.Size = new System.Drawing.Size(100, 20);
            this.txt_MinimumBet.TabIndex = 10;
            // 
            // lbl_HouseRules
            // 
            this.lbl_HouseRules.AutoSize = true;
            this.lbl_HouseRules.Location = new System.Drawing.Point(40, 143);
            this.lbl_HouseRules.Name = "lbl_HouseRules";
            this.lbl_HouseRules.Size = new System.Drawing.Size(68, 13);
            this.lbl_HouseRules.TabIndex = 11;
            this.lbl_HouseRules.Text = "House Rules";
            // 
            // cmb_HouseRules
            // 
            this.cmb_HouseRules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_HouseRules.FormattingEnabled = true;
            this.cmb_HouseRules.Location = new System.Drawing.Point(111, 140);
            this.cmb_HouseRules.Name = "cmb_HouseRules";
            this.cmb_HouseRules.Size = new System.Drawing.Size(145, 21);
            this.cmb_HouseRules.TabIndex = 12;
            // 
            // lbl_working
            // 
            this.lbl_working.AutoSize = true;
            this.lbl_working.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_working.Location = new System.Drawing.Point(293, 121);
            this.lbl_working.Name = "lbl_working";
            this.lbl_working.Size = new System.Drawing.Size(110, 26);
            this.lbl_working.TabIndex = 13;
            this.lbl_working.Text = "Working...";
            this.lbl_working.Visible = false;
            // 
            // lbl_roundCount
            // 
            this.lbl_roundCount.AutoSize = true;
            this.lbl_roundCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_roundCount.Location = new System.Drawing.Point(397, 121);
            this.lbl_roundCount.Name = "lbl_roundCount";
            this.lbl_roundCount.Size = new System.Drawing.Size(24, 26);
            this.lbl_roundCount.TabIndex = 14;
            this.lbl_roundCount.Text = "0";
            this.lbl_roundCount.Visible = false;
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(496, 444);
            this.Controls.Add(this.lbl_roundCount);
            this.Controls.Add(this.lbl_working);
            this.Controls.Add(this.cmb_HouseRules);
            this.Controls.Add(this.lbl_HouseRules);
            this.Controls.Add(this.txt_MinimumBet);
            this.Controls.Add(this.txt_MaximumBet);
            this.Controls.Add(this.txt_NumberofHands);
            this.Controls.Add(this.lbl_NumberOfHands);
            this.Controls.Add(this.lbl_MaximumBet);
            this.Controls.Add(this.lbl_minimumbet);
            this.Controls.Add(this.lbl_ReloadShoe);
            this.Controls.Add(this.lbl_ShoeSize);
            this.Controls.Add(this.cmb_ShoeSize);
            this.Controls.Add(this.cmb_ShoeReload);
            this.Controls.Add(this.btn_Simulate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Black Jack Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Simulate;
        private System.Windows.Forms.ComboBox cmb_ShoeReload;
        private System.Windows.Forms.ComboBox cmb_ShoeSize;
        private System.Windows.Forms.Label lbl_ShoeSize;
        private System.Windows.Forms.Label lbl_ReloadShoe;
        private System.Windows.Forms.Label lbl_minimumbet;
        private System.Windows.Forms.Label lbl_MaximumBet;
        private System.Windows.Forms.Label lbl_NumberOfHands;
        private System.Windows.Forms.TextBox txt_NumberofHands;
        private System.Windows.Forms.TextBox txt_MaximumBet;
        private System.Windows.Forms.TextBox txt_MinimumBet;
        private System.Windows.Forms.Label lbl_HouseRules;
        private System.Windows.Forms.ComboBox cmb_HouseRules;
        private System.Windows.Forms.Label lbl_working;
        private System.Windows.Forms.Label lbl_roundCount;

    }
}

