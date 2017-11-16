using System.Drawing;
using System;

namespace B17_Ex05_Amir_305296238_Yinon_305763641
{

    partial class FormChooseColor
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
            this.purpleButton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.cyanButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.brownButton = new System.Windows.Forms.Button();
            this.whiteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // purpleButton
            // 
            this.purpleButton.BackColor = Color.Purple;
            this.purpleButton.Location = new Point(21, 46);
            this.purpleButton.Margin = new System.Windows.Forms.Padding(2);
            this.purpleButton.Name = "purpleButton";
            this.purpleButton.Size = new Size(55, 52);
            this.purpleButton.TabIndex = 12;
            this.purpleButton.UseVisualStyleBackColor = false;
            this.purpleButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // redButton
            // 
            this.redButton.BackColor = Color.Red;
            this.redButton.Location = new Point(80, 46);
            this.redButton.Margin = new System.Windows.Forms.Padding(2);
            this.redButton.Name = "redButton";
            this.redButton.Size = new Size(55, 52);
            this.redButton.TabIndex = 13;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // greenButton
            // 
            this.greenButton.BackColor = Color.SpringGreen;
            this.greenButton.Location = new Point(139, 46);
            this.greenButton.Margin = new System.Windows.Forms.Padding(2);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new Size(55, 52);
            this.greenButton.TabIndex = 14;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // cyanButton
            // 
            this.cyanButton.BackColor = System.Drawing.Color.Cyan;
            this.cyanButton.Location = new System.Drawing.Point(198, 46);
            this.cyanButton.Margin = new System.Windows.Forms.Padding(2);
            this.cyanButton.Name = "cyanButton";
            this.cyanButton.Size = new System.Drawing.Size(55, 52);
            this.cyanButton.TabIndex = 15;
            this.cyanButton.UseVisualStyleBackColor = false;
            this.cyanButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // blueButton
            // 
            this.blueButton.BackColor = Color.Blue;
            this.blueButton.Location = new Point(21, 114);
            this.blueButton.Margin = new System.Windows.Forms.Padding(2);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new Size(55, 52);
            this.blueButton.TabIndex = 16;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = Color.Yellow;
            this.yellowButton.Location = new Point(80, 114);
            this.yellowButton.Margin = new System.Windows.Forms.Padding(2);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new Size(55, 52);
            this.yellowButton.TabIndex = 17;
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // brownButton
            // 
            this.brownButton.BackColor = Color.Brown;
            this.brownButton.Location = new Point(139, 114);
            this.brownButton.Margin = new System.Windows.Forms.Padding(2);
            this.brownButton.Name = "brownButton";
            this.brownButton.Size = new Size(55, 52);
            this.brownButton.TabIndex = 18;
            this.brownButton.UseVisualStyleBackColor = false;
            this.brownButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // whiteButton
            // 
            this.whiteButton.BackColor = Color.White;
            this.whiteButton.Location = new Point(198, 114);
            this.whiteButton.Margin = new System.Windows.Forms.Padding(2);
            this.whiteButton.Name = "whiteButton";
            this.whiteButton.Size = new Size(55, 52);
            this.whiteButton.TabIndex = 19;
            this.whiteButton.UseVisualStyleBackColor = false;
            this.whiteButton.Click += new System.EventHandler(this.colorButton_Clicked);

            // 
            // FormChooseColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 245);
            this.Controls.Add(this.whiteButton);
            this.Controls.Add(this.brownButton);
            this.Controls.Add(this.yellowButton);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.cyanButton);
            this.Controls.Add(this.greenButton);
            this.Controls.Add(this.redButton);
            this.Controls.Add(this.purpleButton);
            this.Name = "FormChooseColor";
            this.Text = "FormChooseColor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button purpleButton;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button cyanButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Button brownButton;
        private System.Windows.Forms.Button whiteButton;
    }
}