namespace commonv2_Tool
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDecompile = new System.Windows.Forms.Button();
            this.btnRecompile = new System.Windows.Forms.Button();
            this.tbDecompileCommonv2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRecompileCommonv2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDecompileDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnDecompile
            // 
            this.btnDecompile.Location = new System.Drawing.Point(1059, 4);
            this.btnDecompile.Name = "btnDecompile";
            this.btnDecompile.Size = new System.Drawing.Size(101, 23);
            this.btnDecompile.TabIndex = 0;
            this.btnDecompile.Text = "Decompile";
            this.btnDecompile.UseVisualStyleBackColor = true;
            this.btnDecompile.Click += new System.EventHandler(this.btnDecompile_Click);
            // 
            // btnRecompile
            // 
            this.btnRecompile.Location = new System.Drawing.Point(1059, 56);
            this.btnRecompile.Name = "btnRecompile";
            this.btnRecompile.Size = new System.Drawing.Size(101, 23);
            this.btnRecompile.TabIndex = 1;
            this.btnRecompile.Text = "Recompile";
            this.btnRecompile.UseVisualStyleBackColor = true;
            this.btnRecompile.Click += new System.EventHandler(this.btnRecompile_Click);
            // 
            // tbDecompileCommonv2
            // 
            this.tbDecompileCommonv2.Location = new System.Drawing.Point(153, 6);
            this.tbDecompileCommonv2.Name = "tbDecompileCommonv2";
            this.tbDecompileCommonv2.Size = new System.Drawing.Size(900, 20);
            this.tbDecompileCommonv2.TabIndex = 2;
            this.tbDecompileCommonv2.Click += new System.EventHandler(this.tbDecompileCommonv2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Decompile commonv2.agz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recompile commonv2.agz:";
            // 
            // tbRecompileCommonv2
            // 
            this.tbRecompileCommonv2.Location = new System.Drawing.Point(153, 58);
            this.tbRecompileCommonv2.Name = "tbRecompileCommonv2";
            this.tbRecompileCommonv2.Size = new System.Drawing.Size(900, 20);
            this.tbRecompileCommonv2.TabIndex = 4;
            this.tbRecompileCommonv2.Click += new System.EventHandler(this.tbRecompileCommonv2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Decompile Directory:";
            // 
            // tbDecompileDirectory
            // 
            this.tbDecompileDirectory.Location = new System.Drawing.Point(153, 32);
            this.tbDecompileDirectory.Name = "tbDecompileDirectory";
            this.tbDecompileDirectory.Size = new System.Drawing.Size(1007, 20);
            this.tbDecompileDirectory.TabIndex = 6;
            this.tbDecompileDirectory.Click += new System.EventHandler(this.tbDecompileDirectory_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 94);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDecompileDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRecompileCommonv2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDecompileCommonv2);
            this.Controls.Add(this.btnRecompile);
            this.Controls.Add(this.btnDecompile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDecompile;
        private System.Windows.Forms.Button btnRecompile;
        private System.Windows.Forms.TextBox tbDecompileCommonv2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRecompileCommonv2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDecompileDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

