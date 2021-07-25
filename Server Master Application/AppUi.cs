using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Master
{
    public partial class AppUi : MaterialSkin.Controls.MaterialForm
    {
        public AppUi()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinMnager = MaterialSkin.MaterialSkinManager.Instance;
            SkinManager.AddFormToManage(this);
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            SkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green900, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
        }

        public DataTable dtbProdServerList = new DataTable();
        public DataTable dtbStageServerList = new DataTable();
        public Dictionary<string, string> dcProdServerList = new Dictionary<string, string>();
        public Dictionary<string, string> dcStageServerList = new Dictionary<string, string>();


        private void AppUi_Load(object sender, EventArgs e)
        {
            lblException.Visible = false;
            lblServer.Visible = false;
            ddServer.Enabled = false;
            btnOpenServer.Enabled = false;
            setServerList();
        }

        private void ddEnv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblServer.Visible = false;
            if (ddEnv.SelectedItem.ToString().Trim() == "Production")
            {
                ddServer.Enabled = true;
                btnOpenServer.Enabled = true;
                ddServer.DataSource = dtbProdServerList;
                ddServer.ValueMember = "Server Name";
                ddServer.DisplayMember = "Server Name";
            }
            if (ddEnv.SelectedItem.ToString().Trim() == "Stage")
            {
                ddServer.Enabled = true;
                btnOpenServer.Enabled = true;
                ddServer.DataSource = dtbStageServerList;
                ddServer.ValueMember = "Server Name";
                ddServer.DisplayMember = "Server Name";
            }
        }
        

        public void setServerList()
        {
            string szServerListPath = Convert.ToString(ConfigurationManager.AppSettings["serverListPath"]).Trim();
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(szServerListPath);
            Worksheet sheetProd = workbook.Worksheets[0];
            dtbProdServerList = sheetProd.ExportDataTable();
            Worksheet sheetStage = workbook.Worksheets[1];
            dtbStageServerList = sheetStage.ExportDataTable();
            dcProdServerList = dtbProdServerList.AsEnumerable().ToDictionary(row => row.Field<string>(0).Trim(), row => row.Field<string>(1).Trim());
            dcStageServerList = dtbStageServerList.AsEnumerable().ToDictionary(row => row.Field<string>(0).Trim(), row => row.Field<string>(1).Trim());
        }

        private void ddServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] szValue = new string[5];
            lblException.Visible = false;
            if (ddEnv.Text.Trim() == "Production")
            {
                if (dcProdServerList.ContainsKey(Convert.ToString(ddServer.Text).Trim()))
                {

                    lblServer.Text = dcProdServerList[ddServer.Text.Trim()];
                    if (lblServer.Text.Length > 17)
                    {
                        szValue = Convert.ToString(lblServer.Text).Split(' ');
                        lblServer.Text = szValue[0] + "\n" + szValue[1] + "\n" + szValue[2];
                    }
                    lblServer.Visible = true;
                }
            }
            if (ddEnv.Text.Trim() == "Stage")
            {
                if (dcStageServerList.ContainsKey(Convert.ToString(ddServer.Text).Trim()))
                {

                    lblServer.Text = dcStageServerList[ddServer.Text.Trim()];
                    if (lblServer.Text.Length > 17)
                    {
                        szValue = Convert.ToString(lblServer.Text).Split(' ');
                        lblServer.Text = szValue[0] + "\n" + szValue[1] + "\n" + szValue[2];
                    }
                    lblServer.Visible = true;
                }
            }
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            string szServerPath = string.Empty;
            szServerPath = Convert.ToString(ConfigurationManager.AppSettings["serverPath"]).Trim();
            try
            {
                if (ddEnv.Text.Trim() == "Production")
                {
                    if (dcProdServerList.ContainsKey(Convert.ToString(ddServer.Text).Trim()))
                    {
                        szServerPath = szServerPath + @"Production\" + Convert.ToString(dcProdServerList.FirstOrDefault(x => x.Value.Equals(dcProdServerList[Convert.ToString(ddServer.Text).Trim()])).Key) + ".msc";
                        Process.Start(szServerPath);
                    }
                }
                if (ddEnv.Text.Trim() == "Stage")
                {
                    if (dcStageServerList.ContainsKey(Convert.ToString(ddServer.Text).Trim()))
                    {
                        szServerPath = szServerPath + @"Stage\" + Convert.ToString(dcStageServerList.FirstOrDefault(x => x.Value.Equals(dcStageServerList[Convert.ToString(ddServer.Text).Trim()])).Key) + ".msc";
                        Process.Start(szServerPath);
                    }
                }
            }
            catch (Exception ex)
            {
                lblServer.Visible = false;
                lblException.Text = "Unable to Open Server!! Error- Please Try Again";
                lblException.Visible = true;
            }
        }
    }
}
