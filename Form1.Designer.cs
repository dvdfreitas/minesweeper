
namespace MineSweeper
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
            this.debug_bombas = new System.Windows.Forms.TextBox();
            this.debugVolta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // debug_bombas
            // 
            this.debug_bombas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debug_bombas.Location = new System.Drawing.Point(588, 124);
            this.debug_bombas.Multiline = true;
            this.debug_bombas.Name = "debug_bombas";
            this.debug_bombas.Size = new System.Drawing.Size(209, 189);
            this.debug_bombas.TabIndex = 0;
            // 
            // debugVolta
            // 
            this.debugVolta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debugVolta.Location = new System.Drawing.Point(591, 337);
            this.debugVolta.Multiline = true;
            this.debugVolta.Name = "debugVolta";
            this.debugVolta.Size = new System.Drawing.Size(205, 202);
            this.debugVolta.TabIndex = 1;
            this.debugVolta.TextChanged += new System.EventHandler(this.debugVolta_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 648);
            this.Controls.Add(this.debugVolta);
            this.Controls.Add(this.debug_bombas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox debug_bombas;
        private System.Windows.Forms.TextBox debugVolta;
    }
}

