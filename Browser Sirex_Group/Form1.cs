using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_Sirex_Group
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        WebBrowser browser = new WebBrowser();
        int i = 0;

private void Form1_Load(object sender, EventArgs e)
        {
            browser = new WebBrowser(); 
            browser.ScriptErrorsSuppressed = true;
            browser.Dock = DockStyle.Fill;
            browser.Visible = true;
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.Navigate("https://www.google.com");
            tabControl1.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Left;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(browser);
            i += 1;
        }

        void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;

            textBox1.Text = browser.Url.AbsoluteUri;
        }

        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                browser.Navigate(new Uri(address));
            }
            catch(System.UriFormatException)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://www.google.com");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(textBox1.Text);
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(textBox1.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            browser = new WebBrowser();
            browser.ScriptErrorsSuppressed = true;
            browser.Dock = DockStyle.Fill;
            browser.Visible = true;
            browser.DocumentCompleted += Browser_DocumentCompleted;
            browser.Navigate("https://www.google.com");
            tabControl1.Anchor = AnchorStyles.Top & AnchorStyles.Bottom & AnchorStyles.Right & AnchorStyles.Left;
            tabControl1.TabPages.Add("New Tab");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(browser);
            i += 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
        }
    }
}
