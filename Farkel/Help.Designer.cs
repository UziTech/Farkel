namespace Farkel
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.label1 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 965);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HMouseMove);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HMouseDown);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HMouseUp);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.LargeChange = 250;
            this.vScrollBar1.Location = new System.Drawing.Point(522, 0);
            this.vScrollBar1.Maximum = 945;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 266);
            this.vScrollBar1.SmallChange = 13;
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 264);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Help";
            this.Text = "How To Play";
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.HMouseWheel);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}