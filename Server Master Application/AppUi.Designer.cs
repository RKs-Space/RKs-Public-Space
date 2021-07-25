namespace Server_Master
{
    partial class AppUi
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
            this.ddEnv = new System.Windows.Forms.ComboBox();
            this.ddServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblException = new System.Windows.Forms.Label();
            this.btnOpenServer = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // ddEnv
            // 
            this.ddEnv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ddEnv.FormattingEnabled = true;
            this.ddEnv.Items.AddRange(new object[] {
            "Production",
            "Stage"});
            this.ddEnv.Location = new System.Drawing.Point(139, 109);
            this.ddEnv.Name = "ddEnv";
            this.ddEnv.Size = new System.Drawing.Size(135, 21);
            this.ddEnv.TabIndex = 0;
            this.ddEnv.SelectionChangeCommitted += new System.EventHandler(this.ddEnv_SelectionChangeCommitted);
            // 
            // ddServer
            // 
            this.ddServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ddServer.FormattingEnabled = true;
            this.ddServer.Location = new System.Drawing.Point(139, 182);
            this.ddServer.Name = "ddServer";
            this.ddServer.Size = new System.Drawing.Size(121, 21);
            this.ddServer.TabIndex = 1;
            this.ddServer.SelectedIndexChanged += new System.EventHandler(this.ddServer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(137, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Environment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(137, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Server Group";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblServer.Location = new System.Drawing.Point(137, 225);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(51, 20);
            this.lblServer.TabIndex = 4;
            this.lblServer.Text = "label3";
            // 
            // lblException
            // 
            this.lblException.AutoSize = true;
            this.lblException.BackColor = System.Drawing.Color.Transparent;
            this.lblException.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblException.ForeColor = System.Drawing.Color.Red;
            this.lblException.Location = new System.Drawing.Point(225, 225);
            this.lblException.Name = "lblException";
            this.lblException.Size = new System.Drawing.Size(51, 20);
            this.lblException.TabIndex = 6;
            this.lblException.Text = "label3";
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenServer.Depth = 0;
            this.btnOpenServer.Location = new System.Drawing.Point(139, 265);
            this.btnOpenServer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Primary = true;
            this.btnOpenServer.Size = new System.Drawing.Size(114, 38);
            this.btnOpenServer.TabIndex = 8;
            this.btnOpenServer.Text = "Open Servers";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // AppUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 325);
            this.Controls.Add(this.btnOpenServer);
            this.Controls.Add(this.lblException);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddServer);
            this.Controls.Add(this.ddEnv);
            this.Name = "AppUi";
            this.Text = "Server Master";
            this.Load += new System.EventHandler(this.AppUi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddEnv;
        private System.Windows.Forms.ComboBox ddServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblException;
        private MaterialSkin.Controls.MaterialRaisedButton btnOpenServer;
    }
}

