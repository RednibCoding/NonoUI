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
            this.nonoButton3 = new NonoUI.Controls.NonoButton();
            this.nonoButton1 = new NonoUI.Controls.NonoButton();
            this.nonoButton2 = new NonoUI.Controls.NonoButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nonoListBox1 = new NonoUI.Controls.NonoListBox();
            this.nonoImageButton1 = new NonoUI.Controls.NonoImageButton();
            this.Titlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonoImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // resizeBehavior1
            // 
            this.resizeBehavior1.MaxHeight = 0;
            this.resizeBehavior1.MaxWidth = 0;
            this.resizeBehavior1.MinHeight = 200;
            this.resizeBehavior1.MinWidth = 200;
            this.resizeBehavior1.TargetForm = this;
            // 
            // Titlebar
            // 
            this.Titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Titlebar.Controls.Add(this.controlButton3);
            this.Titlebar.Controls.Add(this.controlButton2);
            this.Titlebar.Controls.Add(this.controlButton1);
            this.Titlebar.Controls.Add(this.nonoButton3);
            this.Titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Titlebar.Location = new System.Drawing.Point(0, 0);
            this.Titlebar.Name = "Titlebar";
            this.Titlebar.Size = new System.Drawing.Size(1137, 75);
            this.Titlebar.TabIndex = 0;
            this.Titlebar.TargetForm = this;
            // 
            // controlButton3
            // 
            this.controlButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton3.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton3.ButtonForeColor = System.Drawing.Color.White;
            this.controlButton3.ControlType = NonoUI.Controls.ControlButton.ButtonType.Minimize;
            this.controlButton3.FlatAppearance.BorderSize = 0;
            this.controlButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton3.ForeColor = System.Drawing.Color.White;
            this.controlButton3.Location = new System.Drawing.Point(900, 0);
            this.controlButton3.Name = "controlButton3";
            this.controlButton3.Size = new System.Drawing.Size(75, 75);
            this.controlButton3.TabIndex = 5;
            this.controlButton3.UseVisualStyleBackColor = false;
            // 
            // controlButton2
            // 
            this.controlButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton2.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton2.ButtonForeColor = System.Drawing.Color.White;
            this.controlButton2.ControlType = NonoUI.Controls.ControlButton.ButtonType.Maximize;
            this.controlButton2.FlatAppearance.BorderSize = 0;
            this.controlButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton2.ForeColor = System.Drawing.Color.White;
            this.controlButton2.Location = new System.Drawing.Point(981, 0);
            this.controlButton2.Name = "controlButton2";
            this.controlButton2.Size = new System.Drawing.Size(75, 75);
            this.controlButton2.TabIndex = 5;
            this.controlButton2.UseVisualStyleBackColor = false;
            // 
            // controlButton1
            // 
            this.controlButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton1.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.controlButton1.ButtonForeColor = System.Drawing.Color.White;
            this.controlButton1.ControlType = NonoUI.Controls.ControlButton.ButtonType.Close;
            this.controlButton1.FlatAppearance.BorderSize = 0;
            this.controlButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlButton1.ForeColor = System.Drawing.Color.White;
            this.controlButton1.Location = new System.Drawing.Point(1062, 0);
            this.controlButton1.Name = "controlButton1";
            this.controlButton1.Size = new System.Drawing.Size(75, 75);
            this.controlButton1.TabIndex = 5;
            this.controlButton1.UseVisualStyleBackColor = false;
            // 
            // nonoButton3
            // 
            this.nonoButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nonoButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.nonoButton3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.nonoButton3.ButtonToggleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.nonoButton3.FlatAppearance.BorderSize = 0;
            this.nonoButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nonoButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nonoButton3.ForeColor = System.Drawing.Color.White;
            this.nonoButton3.Image = global::Example.Properties.Resources.user;
            this.nonoButton3.IsToggleable = false;
            this.nonoButton3.IsToggled = false;
            this.nonoButton3.Location = new System.Drawing.Point(811, 0);
            this.nonoButton3.Name = "nonoButton3";
            this.nonoButton3.Size = new System.Drawing.Size(83, 75);
            this.nonoButton3.TabIndex = 3;
            this.nonoButton3.TextColor = System.Drawing.Color.White;
            this.nonoButton3.TextToggleColor = System.Drawing.Color.White;
            this.nonoButton3.TextWhenToggled = "nonoButton3";
            this.nonoButton3.UseVisualStyleBackColor = false;
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
            this.nonoButton1.Location = new System.Drawing.Point(930, 743);
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
            this.nonoButton2.Location = new System.Drawing.Point(714, 743);
            this.nonoButton2.Name = "nonoButton2";
            this.nonoButton2.Size = new System.Drawing.Size(195, 60);
            this.nonoButton2.TabIndex = 2;
            this.nonoButton2.Text = "Back";
            this.nonoButton2.TextColor = System.Drawing.Color.White;
            this.nonoButton2.TextToggleColor = System.Drawing.Color.White;
            this.nonoButton2.TextWhenToggled = "nonoButton1";
            this.nonoButton2.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Example.Properties.Resources.logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(36, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 241);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // nonoListBox1
            // 
            this.nonoListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nonoListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nonoListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.nonoListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nonoListBox1.FormattingEnabled = true;
            this.nonoListBox1.ItemBackColor = System.Drawing.Color.Transparent;
            this.nonoListBox1.ItemHeight = 40;
            this.nonoListBox1.Items.AddRange(new object[] {
            "Hello",
            "Here",
            "I AM"});
            this.nonoListBox1.ItemTextColor = System.Drawing.Color.Black;
            this.nonoListBox1.Location = new System.Drawing.Point(345, 115);
            this.nonoListBox1.Name = "nonoListBox1";
            this.nonoListBox1.SelectedItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.nonoListBox1.SelectedItemTextColor = System.Drawing.Color.White;
            this.nonoListBox1.Size = new System.Drawing.Size(764, 560);
            this.nonoListBox1.TabIndex = 4;
            // 
            // nonoImageButton1
            // 
            this.nonoImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.nonoImageButton1.BackgroundImage = global::Example.Properties.Resources.play_now;
            this.nonoImageButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nonoImageButton1.Disabled = false;
            this.nonoImageButton1.ImageClicked = global::Example.Properties.Resources.play_now;
            this.nonoImageButton1.ImageDisabled = global::Example.Properties.Resources.play_now_disabled;
            this.nonoImageButton1.ImageHover = global::Example.Properties.Resources.play_now;
            this.nonoImageButton1.ImageNormal = global::Example.Properties.Resources.play_now;
            this.nonoImageButton1.Location = new System.Drawing.Point(502, 348);
            this.nonoImageButton1.Name = "nonoImageButton1";
            this.nonoImageButton1.Size = new System.Drawing.Size(150, 75);
            this.nonoImageButton1.TabIndex = 5;
            this.nonoImageButton1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 815);
            this.Controls.Add(this.nonoImageButton1);
            this.Controls.Add(this.nonoListBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nonoButton2);
            this.Controls.Add(this.nonoButton1);
            this.Controls.Add(this.Titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Titlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonoImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NonoUI.Other.ResizeBehavior resizeBehavior1;
        private NonoUI.Controls.DragPanel Titlebar;
        private NonoUI.Controls.NonoButton nonoButton2;
        private NonoUI.Controls.NonoButton nonoButton1;
        private NonoUI.Controls.NonoButton nonoButton3;
        private PictureBox pictureBox1;
        private NonoUI.Controls.NonoListBox nonoListBox1;
        private NonoUI.Controls.ControlButton controlButton3;
        private NonoUI.Controls.ControlButton controlButton2;
        private NonoUI.Controls.ControlButton controlButton1;
        private NonoUI.Controls.NonoImageButton nonoImageButton1;
    }
}