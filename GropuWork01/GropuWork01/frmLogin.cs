using ClassLibrary1;
using System;
using System.Data;
using System.Windows.Forms;

namespace GropuWork01
{
    public partial class frmLogin : Form
    {
        DataTable dt = null;
        public frmLogin()
        {
            InitializeComponent();
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                dt = ClassTable.getManagerTable();
                this.txtPsw.MaxLength = 6;
                txtPsw.PasswordChar = '*';

                this.comboBox1.DataSource = dt;
                this.comboBox1.DisplayMember = "name";
                this.comboBox1.ValueMember = "No";
                if (this.comboBox1.Items.Count > 0)
                    this.comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Items.Count <= 0)
                {
                    MessageBox.Show("用户名不能为空！", "提示", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    return;
                }
                string account = this.comboBox1.SelectedValue.ToString();
                string pwd = this.txtPsw.Text;
                string filter = "No='" + account + "'and pwd='" + pwd + "'";
                if (string.IsNullOrEmpty(pwd))
                {
                    filter = "No='" + account + "'and (pwd is null or pwd='')";
                }
                DataRow[] rows = dt.Select(filter);
                if (rows.Length <= 0)
                {
                    DialogResult dr = MessageBox.Show("密码错误！", "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Retry)
                    {
                        txtPsw.SelectAll();
                        txtPsw.Focus();
                        return;
                    }
                    else
                    {
                        Application.Exit();
                        return;
                    }
                }
                Program.name = this.comboBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
