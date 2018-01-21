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

    }
}
