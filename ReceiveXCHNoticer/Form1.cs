using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiveXCHNoticer {
  public partial class Form1 : Form {

    private string walletKey;
    //null for first check
    private XCHBalance lastResult = null;
    private System.Threading.Timer timer;
    private Regex regex = new Regex("{\"grossBalance\":(?<gross>\\d+),\"netBalance\":(?<net>\\d+)}");
    private const int TIMER_INTERVAL = 30 * 1000;

    public Form1() {
      InitializeComponent();
      this.ShowInTaskbar = false;
      textBox1.Text = walletKey = Settings1.Default.walletKey;
      timer = new System.Threading.Timer(timerCallback, null, 0, TIMER_INTERVAL);
    }

    private void timerCallback(object o) {
      TryGetBalance();
    }

    private void btnConfirmModify_Click(object sender, EventArgs e) {
      if (textBox1.ReadOnly) {
        textBox1.ReadOnly = false;
        btnConfirmModify.Text = "Confirm";
      } else {
        textBox1.ReadOnly = true;
        btnConfirmModify.Text = "Edit";

        if (walletKey != textBox1.Text) {

          Settings1.Default.walletKey = walletKey = textBox1.Text;
          Settings1.Default.Save();

          //execute immediately
          timer.Change(0, TIMER_INTERVAL);
        }
      }
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
      show();
    }

    private void show() {
      this.ShowInTaskbar = true;
      this.Visible = true;
      this.WindowState = FormWindowState.Normal;
      this.Activate();
    }

    private void Form1_SizeChanged(object sender, EventArgs e) {
      if (this.WindowState == FormWindowState.Minimized) {
        this.ShowInTaskbar = false;
        this.Visible = false;
        notifyIcon1.Visible = true;
      }
    }

    private string convertXCH(long val) {
      return Math.Round(val / (decimal)1000000000000L, 4).ToString();
    }

    private void TryGetBalance() {
      if (string.IsNullOrEmpty(walletKey)) {
        ShowMsg("Enter your wallet address first", Color.Orange);
        timer.Change(-1, TIMER_INTERVAL);
        return;
      }
      var url = "https://api2.chiaexplorer.com/balance/" + walletKey;
      try {
        var s_balance = HttpHelper.Get(url);
        var m = regex.Match(s_balance);
        if (!m.Success) {
          return;
        }
        string gross = m.Groups["gross"].Value;
        string net = m.Groups["net"].Value;
        var xch = new XCHBalance() {
          grossBalance = Convert.ToInt64(gross),
          netBalance = Convert.ToInt64(net)
        };
        ShowMsg("success " + DateTime.Now.ToString("HH:mm:ss"), Color.Green);
        refreshXch(xch);

        if (lastResult == null) {
          lastResult = xch;
          //show first check
          notifyIcon1.ShowBalloonTip(3 * 1000, "XCH Balance", convertXCH(xch.netBalance) + "/" + convertXCH(xch.grossBalance), ToolTipIcon.Info);
        } else {
          if (lastResult.grossBalance != xch.grossBalance || lastResult.netBalance != xch.netBalance) {
            //show changed
            var addNet = xch.netBalance - lastResult.netBalance;
            var addGross = xch.grossBalance - lastResult.grossBalance;

            notifyIcon1.ShowBalloonTip(30 * 1000, "XCH Balance Updated", convertXCH(xch.netBalance) + "(" + (addNet > 0 ? "+" : "") + convertXCH(addNet) + ")"
              + "\n" + convertXCH(xch.grossBalance) + "(" + (addNet > 0 ? "+" : "") + convertXCH(addGross) + ")", ToolTipIcon.Info);
          }
          lastResult = xch;
        }
      } catch (Exception e) {
        ShowMsg(e.Message, Color.Red);
      }
    }

    void refreshXch(XCHBalance xch) {
      if (this.InvokeRequired) {
        this.Invoke(new Action(() => {
          refreshXch(xch);
        }));
      } else {
        lbl_received.Text = convertXCH(xch.grossBalance);
        lbl_balance.Text = convertXCH(xch.netBalance);
        notifyIcon1.Text = "Updated at "+ DateTime.Now.ToString("HH:mm:ss")+ "\nXCH "
          + lbl_balance.Text +"/" + lbl_received.Text;
      }
    }

    void ShowMsg(string msg, Color color) {
      if (this.InvokeRequired) {
        this.Invoke(new Action(() => {
          ShowMsg(msg, color);
        }));
      } else {
        lbl_msg.Text = msg;
        lbl_msg.ForeColor = color;
      }
    }


    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
      timer.Dispose();
    }

    private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
      if (e.ClickedItem == tsmShow) {
        show();
      }
      if (e.ClickedItem == tsmExit) {
        this.Close();
      }
    }
  }
}
