using System;
using System.IO;
using System.Windows.Forms;

namespace GropuWork01
{
    public partial class frmManual : Form
    {
        public frmManual()
        {
            InitializeComponent();
        }

        private void frmManual_Load(object sender, EventArgs e)
        {
            try
            {
                //读取文本文件，第8章知识
                string file = Application.StartupPath + "\\Manual.txt";
                FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Dispose();
                this.textBox1.Text = System.Text.Encoding.GetEncoding("GB2312").GetString(bytes);
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.button1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

