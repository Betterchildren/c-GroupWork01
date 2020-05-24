using ClassLibrary1;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GropuWork01
{
    public partial class frmShowData : Form
    {
        DataTable dt;
        #region 初始化窗体组件
        public frmShowData()
        {
            InitializeComponent();
        }
        #endregion

        #region 分别以listview和datagrid两种方式显示数据
        private void frmShowData_Load(object sender, EventArgs e)
        {
            Text = "显示数据";
            this.tabControl1.TabIndex = 0;
            dt = ClassTable.getDataTable("d:/data.txt");
            
            #region 采用listView显示数据
            this.listView1.View = View.Details;//条目列表形式为详细列表
            listView1.Columns.Add("时间", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("温度", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("湿度", 100, HorizontalAlignment.Left);
            ListViewItem item;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new ListViewItem(new string[]
				{
					dt.Rows[i][0].ToString(),
					dt.Rows[i][1].ToString(),
					dt.Rows[i][2].ToString()
				});
                listView1.Items.Add(item);
            }
            #endregion

            #region 采用datagridview显示数据
            this.dataGridView1.DataSource = dt;
            #endregion

        }
        #endregion
       
        #region 图方式显示数据
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;//创建Graphics
            Pen pen_red = new Pen(Color.Red);//创建画笔
            Pen pen_blue = new Pen(Color.FromArgb(255, 0, 0, 255));
            PointF[] pp1 = new PointF[dt.Rows.Count];//由数据行数获得点数
            PointF[] pp2 = new PointF[dt.Rows.Count];
            TimeSpan ts;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {   //分别获得温湿度的起始点
                    pp1[i] = new PointF(0, 10 * float.Parse(dt.Rows[i][1].ToString()));
                    pp2[i] = new PointF(0, float.Parse(dt.Rows[i][1].ToString()));
                }
                else
                {
                    ts = DateTime.Parse(dt.Rows[i][0].ToString()) - DateTime.Parse(dt.Rows[i - 1][0].ToString());//获得相邻两个数据的时间间隔
                    pp1[i] = new PointF(pp1[i - 1].X + (float)ts.TotalSeconds, 10 * float.Parse(dt.Rows[i][1].ToString()));//得到湿度点集合
                    pp2[i] = new PointF(pp1[i - 1].X + (float)ts.TotalSeconds, float.Parse(dt.Rows[i][2].ToString()));//得到湿度点集合
                }
            }
            g.DrawLines(pen_red, pp1);//根据湿度点集合画出湿度折线图
            g.DrawLines(pen_blue, pp2);//根据温度点集合画出湿度折线图
        }
        
        #endregion

        #region close
                private void button1_Click(object sender, EventArgs e)
                {
                    this.Dispose();
                }
                #endregion
    }
}
