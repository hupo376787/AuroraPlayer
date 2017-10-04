using System;
using System.IO;
using System.Drawing;
using DSkin.Controls;
using DSkin.Forms;
using System.Windows.Forms;

namespace Aurora_Player
{
    public partial class FileInfoFrm : DSkinForm
    {
        public FileInfoFrm()
        {
            InitializeComponent();
        }

        MainForm mainfrm;
        
        private void FileInfoFrm_Load(object sender, EventArgs e)
        {
            InitGridList();
            SetColumnWidth();
            mainfrm = (MainForm)this.Owner;
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            //if (mainfrm.b_ImageFuzzy)
            //{
            //    Bitmap bt = mainfrm.BackImageCurrent;
            //    Rectangle rect = new Rectangle(0, 0, bt.Width, bt.Height);
            //    DSkin.ImageEffects.GaussianBlur(bt, ref rect, 20, false);
            //    this.BackgroundImage = bt;
            //}
            //else
            //{
            //    this.BackgroundImage = mainfrm.BackImageCurrent;
            //}
            //this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            if(mainfrm.axPlayer1.GetState() == (int)PublicClass.PLAY_STATE.PS_PLAY)
            {
                if (!mainfrm.b_PlayTV)
                {
                    string str_Url = mainfrm.axPlayer1.GetConfig(4);
                    try
                    {
                        int n_MaxGongYueShu = MaxGongYueShu(mainfrm.axPlayer1.GetVideoWidth(), mainfrm.axPlayer1.GetVideoHeight());

                        dSkinGridList_FileInfo.Rows.AddRow("文件名", Path.GetFileName(str_Url));
                        dSkinGridList_FileInfo.Rows.AddRow("文件类型", Path.GetExtension(str_Url).Replace(".", ""));
                        dSkinGridList_FileInfo.Rows.AddRow("文件路径", Path.GetDirectoryName(str_Url));
                        dSkinGridList_FileInfo.Rows.AddRow("文件大小", (Convert.ToInt64(mainfrm.axPlayer1.GetConfig(5)) / 1024 / 1024).ToString() + "MB (" + mainfrm.axPlayer1.GetConfig(5) + " bytes)");
                        dSkinGridList_FileInfo.Rows.AddRow("文件尺寸", mainfrm.axPlayer1.GetVideoWidth().ToString() + " x " + mainfrm.axPlayer1.GetVideoHeight().ToString()
                            + " (画面比例 " + (mainfrm.axPlayer1.GetVideoWidth() / n_MaxGongYueShu).ToString() + ":"
                            + (mainfrm.axPlayer1.GetVideoHeight() / n_MaxGongYueShu).ToString() + ")");
                        dSkinGridList_FileInfo.Rows.AddRow("文件长度", FileHelper.GetAccurateTime(mainfrm.axPlayer1.GetDuration()));
                        dSkinGridList_FileInfo.Rows.AddRow("文件创建时间", FileHelper.GetFileCreateTime(str_Url));
                        dSkinGridList_FileInfo.Rows.AddRow("上次访问时间", FileHelper.GetFileLastAccessTime(str_Url));

                        for (int i = 0; i < dSkinGridList_FileInfo.RowCount; i++)
                        {
                            DSkinGridListRow dr = dSkinGridList_FileInfo.Rows[i];
                            for (int j = 0; j < dr.Cells.Count; j++)
                            {
                                DSkinGridListCell dc = dr.Cells[j];
                                Font font = new Font("宋体", 9, FontStyle.Regular);
                                dc.Font = font;
                            }
                        }

                        dSkinGridList_FileInfo.LayoutContent();
                    }
                    catch { }
                }
                else
                {
                    int n_MaxGongYueShu = MaxGongYueShu(mainfrm.axPlayer1.GetVideoWidth(), mainfrm.axPlayer1.GetVideoHeight());
                    dSkinGridList_FileInfo.Rows.AddRow("文件名", mainfrm.TitleBarPanel.Text);
                    dSkinGridList_FileInfo.Rows.AddRow("文件尺寸", mainfrm.axPlayer1.GetVideoWidth().ToString() + " x " + mainfrm.axPlayer1.GetVideoHeight().ToString()
                            + " (画面比例 " + (mainfrm.axPlayer1.GetVideoWidth() / n_MaxGongYueShu).ToString() + ":"
                            + (mainfrm.axPlayer1.GetVideoHeight() / n_MaxGongYueShu).ToString() + ")");
                    dSkinGridList_FileInfo.LayoutContent();
                }
            }
        }

        private int MaxGongYueShu(int n1, int n2)
        {
            int temp = Math.Max(n1, n2);
            n2 = Math.Min(n1, n2);
            n1 = temp;
            while(n2 != 0)
            {
                n1 = n1 > n2 ? n1 : n2;
                int m = n1 % n2;
                n1 = n2;
                n2 = m;
            }
            return n1;
        }

        private void InitGridList()
        {
            DSkinGridListColumn dSkinGridListColumn1 = new DSkinGridListColumn();
            DSkinGridListColumn dSkinGridListColumn2 = new DSkinGridListColumn();

            // 
            // 
            // 
            dSkinGridListColumn1.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn1.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn1.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn1.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn1.Item.Name = string.Empty;
            dSkinGridListColumn1.Item.Size = new System.Drawing.Size(40, 22);
            dSkinGridListColumn1.Item.Text = "项";
            dSkinGridListColumn1.Item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            dSkinGridListColumn1.Name = "项";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = 88;
            dSkinGridListColumn1.DataPropertyName = "Column_Item";
            // 
            // 
            // 
            dSkinGridListColumn2.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn2.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn2.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn2.Item.Location = new System.Drawing.Point(40, 0);
            dSkinGridListColumn2.Item.Name = string.Empty;
            dSkinGridListColumn2.Item.Size = new System.Drawing.Size(70, 22);
            dSkinGridListColumn2.Item.Text = "值";
            dSkinGridListColumn2.Item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            dSkinGridListColumn2.Name = "值";
            dSkinGridListColumn2.Visble = true;
            dSkinGridListColumn2.Width = dSkinGridList_FileInfo.Width - 88 - 5;
            dSkinGridListColumn2.DataPropertyName = "Column_Value";

            //dSkinGridList_FileInfo.RowHeight = 22;
            dSkinGridList_FileInfo.ColumnFill = true;  //窗体最大化后，列宽自适应
            dSkinGridList_FileInfo.EnablePage = false;
            dSkinGridList_FileInfo.Dock = System.Windows.Forms.DockStyle.Fill;

            //设置透明
            dSkinGridList_FileInfo.BackColor = Color.Transparent;
            dSkinGridList_FileInfo.DoubleItemsBackColor = Color.Transparent;
            dSkinGridList_FileInfo.SingleItemsBackColor = Color.Transparent;
            DSkinLinearGradientBrush dSkinLinearGradientBrush1 = new DSkinLinearGradientBrush();
            dSkinGridList_FileInfo.ColumnHeaderBrush = dSkinLinearGradientBrush1;
            dSkinGridList_FileInfo.ColumnHeaderHoverBrush = dSkinLinearGradientBrush1;
            dSkinGridList_FileInfo.ColumnHeaderPressBrush = dSkinLinearGradientBrush1;

            dSkinGridList_FileInfo.Columns.AddRange(new DSkinGridListColumn[] {
            dSkinGridListColumn1,
            dSkinGridListColumn2});
        }

        private void SetColumnWidth()
        {
            dSkinGridList_FileInfo.Columns[0].Width = 88;
            dSkinGridList_FileInfo.Columns[1].Width = dSkinGridList_FileInfo.Width - 88;
        }

        private void FileInfoFrm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            dSkinGridList_FileInfo.Rows.Clear();
        }

        private void FileInfoFrm_Resize(object sender, EventArgs e)
        {
            SetColumnWidth();
        }

        private void dSkinGridList_FileInfo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DllHelper.ReleaseCapture();
            DllHelper.SendMessage(this.Handle, DllHelper.WM_SYSCOMMAND, DllHelper.SC_MOVE + DllHelper.HTCAPTION, 0);
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

    }
}
