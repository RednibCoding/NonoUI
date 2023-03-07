namespace NonoUI_Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.controlButton1 = new NonoUI.Controls.ControlButton();
            this.controlButton2 = new NonoUI.Controls.ControlButton();
            this.controlButton3 = new NonoUI.Controls.ControlButton();
            this.dragPanel1 = new NonoUI.Controls.DragPanel();
            this.resizeBehavior1 = new NonoUI.Other.ResizeBehavior();
            this.SuspendLayout();
            // 
            // controlButton1
            // 
            this.controlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton1.AutoSize = true;
            this.controlButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlButton1.ControlType = NonoUI.Controls.ControlButton.ButtonType.Close;
            this.controlButton1.FlatAppearance.BorderSize = 0;
            this.controlButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton1.Location = new System.Drawing.Point(749, 1);
            this.controlButton1.Name = "controlButton1";
            this.controlButton1.Size = new System.Drawing.Size(51, 47);
            this.controlButton1.TabIndex = 1;
            this.controlButton1.UseVisualStyleBackColor = true;
            // 
            // controlButton2
            // 
            this.controlButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton2.AutoSize = true;
            this.controlButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlButton2.ControlType = NonoUI.Controls.ControlButton.ButtonType.Maximize;
            this.controlButton2.FlatAppearance.BorderSize = 0;
            this.controlButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton2.Location = new System.Drawing.Point(692, 1);
            this.controlButton2.Name = "controlButton2";
            this.controlButton2.Size = new System.Drawing.Size(51, 47);
            this.controlButton2.TabIndex = 2;
            this.controlButton2.UseVisualStyleBackColor = true;
            // 
            // controlButton3
            // 
            this.controlButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton3.AutoSize = true;
            this.controlButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.controlButton3.ControlType = NonoUI.Controls.ControlButton.ButtonType.Minimize;
            this.controlButton3.FlatAppearance.BorderSize = 0;
            this.controlButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton3.Location = new System.Drawing.Point(635, 1);
            this.controlButton3.Name = "controlButton3";
            this.controlButton3.Size = new System.Drawing.Size(51, 47);
            this.controlButton3.TabIndex = 3;
            this.controlButton3.UseVisualStyleBackColor = true;
            // 
            // dragPanel1
            // 
            this.dragPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dragPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dragPanel1.Location = new System.Drawing.Point(12, 12);
            this.dragPanel1.Name = "dragPanel1";
            this.dragPanel1.Size = new System.Drawing.Size(613, 51);
            this.dragPanel1.TabIndex = 4;
            this.dragPanel1.TargetForm = this;
            // 
            // resizeBehavior1
            // 
            this.resizeBehavior1.TargetForm = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dragPanel1);
            this.Controls.Add(this.controlButton3);
            this.Controls.Add(this.controlButton2);
            this.Controls.Add(this.controlButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NonoUI.Controls.ControlButton controlButton3;
        private NonoUI.Controls.ControlButton controlButton2;
        private NonoUI.Controls.ControlButton controlButton1;
        private NonoUI.Controls.DragPanel dragPanel1;
        private NonoUI.Other.ResizeBehavior resizeBehavior1;
    }
}