namespace Football_Managment
{
    partial class Scoreboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTeam1 = new System.Windows.Forms.Label();
            this.labelTeam2 = new System.Windows.Forms.Label();
            this.labelScore1 = new System.Windows.Forms.Label();
            this.labelScore2 = new System.Windows.Forms.Label();
            this.buttonPreviousMatch = new System.Windows.Forms.Button();
            this.buttonNextMatch = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.labelGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Match Score";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Group";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 38);
            this.label5.TabIndex = 9;
            this.label5.Text = "Vs";
            // 
            // labelTeam1
            // 
            this.labelTeam1.AutoSize = true;
            this.labelTeam1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam1.Location = new System.Drawing.Point(192, 193);
            this.labelTeam1.Name = "labelTeam1";
            this.labelTeam1.Size = new System.Drawing.Size(60, 25);
            this.labelTeam1.TabIndex = 10;
            this.labelTeam1.Text = "Brazil";
            // 
            // labelTeam2
            // 
            this.labelTeam2.AutoSize = true;
            this.labelTeam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeam2.Location = new System.Drawing.Point(436, 193);
            this.labelTeam2.Name = "labelTeam2";
            this.labelTeam2.Size = new System.Drawing.Size(96, 25);
            this.labelTeam2.TabIndex = 11;
            this.labelTeam2.Text = "Argentina";
            // 
            // labelScore1
            // 
            this.labelScore1.AutoSize = true;
            this.labelScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore1.Location = new System.Drawing.Point(210, 248);
            this.labelScore1.Name = "labelScore1";
            this.labelScore1.Size = new System.Drawing.Size(26, 29);
            this.labelScore1.TabIndex = 12;
            this.labelScore1.Text = "0";
            // 
            // labelScore2
            // 
            this.labelScore2.AutoSize = true;
            this.labelScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore2.Location = new System.Drawing.Point(469, 248);
            this.labelScore2.Name = "labelScore2";
            this.labelScore2.Size = new System.Drawing.Size(26, 29);
            this.labelScore2.TabIndex = 13;
            this.labelScore2.Text = "0";
            // 
            // buttonPreviousMatch
            // 
            this.buttonPreviousMatch.Location = new System.Drawing.Point(0, 405);
            this.buttonPreviousMatch.Name = "buttonPreviousMatch";
            this.buttonPreviousMatch.Size = new System.Drawing.Size(158, 33);
            this.buttonPreviousMatch.TabIndex = 14;
            this.buttonPreviousMatch.Text = "Previous Match";
            this.buttonPreviousMatch.UseVisualStyleBackColor = true;
            this.buttonPreviousMatch.Click += new System.EventHandler(this.buttonPreviousMatch_Click);
            // 
            // buttonNextMatch
            // 
            this.buttonNextMatch.Location = new System.Drawing.Point(630, 405);
            this.buttonNextMatch.Name = "buttonNextMatch";
            this.buttonNextMatch.Size = new System.Drawing.Size(158, 33);
            this.buttonNextMatch.TabIndex = 15;
            this.buttonNextMatch.Text = "Next Match";
            this.buttonNextMatch.UseVisualStyleBackColor = true;
            this.buttonNextMatch.Click += new System.EventHandler(this.buttonNextMatch_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 33);
            this.button3.TabIndex = 16;
            this.button3.Text = "<--";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(662, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 33);
            this.button4.TabIndex = 17;
            this.button4.Text = "Group Stage";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(662, 60);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(126, 33);
            this.button6.TabIndex = 17;
            this.button6.Text = "Knockout Stage";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroup.Location = new System.Drawing.Point(388, 91);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(28, 29);
            this.labelGroup.TabIndex = 19;
            this.labelGroup.Text = "A";
            this.labelGroup.Click += new System.EventHandler(this.label2_Click);
            // 
            // Scoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonNextMatch);
            this.Controls.Add(this.buttonPreviousMatch);
            this.Controls.Add(this.labelScore2);
            this.Controls.Add(this.labelScore1);
            this.Controls.Add(this.labelTeam2);
            this.Controls.Add(this.labelTeam1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "Scoreboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scoreboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTeam1;
        private System.Windows.Forms.Label labelTeam2;
        private System.Windows.Forms.Label labelScore1;
        private System.Windows.Forms.Label labelScore2;
        private System.Windows.Forms.Button buttonPreviousMatch;
        private System.Windows.Forms.Button buttonNextMatch;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label labelGroup;
    }
}