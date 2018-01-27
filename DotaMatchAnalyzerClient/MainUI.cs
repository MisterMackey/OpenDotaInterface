using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotaMatchAnalyzerClient.Functions;

namespace DotaMatchAnalyzerClient
{
    public partial class MainUI : Form
    {
        private ManagerHelper ManagerHelper { get; set; }
        public MainUI()
        {
            InitializeComponent();
            //subscribe to load event
            this.Load += Form_Load;
        }

        //add code here that runs upon form loading
        private void Form_Load(object sender, EventArgs e)
        {
            //field filling
            ManagerHelper = new ManagerHelper();

            //event subscription
            //
            //event when selecting a new tab
            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;

            //set the startup tab to manage, this raises selectedindexchanged event
            TabControl.SelectedTab = TabManage;

        }

        //subscribed to event raised on selecting a new tab
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //code for when the tab is changed to Explore
            if (TabControl.SelectedTab.Name.Equals("TabExplore"))
            {
                //add code
            }
            //code for when the tab is changed to Manage
            else if (TabControl.SelectedTab.Name.Equals("TabManage"))
            {
                int MatchCount = ManagerHelper.GetMatchCount();
                labelMatchCount.Text = "Current match count: " + MatchCount;
            }
            //code for when the tab is changed to Analyze
            else if (TabControl.SelectedTab.Name.Equals("TabAnalyze"))
            {
                //add code
            }
            //initialize the helper
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult Response = MessageBox.Show( "You of deletings all matches except test match?", "Really?", MessageBoxButtons.YesNo);
            if (Response == DialogResult.Yes)
            {
                ManagerHelper.DeleteAllMatches();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string Range = txtDownloadRange.Text;
                string Lowrange = Range.Split(':')[0];
                String Highrange = Range.Split(':')[1];
                long lowrange = Int64.Parse(Lowrange);
                long highrange = Int64.Parse(Highrange);
                DialogResult Response = MessageBox.Show("Hoeveel matches G? " + (highrange-lowrange).ToString(), "hoeveel nullen is dat?", MessageBoxButtons.OKCancel);
                if (Response == DialogResult.OK)
                {
                    this.BackColor = Color.Red; //huehuehuehuehuehue
                    ManagerHelper.DownloadFinished += OnDownloadFinished;
                    ManagerHelper.DownloadMatches(lowrange, highrange);
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Correct input format = 0123456789:9876543210");
            }

        }

        private void OnDownloadFinished()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.BackColor = Color.White;
            }));
        }
    }
}
