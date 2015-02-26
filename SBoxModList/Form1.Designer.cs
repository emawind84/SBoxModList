namespace SBoxModList
{
    partial class Form1
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutRAW = new System.Windows.Forms.RichTextBox();
            this.txtOut = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSName = new System.Windows.Forms.Button();
            this.btnSID = new System.Windows.Forms.Button();
            this.lblLoad = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.forumUrlButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 23);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mod List RAW";
            // 
            // txtOutRAW
            // 
            this.txtOutRAW.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOutRAW.Location = new System.Drawing.Point(12, 76);
            this.txtOutRAW.Name = "txtOutRAW";
            this.txtOutRAW.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtOutRAW.Size = new System.Drawing.Size(262, 179);
            this.txtOutRAW.TabIndex = 3;
            this.txtOutRAW.Text = "";
            this.txtOutRAW.WordWrap = false;
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOut.Location = new System.Drawing.Point(12, 327);
            this.txtOut.Name = "txtOut";
            this.txtOut.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtOut.Size = new System.Drawing.Size(466, 248);
            this.txtOut.TabIndex = 4;
            this.txtOut.Text = "";
            this.txtOut.WordWrap = false;
            this.txtOut.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtOut_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mod Details";
            // 
            // btnSName
            // 
            this.btnSName.Location = new System.Drawing.Point(216, 3);
            this.btnSName.Name = "btnSName";
            this.btnSName.Size = new System.Drawing.Size(102, 23);
            this.btnSName.TabIndex = 6;
            this.btnSName.Text = "Sort By Name";
            this.btnSName.UseVisualStyleBackColor = true;
            this.btnSName.Click += new System.EventHandler(this.btnSName_Click);
            // 
            // btnSID
            // 
            this.btnSID.Location = new System.Drawing.Point(135, 3);
            this.btnSID.Name = "btnSID";
            this.btnSID.Size = new System.Drawing.Size(75, 23);
            this.btnSID.TabIndex = 7;
            this.btnSID.Text = "Sort By ID";
            this.btnSID.UseVisualStyleBackColor = true;
            this.btnSID.Click += new System.EventHandler(this.btnSID_Click);
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(110, 28);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(0, 13);
            this.lblLoad.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnSName);
            this.flowLayoutPanel1.Controls.Add(this.btnSID);
            this.flowLayoutPanel1.Controls.Add(this.forumUrlButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(157, 293);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(321, 28);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // forumUrlButton
            // 
            this.forumUrlButton.Location = new System.Drawing.Point(54, 3);
            this.forumUrlButton.Name = "forumUrlButton";
            this.forumUrlButton.Size = new System.Drawing.Size(75, 23);
            this.forumUrlButton.TabIndex = 8;
            this.forumUrlButton.Text = "Forum URL";
            this.forumUrlButton.UseVisualStyleBackColor = true;
            this.forumUrlButton.Click += new System.EventHandler(this.ForumUrlButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 587);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.txtOutRAW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Name = "Form1";
            this.Text = "SBCModView";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtOutRAW;
        private System.Windows.Forms.RichTextBox txtOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSName;
        private System.Windows.Forms.Button btnSID;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button forumUrlButton;
    }
}

