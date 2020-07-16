using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.XPath;
namespace SBoxModList
{

    public partial class Form1 : Form
    {
        private const string SteamWorkshopPrefix = "Steam Workshop::";
        OpenFileDialog ofd = new OpenFileDialog();
        WebTimeout web = new WebTimeout();
        XPathDocument sbcFile;
        XPathNavigator nav;
        XPathNodeIterator modListIt;
        
        public Form1()
        {
            ofd.Filter = "SBC|*.sbc";
            InitializeComponent();
        }

        public struct ModInfo
        {
            public String ID;
            public String title;
            public String URL;
        }
        public List<ModInfo> modList = new List<ModInfo>();


        private void loadModFileClick(object sender, EventArgs e)
        {


            
            try
            {

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    lblLoad.Text = "Loading: ";
                    String fName = ofd.FileName;
                    String sFName = ofd.FileName;
                    sbcFile = new XPathDocument(fName);
                    nav = sbcFile.CreateNavigator();
                    modListIt = nav.Select("//ModItem/PublishedFileId");
                    
                    /*
                    txtOutRAW.Clear();
                    
                    while (modListIt.MoveNext())
                    {
                        
                        txtOutRAW.AppendText(modListIt.Current.InnerXml + "\r\n");
                        

                    }
                    */

                    modList.Clear();
                    while (modListIt.MoveNext())
                    {
                        ModInfo modInfo = loadModInfo(modListIt.Current.InnerXml);
                        modList.Add(modInfo);
                        lblLoad.Text += "|";
                        if(lblLoad.Text.TakeWhile(c => c == '|').Count()>10)
                        {
                            lblLoad.Text = "Loading: ";
                        }
                        
                        lblLoad.Refresh();
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(500);
                    }

                    modList = modList.OrderBy(m => m.ID).ToList();

                    txtOutRAW.Clear();
                    txtOut.Clear();
                    foreach (ModInfo mi in modList)
                    {
                        txtOutRAW.AppendText(mi.ID + "\r\n");
                        StringBuilder tOut = new StringBuilder();
                        tOut.Append("ModID: " + mi.ID + "       ");
                        tOut.Append("ModName: " + mi.title + "      ");
                        tOut.Append("Workshop URL: " + mi.URL + "\r\n");
                        txtOut.AppendText(tOut.ToString());
                    }
                    lblLoad.Text = "File Loaded";

                    //old code deprecated
                    /*
                    while (modListIt.MoveNext())
                    {
                        StringBuilder outputStr = new StringBuilder();
                        string ID = modListIt.Current.InnerXml;
                        outputStr.Append("ModID>>   " + ID);
                        string URL =  "http://steamcommunity.com/sharedfiles/filedetails/?id=" + ID;
                        try{
                            string workshopPage = web.DownloadString(URL);
                        string title = Regex.Match(workshopPage, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                        title = title.Replace("Steam Workshop :: ", "");
                        outputStr.Append("  >>NAME>>    " + title);
                        }
                        catch(Exception)
                        {
                            outputStr.Append("      >>NAME>>         BadURL");
                        }
                        outputStr.Append("  >>LINK>>    " + URL);
                        outputStr.Append("\r\n");
                        txtOut.AppendText(outputStr.ToString());
                                                
                    }

                    */
                }
                else { txtOutRAW.Text = "Unable To Read File"; }
            }
            catch (Exception)
            {
                txtOutRAW.Text = "An Unknown Error Has Occurred";
            }
        }

        private void txtOut_LinkClicked(Object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        /// <summary>
        /// SORT BY NAME AND LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSName_Click(object sender, EventArgs e)
        {
            modList = modList.OrderBy(m => m.title).ToList();
            printLongView();
        }

        /// <summary>
        /// SORT BY ID AND LOAD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSID_Click(object sender, EventArgs e)
        {
            modList = modList.OrderBy(m => m.ID).ToList();
            printLongView();
        }

        /// <summary>
        /// FORUM VIEW
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forumUrlButtonClick(object sender, EventArgs e)
        {
            printForumView();
        }

        /// <summary>
        /// GET MOD INFO FROM STEAM
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private ModInfo loadModInfo(string id)
        {
            ModInfo modInfo = new ModInfo();
            modInfo.ID = id;
            modInfo.URL = "http://steamcommunity.com/sharedfiles/filedetails/?id=" + modInfo.ID;
            int failcount = 0;
            do
            {
                try
                {
                    string workshopPage = web.DownloadString(modInfo.URL);
                    System.Threading.Thread.Sleep(500);
                    modInfo.title = Regex.Match(workshopPage, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                    modInfo.title = modInfo.title.Replace(SteamWorkshopPrefix, "");
                    if (failcount > 0) failcount = 0;

                }
                catch (Exception)
                {
                    modInfo.title = "URL Timed Out";
                    failcount++;
                }
            } while (failcount > 0 && failcount < 4);

            return modInfo;
        }

        /// <summary>
        /// RELOAD MOD LIST
        /// </summary>
        private void reloadModList() {
            txtOut.Clear();
            lblLoad.Text = "Reloading: ";
            modList.Clear();
            string[] lines = txtOutRAW.Lines;
            for (var i = 0; i < lines.Length; i++) {
                ModInfo modInfo = loadModInfo(lines[i]);
                modList.Add(modInfo);
                lblLoad.Text += "|";
                if (lblLoad.Text.TakeWhile(c => c == '|').Count() > 10)
                {
                    lblLoad.Text = "Reloading: ";
                }
                lblLoad.Refresh();
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
            lblLoad.Text = "Reloaded";

            printLongView();
        }

        private void reloadButtonClick(object sender, EventArgs e)
        {
            reloadModList();
        }

        private void printLongView() {
            txtOutRAW.Clear();
            txtOut.Clear();
            foreach (ModInfo mi in modList)
            {
                txtOutRAW.AppendText(mi.ID + "\r\n");
                StringBuilder tOut = new StringBuilder();
                tOut.Append("ModID: " + mi.ID + "       ");
                tOut.Append("ModName: " + mi.title + "      ");
                tOut.Append("Workshop URL: " + mi.URL + "\r\n");
                txtOut.AppendText(tOut.ToString());
            }
        }

        private void printForumView() {
            txtOutRAW.Clear();
            txtOut.Clear();
            foreach (ModInfo mi in modList)
            {
                txtOutRAW.AppendText(mi.ID + "\r\n");
                StringBuilder tOut = new StringBuilder();

                tOut.Append("[URL=")
                    .Append(mi.URL)
                    .Append("]")
                    .Append(mi.title)
                    .Append("[/URL]")
                    .Append(Environment.NewLine);
                txtOut.AppendText(tOut.ToString());
            }
        }

        private void printDiscordView()
        {
            txtOutRAW.Clear();
            txtOut.Clear();
            foreach (ModInfo mi in modList)
            {
                txtOutRAW.AppendText(mi.ID + "\r\n");
                StringBuilder tOut = new StringBuilder();

                tOut.Append(mi.title)
                    .Append(" - ")
                    .Append(mi.URL)
                    .Append(Environment.NewLine);
                txtOut.AppendText(tOut.ToString());
            }
        }

        private void discordViewOnClick(object sender, EventArgs e)
        {
            printDiscordView();
        }
    }

    public class WebTimeout : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 5000;
            return w;
        }
    }
}
