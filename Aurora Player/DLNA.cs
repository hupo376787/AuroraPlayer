using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.Controls;

namespace Aurora_Player
{
    public partial class DLNA : DSkinForm
    {
        public DLNA()
        {
            InitializeComponent();
        }

        MainForm mainfrm;

        private void DLNA_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;
            dSkinLabel_Tip.Visible = false;
            InitDSkinListView();
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;

            if (mainfrm.axPlayer1.GetConfig(1801) == "0")
            {
                mainfrm.axPlayer1.SetConfig(1801, "1");
            }
            GetDLNAList();

        }

        private void InitDSkinListView()
        {
            DSkinGridListColumn dSkinGridListColumn0 = new DSkinGridListColumn();
            DSkinGridListColumn dSkinGridListColumn1 = new DSkinGridListColumn();
            DSkinGridListColumn dSkinGridListColumn11 = new DSkinGridListColumn();

            //dSkinGridListColumn0.ItemType = ControlType.DuiPictureBox;
            dSkinGridListColumn0.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn0.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn0.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn0.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn0.Item.Name = "";
            dSkinGridListColumn0.Item.Size = new System.Drawing.Size(25, 25);
            dSkinGridListColumn0.Item.Text = "DeviceIcon";
            dSkinGridListColumn0.Item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dSkinGridListColumn0.DockStyle = DockStyle.Fill;
            dSkinGridListColumn0.Name = "DeviceIcon";
            dSkinGridListColumn0.Visble = true;
            dSkinGridListColumn0.Width = 25;
            dSkinGridListColumn0.DataPropertyName = "Column_Icon";

            dSkinGridListColumn1.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn1.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn1.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn1.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn1.Item.Name = "";
            dSkinGridListColumn1.Item.Size = new System.Drawing.Size(40, 22);
            dSkinGridListColumn1.Item.Text = "Device名称";
            dSkinGridListColumn1.Item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dSkinGridListColumn1.DockStyle = DockStyle.Left;
            dSkinGridListColumn1.Name = "Device名称";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 180;
            dSkinGridListColumn1.DataPropertyName = "Column_Name";

            dSkinGridListColumn11.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn11.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn11.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn11.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn11.Item.Name = "";
            dSkinGridListColumn11.Item.Size = new System.Drawing.Size(40, 22);
            dSkinGridListColumn11.Item.Text = "DeviceID";
            dSkinGridListColumn11.Item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dSkinGridListColumn11.DockStyle = DockStyle.Left;
            dSkinGridListColumn11.Name = "DeviceID";
            dSkinGridListColumn11.Visble = true;
            dSkinGridListColumn11.Width = 180;
            dSkinGridListColumn11.DataPropertyName = "Column_Name";

            dSkinGridList_DLNA.RowHeight = 25;
            dSkinGridList_DLNA.ColumnHeadersVisible = false;

            //设置透明
            dSkinGridList_DLNA.BackColor = Color.Transparent;
            dSkinGridList_DLNA.DoubleItemsBackColor = Color.Transparent;
            dSkinGridList_DLNA.SingleItemsBackColor = Color.Transparent;
            DSkinLinearGradientBrush dSkinLinearGradientBrush1 = new DSkinLinearGradientBrush();
            dSkinGridList_DLNA.ColumnHeaderBrush = dSkinLinearGradientBrush1;

            dSkinGridList_DLNA.Columns.AddRange(new DSkinGridListColumn[] {
            dSkinGridListColumn0,
            dSkinGridListColumn1,
            dSkinGridListColumn11});
        }

        #region 改变窗体背景
        protected override void OnLayeredPaintBackground(PaintEventArgs e)
        {
            base.OnLayeredPaintBackground(e);

            //SetForeColor(this, mainFrm.BackImageCurrent);

            if (mainfrm.BackImageCurrent != null)
            {
                if (mainfrm.n_BackImageTransparency <= 1)
                {
                    return;
                }
                if (mainfrm.n_BackImageTransparency == 100)
                {
                    e.Graphics.DrawImage(mainfrm.BackImageCurrent, 0, 0, this.Width, this.Height);
                    return;
                }
                e.Graphics.DrawImage(mainfrm.BackImageCurrent, new Rectangle(0, 0, this.Width, this.Height),
                    0, 0, mainfrm.BackImageCurrent.Width, mainfrm.BackImageCurrent.Height, GraphicsUnit.Pixel,
                    DSkin.ImageEffects.ChangeOpacity((float)(1.0 * mainfrm.n_BackImageTransparency / 100)));
            }
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }

        #endregion

        private void dSkinButton_Connect_Click(object sender, EventArgs e)
        {
            ConnectDLNA();
        }

        private void dSkinGridList_DLNA_ItemDoubleClick(object sender, DSkinGridListMouseEventArgs e)
        {
            ConnectDLNA();
        }

        private void dSkinButton_Refresh_Click(object sender, EventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(1804, null);//强制刷新
            dSkinGridList_DLNA.Rows.Clear();
            GetDLNAList();
        }

        //当前局域网中可用的 DLNA 设备列表，格式："name1;id1;wmv,mp4\r\nname2;id2;flv,wmv,mkv\r\n..."，每行表示一个设备的信息，其中id为设备标识。
        private void GetDLNAList()
        {
            if (mainfrm.axPlayer1.GetConfig(1801) == "1")
            {
                string str_List_All = mainfrm.axPlayer1.GetConfig(1802);
                //str_List_All = "name1;id1;wmv,mp4" + "\r\n" + "name2;id2;flv,wmv,mkv";
                if (str_List_All.Trim() == "")
                {
                    dSkinLabel_Tip.Visible = true;
                    return;
                }
                else
                {
                    string str_line = string.Empty;
                    byte[] array = Encoding.ASCII.GetBytes(str_List_All);
                    MemoryStream stream = new MemoryStream(array);
                    StreamReader sr = new StreamReader(stream, Encoding.Default);
                    while ((str_line = sr.ReadLine()) != null)
                    {
                        string[] str_Temp = str_line.Split(';');
                        dSkinGridList_DLNA.Rows.AddRow("", str_Temp[0], str_Temp[1]);
                    }
                    sr.Close();
                }
            }
            dSkinGridList_DLNA.LayoutContent();
        }

        private void ConnectDLNA()
        {
            if (dSkinGridList_DLNA.SelectedItem == null)
                return;
            else
            {
                string str_dlna_id = dSkinGridList_DLNA.SelectedItem.Cells[2].Text;
                mainfrm.axPlayer1.SetConfig(1803, str_dlna_id);
            }
        }

        private void dSkinButton_CancelDLNA_Click(object sender, EventArgs e)
        {
            mainfrm.axPlayer1.SetConfig(1803, "");
        }
    }
}
