using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DSkin.Forms;
using DSkin.Controls;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace Aurora_Player
{
    public partial class PlayListFrm : DSkinForm
    {
        public PlayListFrm()
        {
            InitializeComponent();
        }

        MainForm mainfrm;

        private void PlayListFrm_Load(object sender, EventArgs e)
        {
            mainfrm = (MainForm)this.Owner;

            mainfrm.LocateResizePlayListPanel();
            this.BackColor = Color.FromArgb(mainfrm.n_BackColorTransparency, this.BackColor);
            this.EnabledDWM = mainfrm.b_EnableDWM;
            dSkinTabControl1.SelectedBackColors[1] = mainfrm.FocusColor;
            this.Opacity = 0.7;
            //dSkinContextMenuStrip_TV.BackgroundImage = mainfrm.BackImageCurrent;
            dSkinContextMenuStrip_TV.Opacity = 0.75;
            dSkinContextMenuStrip_TV.ItemHover = mainfrm.ItemHoverColor;
            dSkinContextMenuStrip_LocalList.Opacity = 0.75;
            dSkinContextMenuStrip_LocalList.ItemHover = mainfrm.ItemHoverColor;

            dSkinTabControl1.ItemSize = new Size(dSkinTabControl1.Width, 28);
            dSkinTabPage1.TabItemImage = Properties.Resources.LG;

            Thread thread = new Thread(LoadPrepare);
            thread.Start();
        }

        //#region 改变窗体背景
        //protected override void OnLayeredPaintBackground(PaintEventArgs e)
        //{
        //    base.OnLayeredPaintBackground(e);

        //    //SetForeColor(this, mainFrm.BackImageCurrent);

        //    if (mainfrm.BackImageCurrent != null)
        //    {
        //        if (mainfrm.n_BackImageTransparency <= 1)
        //        {
        //            return;
        //        }
        //        if (mainfrm.n_BackImageTransparency == 100)
        //        {
        //            e.Graphics.DrawImage(mainfrm.BackImageCurrent, 0, 0, this.Width, this.Height);
        //            return;
        //        }
        //        e.Graphics.DrawImage(mainfrm.BackImageCurrent, new Rectangle(0, 0, this.Width, this.Height),
        //            0, 0, mainfrm.BackImageCurrent.Width, mainfrm.BackImageCurrent.Height, GraphicsUnit.Pixel,
        //            DSkin.ImageEffects.ChangeOpacity((float)(1.0 * mainfrm.n_BackImageTransparency / 100)));
        //    }
        //}

        //protected override void OnBackgroundImageChanged(EventArgs e)
        //{
        //    base.OnBackgroundImageChanged(e);
        //}
        //#endregion

        private void InitDSkinListView()
        {
            DSkinGridListColumn dSkinGridListColumn0 = new DSkinGridListColumn();
            DSkinGridListColumn dSkinGridListColumn1 = new DSkinGridListColumn();
            DSkinGridListColumn dSkinGridListColumn11 = new DSkinGridListColumn();
            DSkinGridListColumn dSkinGridListColumn111 = new DSkinGridListColumn();

            dSkinGridListColumn0.ItemType = ControlType.DuiPictureBox;
            dSkinGridListColumn0.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn0.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn0.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn0.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn0.Item.Name = "";
            dSkinGridListColumn0.Item.Size = new System.Drawing.Size(25, 25);
            dSkinGridListColumn0.Item.Text = "标志";
            dSkinGridListColumn0.Item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dSkinGridListColumn0.DockStyle = DockStyle.Fill;
            dSkinGridListColumn0.Name = "标志";
            dSkinGridListColumn0.Visble = true;
            dSkinGridListColumn0.Width = 25;
            dSkinGridListColumn0.DataPropertyName = "Column_Icon";

            dSkinGridListColumn1.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn1.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn1.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn1.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn1.Item.Name = "";
            dSkinGridListColumn1.Item.Size = new System.Drawing.Size(40, 22);
            dSkinGridListColumn1.Item.Text = "名称";
            dSkinGridListColumn1.Item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dSkinGridListColumn1.DockStyle = DockStyle.Left;
            dSkinGridListColumn1.Name = "名称";
            dSkinGridListColumn1.Visble = true;
            dSkinGridListColumn1.Width = dSkinGridList_PlayList_LocalList.Width - 35;
            dSkinGridListColumn1.DataPropertyName = "Column_Name";

            dSkinGridListColumn11.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn11.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn11.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn11.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn11.Item.Name = "";
            dSkinGridListColumn11.Item.Size = new System.Drawing.Size(40, 22);
            dSkinGridListColumn11.Item.Text = "地址";
            dSkinGridListColumn11.Item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dSkinGridListColumn11.Name = "地址";
            dSkinGridListColumn11.Visble = true;
            dSkinGridListColumn11.Width = 0;
            dSkinGridListColumn11.DataPropertyName = "Column_URL";

            dSkinGridListColumn111.Item.Font = new System.Drawing.Font("宋体", 9F);
            dSkinGridListColumn111.Item.ForeColor = System.Drawing.Color.Black;
            dSkinGridListColumn111.Item.InheritanceSize = new System.Drawing.SizeF(0F, 1F);
            dSkinGridListColumn111.Item.Location = new System.Drawing.Point(0, 0);
            dSkinGridListColumn111.Item.Name = "";
            dSkinGridListColumn111.Item.Size = new System.Drawing.Size(40, 22);
            dSkinGridListColumn111.Item.Text = "进度";
            dSkinGridListColumn111.Item.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            dSkinGridListColumn111.Name = "进度";
            dSkinGridListColumn111.Visble = true;
            dSkinGridListColumn111.Width = 0;
            dSkinGridListColumn111.DataPropertyName = "Column_Position";

            dSkinGridList_PlayList_LocalList.RowHeight = 25;

            //设置透明
            dSkinGridList_PlayList_LocalList.BackColor = Color.Transparent;
            dSkinGridList_PlayList_LocalList.DoubleItemsBackColor = Color.Transparent;
            dSkinGridList_PlayList_LocalList.SingleItemsBackColor = Color.Transparent;
            DSkinLinearGradientBrush dSkinLinearGradientBrush1 = new DSkinLinearGradientBrush();
            dSkinGridList_PlayList_LocalList.ColumnHeaderBrush = dSkinLinearGradientBrush1;

            dSkinGridList_PlayList_LocalList.Columns.AddRange(new DSkinGridListColumn[] {
            dSkinGridListColumn0,
            dSkinGridListColumn1,
            dSkinGridListColumn11,
            dSkinGridListColumn111,});
        }

        private void LoadPrepare()
        {
            MethodInvoker invoke = new MethodInvoker(LoadPrepare1);
            BeginInvoke(invoke);
        }

        private void LoadPrepare1()
        {
            InitDSkinListView();
            dSkinGridList_PlayList_LocalList.ColumnHeadersVisible = false;
            dSkinTabControl1.SelectedIndex = 0;
            ReadLocalList();
            dSkinGridList_PlayList_LocalList.LayoutContent();
        }

        private void ReadLocalList()
        {
            dSkinGridList_PlayList_LocalList.Rows.Clear();
            string sql = "select * from LocalList";
            SQLiteCommand command = new SQLiteCommand(sql, mainfrm.SQLiteConn);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string strFullFileName = reader["FileFullName"].ToString();
                int nPosition = 0;
                if (reader["Position"] == null || reader["Position"].ToString() == "")
                    nPosition = 0;
                else
                    nPosition = (int)reader["Position"];
                //mainfrm.AddtoPlayList(strFullFileName);
                string strFileNameAndExtension = Path.GetFileName(strFullFileName);
                dSkinGridList_PlayList_LocalList.Rows.AddRow(Properties.Resources.LG, strFileNameAndExtension, strFullFileName, nPosition);
            }
        }
        
        private void PlayListFrm_SizeChanged(object sender, EventArgs e)
        {
            if (dSkinTabControl1.Width <= 15)
                return;
            dSkinTabControl1.ItemSize = new Size(dSkinTabControl1.Width / 2 - 7, 28);
            if (dSkinGridList_PlayList_LocalList.Columns.Count > 0)
                dSkinGridList_PlayList_LocalList.Columns[1].Width = this.Width - 4;
        }

        private void dSkinGridList_PlayList_LocalList_ItemDoubleClick(object sender, DSkinGridListMouseEventArgs e)
        {
            PlaySelectedLocalFile();
        }

        private void PlaySelectedLocalFile()
        {
            mainfrm.b_PlayTV = false;
            DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.SelectedItem;
            if (dr == null)
                mainfrm.OpenFile();
            else
            {
                string str_LocalURL = dr.Cells[2].Text;
                if (str_LocalURL == "")
                    return;
                mainfrm.str_NowPlaying = Path.GetFileName(str_LocalURL);
                //int nPosition = Convert.ToInt32(dr.Cells[3].Text);
                mainfrm.OpenFile(str_LocalURL, -1);

                Console.WriteLine(str_LocalURL);
            }
        }

        private void toolStripMenuItem_LocalList_Play_Click(object sender, EventArgs e)
        {
            PlaySelectedLocalFile();
        }

        private void toolStripMenuItem_PlayFromStart_Click(object sender, EventArgs e)
        {
            mainfrm.b_PlayTV = false;
            DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.SelectedItem;
            if (dr == null)
                mainfrm.OpenFile();
            else
            {
                string str_LocalURL = dr.Cells[2].Text;
                if (str_LocalURL == "")
                    return;
                mainfrm.OpenFile(str_LocalURL, 0);

                Console.WriteLine(str_LocalURL);
            }
        }

        private void toolStripMenuItem_LocalList_Delete_Click(object sender, EventArgs e)
        {
            if (dSkinGridList_PlayList_LocalList.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dSkinGridList_PlayList_LocalList.SelectedItems.Count; i++)
                {
                    DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.SelectedItems[i];
                    dSkinGridList_PlayList_LocalList.Rows.Remove(dr);
                    string sql = "delete from LocalList " + " where FileFullName = '" + dr.Cells[2].Text + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, mainfrm.SQLiteConn);
                    command.ExecuteNonQuery();
                }

            }
            dSkinGridList_PlayList_LocalList.LayoutContent();
            dSkinGridList_PlayList_LocalList.SelectedItems.Clear();
        }

        private void toolStripMenuItem_DeleteUselessFile_Click(object sender, EventArgs e)
        {
            for (int i = dSkinGridList_PlayList_LocalList.RowCount - 1; i >= 0; i--)
            {
                DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.Rows[i];
                if (!File.Exists(dr.Cells[1].Text))
                {
                    dSkinGridList_PlayList_LocalList.Rows.Remove(dr);
                    string sql = "delete from LocalList " + " where FileFullName = '" + dr.Cells[2].Text + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, mainfrm.SQLiteConn);
                    command.ExecuteNonQuery();
                }
            }
            dSkinGridList_PlayList_LocalList.LayoutContent();
        }

        private void toolStripMenuItem_LocalList_ClearList_Click(object sender, EventArgs e)
        {
            dSkinGridList_PlayList_LocalList.Rows.Clear();
            string sql = "delete from LocalList";
            SQLiteCommand command = new SQLiteCommand(sql, mainfrm.SQLiteConn);
            command.ExecuteNonQuery();
        }

        private void toolStripMenuItem_LocalList_Add_Click(object sender, EventArgs e)
        {
            mainfrm.OpenFile();
        }

        private void toolStripMenuItem_MoveUp_Click(object sender, EventArgs e)
        {
            DSkinGridListRow dr_SelFirst = dSkinGridList_PlayList_LocalList.SelectedItems[0];
            int index = dSkinGridList_PlayList_LocalList.Rows.IndexOf(dr_SelFirst);
            if (0 == index)
                return;

            for (int i = 0; i < dSkinGridList_PlayList_LocalList.SelectedItems.Count; i++)
            {
                DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.SelectedItems[i];
                string strFileFullName = dr.Cells[2].Text;
                dSkinGridList_PlayList_LocalList.Rows.Remove(dSkinGridList_PlayList_LocalList.SelectedItems[i]);
                dSkinGridList_PlayList_LocalList.Rows.Insert(index - 1 + i, dr);
            }
            ReadLocalList();
        }

        private void toolStripMenuItem_MoveTop_Click(object sender, EventArgs e)
        {
            DSkinGridListRow dr_SelFirst = dSkinGridList_PlayList_LocalList.SelectedItems[0];
            if (0 == dSkinGridList_PlayList_LocalList.Rows.IndexOf(dr_SelFirst))
                return;

            for (int i = 0; i < dSkinGridList_PlayList_LocalList.SelectedItems.Count; i++)
            {
                DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.SelectedItems[i];
                dSkinGridList_PlayList_LocalList.Rows.Remove(dSkinGridList_PlayList_LocalList.SelectedItems[i]);
                dSkinGridList_PlayList_LocalList.Rows.Insert(i, dr);
            }
        }

        private void toolStripMenuItem_MoveDown_Click(object sender, EventArgs e)
        {
            int nCount = dSkinGridList_PlayList_LocalList.RowCount;
            DSkinGridListRow dr_SelLast = dSkinGridList_PlayList_LocalList.SelectedItems[dSkinGridList_PlayList_LocalList.SelectedItems.Count - 1];
            int index = dSkinGridList_PlayList_LocalList.Rows.IndexOf(dr_SelLast);

            if (nCount - 1 == index)
                return;

            for (int i = 0; i < dSkinGridList_PlayList_LocalList.SelectedItems.Count; i++)
            {
                DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.SelectedItems[i];
                dSkinGridList_PlayList_LocalList.Rows.Remove(dSkinGridList_PlayList_LocalList.SelectedItems[i]);
                dSkinGridList_PlayList_LocalList.Rows.Insert(index + 1 + i, dr);
            }
        }

        private void toolStripMenuItem_MoveBottom_Click(object sender, EventArgs e)
        {
            int nCount = dSkinGridList_PlayList_LocalList.RowCount;
            DSkinGridListRow dr_SelLast = dSkinGridList_PlayList_LocalList.SelectedItems[dSkinGridList_PlayList_LocalList.SelectedItems.Count - 1];
            if (dr_SelLast == dSkinGridList_PlayList_LocalList.Rows[nCount - 1])
                return;

            for (int i = 0; i < dSkinGridList_PlayList_LocalList.SelectedItems.Count; i++)
            {
                DSkinGridListRow dr = dSkinGridList_PlayList_LocalList.SelectedItems[i];
                dSkinGridList_PlayList_LocalList.Rows.Remove(dSkinGridList_PlayList_LocalList.SelectedItems[i]);
                dSkinGridList_PlayList_LocalList.Rows.Insert(nCount - 1 - i, dr);
            }
        }

        private void toolStripMenuItem_AddFolder_Click(object sender, EventArgs e)
        {
            mainfrm.OpenFolder();
        }
    }
}
