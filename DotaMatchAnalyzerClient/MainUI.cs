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
using DACommonLibrary.Interfaces;

namespace DotaMatchAnalyzerClient
{
    public partial class MainUI : Form
    {
        private bool IsDownloading;
        private ManagerHelper ManagerHelper { get; set; }
        Timer Timer;
        int DownloadCountdown;
        TimeSpan Time;
        double PercentageDownloadComplete;
        long StartOfDownload;
        long EndOfDownload;

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
            if (Timer == null) { Timer = new Timer(); }
            Timer.Tick += TimerTick;
            if (Time == null) { Time = new TimeSpan(); }
            ManagerHelper.DownloadFinished += OnDownloadFinished;
            ManagerHelper.DataWritten += DownloadStatusUpdate;
            IsDownloading = false;

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
                long[] MatchCount = ManagerHelper.GetMatchCount();
                labelMatchCount.Text = "Current match count: " + MatchCount.Count();
                lblHighestMatchId.Text = "Highest Match_Id: " + MatchCount.Max().ToString();
                lblLowestMatchId.Text = "Lowest Match_Id: " + MatchCount.Min().ToString();
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

        //start a download
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (!IsDownloading) //prevent double downloads
            {
                try
                {
                    //parse user input
                    string Range = txtDownloadRange.Text;
                    string Lowrange = Range.Split(':')[0];
                    String Highrange = Range.Split(':')[1];
                    long lowrange = Int64.Parse(Lowrange);
                    long highrange = Int64.Parse(Highrange);
                    //show confirmation dialog
                    DialogResult Response = MessageBox.Show("Hoeveel matches G? " + (highrange - lowrange).ToString(), "hoeveel nullen is dat?", MessageBoxButtons.OKCancel);
                    if (Response == DialogResult.OK)
                    {
                        //initiate an approximate countdown and start download and disable download button
                        Timer.Interval = 1000;
                        Timer.Enabled = true;
                        DownloadCountdown = (int)(highrange - lowrange) / 3; //3 matches per second
                        Timer.Start();
                        TimerTick(null, null);
                        lblTimer.Visible = true;
                        //set color red to indicate downloading
                        this.BackColor = Color.Red; //huehuehuehuehuehue
                        IsDownloading = true;
                        btnDownload.Enabled = false;
                        //store the low and high values
                        StartOfDownload = lowrange;
                        EndOfDownload = highrange;
                        ManagerHelper.DownloadMatches(lowrange, highrange);

                    }
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("Correct input format = 0123456789:9876543210");
                } 
            }
            else
            {
                MessageBox.Show("Please wait for previous download to finish");
            }
        }

        #region onEvents
        /// <summary>
        /// event handler for when download finishes
        /// </summary>
        private void OnDownloadFinished()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                this.BackColor = Color.White;
                this.IsDownloading = false;
                btnDownload.Enabled = true;
                Timer.Stop();
                lblTimer.Visible = false;
                PercentageDownloadComplete = 0;
            }));
        }

        private void DownloadStatusUpdate(object e, DownloaderEventArgs downloaderEventArgs) //linked to OnDataWritten in managerhelper
        {
            long LatestMatchDownloaded = downloaderEventArgs.HighestMatchIdWritten;
            PercentageDownloadComplete = (LatestMatchDownloaded - StartOfDownload) / (EndOfDownload - StartOfDownload);
        }

        private void TimerTick(object e, EventArgs eventArgs)
        {
            Time = TimeSpan.FromSeconds(--DownloadCountdown);
            lblTimer.Text = Time.ToString(@"hh\:mm\:ss") + " " + PercentageDownloadComplete*100 + "%";
        }
        #endregion
    }
}
