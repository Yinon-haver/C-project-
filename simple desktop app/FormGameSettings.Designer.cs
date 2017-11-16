namespace B17_Ex05_Amir_305296238_Yinon_305763641
{
    partial class FormGameSettings
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
            this.startButton = new System.Windows.Forms.Button();
            this.numberOfChancesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(128, 193);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "buttonStart";
            this.startButton.Size = new System.Drawing.Size(130, 31);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Clicked);
            // 
            // numberOfChancesButton
            // 
            this.numberOfChancesButton.Location = new System.Drawing.Point(45, 68);
            this.numberOfChancesButton.Margin = new System.Windows.Forms.Padding(2);
            this.numberOfChancesButton.Name = "numberOfChances";
            this.numberOfChancesButton.Size = new System.Drawing.Size(213, 31);
            this.numberOfChancesButton.TabIndex = 12;
            this.numberOfChancesButton.Text = "Number of chances: 4";
            this.numberOfChancesButton.UseVisualStyleBackColor = true;
            this.numberOfChancesButton.Click += new System.EventHandler(this.numberOfChancesButton_Clicked);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 245);
            this.Controls.Add(this.numberOfChancesButton);
            this.Controls.Add(this.startButton);
            this.Name = "FormGameSettings";
            this.Text = "Bool Pgia";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button numberOfChancesButton;
    }
}