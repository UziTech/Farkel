namespace Farkel
{
    partial class Farkel
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
            this.components = new System.ComponentModel.Container();
            this.Roll = new System.Windows.Forms.Button();
            this.Done = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NGplayers = new System.Windows.Forms.ToolStripMenuItem[5];
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.L = new System.Windows.Forms.Label[6];
            this.H = new System.Windows.Forms.Label[6];
            this.S = new System.Windows.Forms.Label[6];
            this.TB = new System.Windows.Forms.TextBox[6];
            this.RoundScore = new System.Windows.Forms.Label();
            this.diceRoll = new System.Windows.Forms.Timer(this.components);
            this.compWait = new System.Windows.Forms.Timer(this.components);
            this.RollScore = new System.Windows.Forms.Label();
            this.D = new System.Windows.Forms.PictureBox[6];
            this.HighStakes = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            for (int i = 0; i < 6; i++)
            {
                if (i < 5)
                {
                    this.NGplayers[i] = new System.Windows.Forms.ToolStripMenuItem();
                }
                this.H[i] = new System.Windows.Forms.Label();
                this.TB[i] = new System.Windows.Forms.TextBox();
                this.L[i] = new System.Windows.Forms.Label();
                this.S[i] = new System.Windows.Forms.Label();
                this.D[i] = new System.Windows.Forms.PictureBox();
                ((System.ComponentModel.ISupportInitialize)(D[i])).BeginInit();
            }
            this.SuspendLayout();
            // 
            // Roll
            // 
            this.Roll.BackColor = System.Drawing.Color.White;
            this.Roll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Roll.Location = new System.Drawing.Point(166, 200);
            this.Roll.Name = "Roll";
            this.Roll.Size = new System.Drawing.Size(50, 23);
            this.Roll.TabIndex = 6;
            this.Roll.Text = "Roll!";
            this.Roll.UseVisualStyleBackColor = false;
            this.Roll.Click += new System.EventHandler(this.Roll_Click);
            // 
            // Done
            // 
            this.Done.BackColor = System.Drawing.Color.White;
            this.Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Done.ForeColor = System.Drawing.Color.Maroon;
            this.Done.Location = new System.Drawing.Point(223, 200);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(50, 23);
            this.Done.TabIndex = 7;
            this.Done.Text = "End Turn";
            this.Done.UseVisualStyleBackColor = false;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Click += new System.EventHandler(this.Farkel_Click);
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.Farkel_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NGplayers[0],
            this.NGplayers[1],
            this.NGplayers[2],
            this.NGplayers[3],
            this.NGplayers[4]});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            //
            // NGplayers[]
            //
            for (int i = 0; i < 5; i++)
            {
                this.NGplayers[i].Name = "NGplayers" + (i + 2);
                this.NGplayers[i].Size = new System.Drawing.Size(120, 22);
                this.NGplayers[i].Text = (i + 2) + " Players";
                this.NGplayers[i].Click += new System.EventHandler(this.NGplayers_Click);
            }
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // RS
            // 
            this.RoundScore.AutoSize = true;
            this.RoundScore.ForeColor = System.Drawing.Color.Blue;
            this.RoundScore.Location = new System.Drawing.Point(29, 204);
            this.RoundScore.Name = "RoundScore";
            this.RoundScore.Size = new System.Drawing.Size(82, 13);
            this.RoundScore.TabIndex = 27;
            this.RoundScore.Text = "Round Score: 0";
            this.RoundScore.Click += new System.EventHandler(this.Farkel_Click);
            // 
            // diceRoll
            // 
            this.diceRoll.Interval = 50;
            this.diceRoll.Tick += new System.EventHandler(this.diceRoll_Tick);
            // 
            // compWait
            // 
            this.compWait.Interval = 1000;
            this.compWait.Tick += new System.EventHandler(this.compWait_Tick);
            // 
            // RoS
            // 
            this.RollScore.AutoSize = true;
            this.RollScore.ForeColor = System.Drawing.Color.Green;
            this.RollScore.Location = new System.Drawing.Point(32, 188);
            this.RollScore.Name = "RollScore";
            this.RollScore.Size = new System.Drawing.Size(68, 13);
            this.RollScore.TabIndex = 33;
            this.RollScore.Text = "Roll Score: 0";
            this.RollScore.Click += new System.EventHandler(this.Farkel_Click);
            // 
            // D[]
            // 
            this.D[0].Image = global::Farkel.Properties.Resources.Fdie;
            this.D[1].Image = global::Farkel.Properties.Resources.Adie;
            this.D[2].Image = global::Farkel.Properties.Resources.Rdie;
            this.D[3].Image = global::Farkel.Properties.Resources.Kdie;
            this.D[4].Image = global::Farkel.Properties.Resources.Edie;
            this.D[5].Image = global::Farkel.Properties.Resources.Ldie;
            //
            // HighStakes
            //
            this.HighStakes.Name = "HighStakes";
            this.HighStakes.Text = "High Stakes";
            this.HighStakes.TabIndex = 34;
            this.HighStakes.TabStop = false;
            this.HighStakes.Location = new System.Drawing.Point(180, 1);
            this.HighStakes.Visible = false;
            // 
            // Farkel
            // 
            this.AcceptButton = this.Roll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Icon = global::Farkel.Properties.Resources.Farkel;
            this.Controls.Add(this.RollScore);
            this.Click += new System.EventHandler(Farkel_Click);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            //
            // L[]
            // H[]
            // S[]
            // TB[]
            // D[]
            //
            this.L[0].Text = global::Farkel.Properties.Settings.Default.player1;
            this.L[1].Text = global::Farkel.Properties.Settings.Default.player2;
            this.L[2].Text = global::Farkel.Properties.Settings.Default.player3;
            this.L[3].Text = global::Farkel.Properties.Settings.Default.player4;
            this.L[4].Text = global::Farkel.Properties.Settings.Default.player5;
            this.L[5].Text = global::Farkel.Properties.Settings.Default.player6;
            this.H[0].Text = ((Properties.Settings.Default.Comp1) ? "C" : "H");
            this.H[1].Text = ((Properties.Settings.Default.Comp2) ? "C" : "H");
            this.H[2].Text = ((Properties.Settings.Default.Comp3) ? "C" : "H");
            this.H[3].Text = ((Properties.Settings.Default.Comp4) ? "C" : "H");
            this.H[4].Text = ((Properties.Settings.Default.Comp5) ? "C" : "H");
            this.H[5].Text = ((Properties.Settings.Default.Comp6) ? "C" : "H");
            for (int i = 0; i < 6; i++)
            {
                this.L[i].AutoSize = true;
                this.L[i].Location = new System.Drawing.Point(12 + (i % 2) * 73, 39 + (i / 2) * 56);
                this.L[i].Name = "L" + (i + 1);
                this.L[i].Size = new System.Drawing.Size(45, 13);
                this.L[i].TabIndex = 10;
                this.L[i].Click += new System.EventHandler(this.L_Click);
                this.H[i].AutoSize = true;
                this.H[i].Location = new System.Drawing.Point(2 + (i % 2) * 73, 39 + (i / 2) * 56);
                this.H[i].Name = "H" + (i + 1);
                this.H[i].Size = new System.Drawing.Size(12, 13);
                this.H[i].TabIndex = 10;
                this.H[i].ForeColor = System.Drawing.Color.Blue;
                this.H[i].Click += new System.EventHandler(this.H_Click);
                this.S[i].AutoSize = true;
                this.S[i].Location = new System.Drawing.Point(12 + (i % 2) * 73, 52 + (i / 2) * 56);
                this.S[i].Name = "S" + (i + 1);
                this.S[i].Size = new System.Drawing.Size(41, 13);
                this.S[i].TabIndex = 15;
                this.S[i].Text = "";
                this.TB[i].Location = new System.Drawing.Point(12 + (i % 2) * 73, 36 + (i / 2) * 56);
                this.TB[i].Name = "TB" + (i + 1);
                this.TB[i].Size = new System.Drawing.Size(66, 20);
                this.TB[i].TabIndex = 0;
                this.TB[i].Visible = false;
                this.D[i].BackColor = System.Drawing.Color.White;
                this.D[i].BackgroundImage = Properties.Resources.Wdie;
                this.D[i].BackgroundImage.Tag = "White";
                this.D[i].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                this.D[i].Location = new System.Drawing.Point(163 + (i % 2) * 58, 24 + (i / 2) * 58);
                this.D[i].Name = "D" + (i + 1);
                this.D[i].Size = new System.Drawing.Size(56, 56);
                this.D[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                this.D[i].TabIndex = 13;
                this.D[i].TabStop = false;
                this.D[i].Click += new System.EventHandler(this.D_Click);
                this.Controls.Add(this.D[i]);
                this.Controls.Add(this.L[i]);
                this.Controls.Add(this.H[i]);
                this.Controls.Add(this.TB[i]);
                this.Controls.Add(this.S[i]);
                ((System.ComponentModel.ISupportInitialize)(this.D[i])).EndInit();
            }
            this.Controls.Add(this.RoundScore);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.Roll);
            this.Controls.Add(this.HighStakes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Farkel";
            this.ShowIcon = true;
            this.Text = "Farkel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Roll;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label[] L;
        private System.Windows.Forms.Label[] S;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem[] NGplayers;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox[] TB;
        private System.Windows.Forms.Label RoundScore;
        private System.Windows.Forms.PictureBox[] D;
        private System.Windows.Forms.Timer diceRoll;
        private System.Windows.Forms.Timer compWait;
        private System.Windows.Forms.Label RollScore;
        private System.Windows.Forms.CheckBox HighStakes;
        private System.Windows.Forms.Label[] H;

    }
}

