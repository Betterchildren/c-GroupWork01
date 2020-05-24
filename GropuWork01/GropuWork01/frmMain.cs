using System;
using System.Windows.Forms;

namespace GropuWork01
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "单一串口设备数据采集与管理演示示例";
            // 状态栏的text
            toolStripStatusLabel1.Text = Program.name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void helpHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildForm();
            frmManual fm = new frmManual();
            fm.TopLevel = false;//设置该窗体不为顶级窗体。
            this.IsMdiContainer = true;
            fm.MdiParent = this;
            fm.WindowState = FormWindowState.Maximized;
            fm.Show(); //正常
        }

        private void 采集数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit();
        }
        public void exit()
        {
            if (MessageBox.Show("确认结束吗？[Yes|No]", "提示",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning,
               MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void 显示数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void 采集数据ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void 显示数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showData();
        }

        public void getData()
        {
            CloseChildForm();
            frmGetData fgd = new frmGetData();
            fgd.TopLevel = false;//设置该窗体不为顶级窗体。
            this.IsMdiContainer = true;
            fgd.MdiParent = this;
            fgd.Show(); //正常
        }

        public void showData()
        {
            CloseChildForm();
            frmShowData fsd = new frmShowData();
            fsd.TopLevel = false;//设置该窗体不为顶级窗体。
            this.IsMdiContainer = true;
            fsd.MdiParent = this;
            fsd.Show(); //正常
        }

        private void CloseChildForm()
        {
            foreach(Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }
    }
}
