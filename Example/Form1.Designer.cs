namespace Example
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
            this.resizeBehavior1 = new NonoUI.Other.ResizeBehavior();
            this.Titlebar = new NonoUI.Controls.DragPanel();
            this.controlButton3 = new NonoUI.Controls.ControlButton();
            this.controlButton2 = new NonoUI.Controls.ControlButton();
            this.controlButton1 = new NonoUI.Controls.ControlButton();
            this.nonoButton1 = new NonoUI.Controls.NonoButton();
            this.nonoButton2 = new NonoUI.Controls.NonoButton();
            this.Titlebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // resizeBehavior1
            // 
            this.resizeBehavior1.TargetForm = this;
            // 
            // Titlebar
            // 
            this.Titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Titlebar.Controls.Add(this.controlButton3);
            this.Titlebar.Controls.Add(this.controlButton2);
            this.Titlebar.Controls.Add(this.controlButton1);
            this.Titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Titlebar.Location = new System.Drawing.Point(0, 0);
            this.Titlebar.Name = "Titlebar";
            this.Titlebar.Size = new System.Drawing.Size(800, 75);
            this.Titlebar.TabIndex = 0;
            this.Titlebar.TargetForm = this;
            // 
            // controlButton3
            // 
            this.controlButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton3.ControlType = NonoUI.Controls.ControlButton.ButtonType.Minimize;
            this.controlButton3.FlatAppearance.BorderSize = 0;
            this.controlButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton3.ForeColor = System.Drawing.Color.White;
            this.controlButton3.Location = new System.Drawing.Point(563, 0);
            this.controlButton3.Name = "controlButton3";
            this.controlButton3.Size = new System.Drawing.Size(75, 75);
            this.controlButton3.TabIndex = 3;
            this.controlButton3.UseVisualStyleBackColor = false;
            // 
            // controlButton2
            // 
            this.controlButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton2.ControlType = NonoUI.Controls.ControlButton.ButtonType.Maximize;
            this.controlButton2.FlatAppearance.BorderSize = 0;
            this.controlButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton2.ForeColor = System.Drawing.Color.White;
            this.controlButton2.Location = new System.Drawing.Point(644, 0);
            this.controlButton2.Name = "controlButton2";
            this.controlButton2.Size = new System.Drawing.Size(75, 75);
            this.controlButton2.TabIndex = 2;
            this.controlButton2.UseVisualStyleBackColor = false;
            // 
            // controlButton1
            // 
            this.controlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton1.ControlType = NonoUI.Controls.ControlButton.ButtonType.Close;
            this.controlButton1.FlatAppearance.BorderSize = 0;
            this.controlButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton1.ForeColor = System.Drawing.Color.White;
            this.controlButton1.Location = new System.Drawing.Point(725, 0);
            this.controlButton1.Name = "controlButton1";
            this.controlButton1.Size = new System.Drawing.Size(75, 75);
            this.controlButton1.TabIndex = 1;
            this.controlButton1.UseVisualStyleBackColor = false;
            // 
            // nonoButton1
            // 
            this.nonoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nonoButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.nonoButton1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.nonoButton1.ButtonToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.nonoButton1.FlatAppearance.BorderSize = 0;
            this.nonoButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nonoButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nonoButton1.ForeColor = System.Drawing.Color.White;
            this.nonoButton1.IsToggleable = false;
            this.nonoButton1.IsToggled = false;
            this.nonoButton1.Location = new System.Drawing.Point(593, 378);
            this.nonoButton1.Name = "nonoButton1";
            this.nonoButton1.Size = new System.Drawing.Size(195, 60);
            this.nonoButton1.TabIndex = 1;
            this.nonoButton1.Text = "Next";
            this.nonoButton1.TextColor = System.Drawing.Color.White;
            this.nonoButton1.TextToggleColor = System.Drawing.Color.White;
            this.nonoButton1.TextWhenToggled = "nonoButton1";
            this.nonoButton1.UseVisualStyleBackColor = false;
            // 
            // nonoButton2
            // 
            this.nonoButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nonoButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.nonoButton2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.nonoButton2.ButtonToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.nonoButton2.FlatAppearance.BorderSize = 0;
            this.nonoButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nonoButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nonoButton2.ForeColor = System.Drawing.Color.White;
            this.nonoButton2.IsToggleable = false;
            this.nonoButton2.IsToggled = false;
            this.nonoButton2.Location = new System.Drawing.Point(377, 378);
            this.nonoButton2.Name = "nonoButton2";
            this.nonoButton2.Size = new System.Drawing.Size(195, 60);
            this.nonoButton2.TabIndex = 2;
            this.nonoButton2.Text = "Back";
            this.nonoButton2.TextColor = System.Drawing.Color.White;
            this.nonoButton2.TextToggleColor = System.Drawing.Color.White;
            this.nonoButton2.TextWhenToggled = "nonoButton1";
            this.nonoButton2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nonoButton2);
            this.Controls.Add(this.nonoButton1);
            this.Controls.Add(this.Titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Titlebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NonoUI.Other.ResizeBehavior resizeBehavior1;
        private NonoUI.Controls.DragPanel Titlebar;
        private NonoUI.Controls.ControlButton controlButton3;
        private NonoUI.Controls.ControlButton controlButton2;
        private NonoUI.Controls.ControlButton controlButton1;
        private NonoUI.Controls.NonoButton nonoButton2;
        private NonoUI.Controls.NonoButton nonoButton1;
    }
}