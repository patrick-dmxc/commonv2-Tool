using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace commonv2_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDecompile_Click(object sender, EventArgs e)
        {
            Decompiler decompiler = new Decompiler(tbDecompileCommonv2.Text,tbDecompileDirectory.Text);
            decompiler.RunDecompiler();
        }

        private void btnRecompile_Click(object sender, EventArgs e)
        {
            Recompiler recompiler = new Recompiler(tbRecompileCommonv2.Text, tbDecompileDirectory.Text);
            recompiler.RunRecompiler();
        }

        private void tbDecompileCommonv2_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "agz";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                tbDecompileCommonv2.Text = openFileDialog1.FileName;
        }

        private void tbDecompileDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tbDecompileDirectory.Text = folderBrowserDialog1.SelectedPath;
        }

        private void tbRecompileCommonv2_Click(object sender, EventArgs e)
        {
            openFileDialog2.DefaultExt = "agz";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
                tbRecompileCommonv2.Text = openFileDialog2.FileName;
        }
    }
}
