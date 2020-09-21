namespace GameSimon
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRed = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblRound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.DarkRed;
            this.btnRed.Enabled = false;
            this.btnRed.Location = new System.Drawing.Point(18, 22);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(165, 152);
            this.btnRed.TabIndex = 0;
            this.btnRed.Tag = "Red";
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            this.btnRed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRed_MouseDown);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGreen.Enabled = false;
            this.btnGreen.Location = new System.Drawing.Point(206, 22);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(165, 152);
            this.btnGreen.TabIndex = 1;
            this.btnGreen.Tag = "Green";
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            this.btnGreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnGreen_MouseDown);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Gold;
            this.btnYellow.Enabled = false;
            this.btnYellow.Location = new System.Drawing.Point(206, 196);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(165, 152);
            this.btnYellow.TabIndex = 3;
            this.btnYellow.Tag = "Yellow";
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            this.btnYellow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnYellow_MouseDown);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.DarkBlue;
            this.btnBlue.Enabled = false;
            this.btnBlue.Location = new System.Drawing.Point(18, 196);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(165, 152);
            this.btnBlue.TabIndex = 2;
            this.btnBlue.Tag = "Blue";
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            this.btnBlue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBlue_MouseDown);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(105, 400);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(167, 37);
            this.btnNewGame.TabIndex = 4;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnRecords
            // 
            this.btnRecords.Location = new System.Drawing.Point(105, 443);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(167, 37);
            this.btnRecords.TabIndex = 5;
            this.btnRecords.Text = "Records";
            this.btnRecords.UseVisualStyleBackColor = true;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(105, 486);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(167, 37);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(160, 367);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(0, 13);
            this.lblRound.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 535);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRecords);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnYellow);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.btnRed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblRound;
    }
}

