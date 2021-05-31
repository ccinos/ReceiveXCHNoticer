namespace ReceiveXCHNoticer {
  partial class Form1 {
    /// <summary>
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows 窗体设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要修改
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.btnConfirmModify = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lbl_received = new System.Windows.Forms.Label();
      this.lbl_balance = new System.Windows.Forms.Label();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.lbl_msg = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnConfirmModify
      // 
      this.btnConfirmModify.Location = new System.Drawing.Point(605, 4);
      this.btnConfirmModify.Name = "btnConfirmModify";
      this.btnConfirmModify.Size = new System.Drawing.Size(75, 23);
      this.btnConfirmModify.TabIndex = 0;
      this.btnConfirmModify.Text = "Edit";
      this.btnConfirmModify.UseVisualStyleBackColor = true;
      this.btnConfirmModify.Click += new System.EventHandler(this.btnConfirmModify_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(107, 4);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(492, 21);
      this.textBox1.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 7);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 12);
      this.label1.TabIndex = 2;
      this.label1.Text = "Wallet Address:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 28);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(95, 12);
      this.label3.TabIndex = 4;
      this.label3.Text = "Coins received:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 48);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(101, 12);
      this.label2.TabIndex = 5;
      this.label2.Text = "Coins remaining:";
      // 
      // lbl_received
      // 
      this.lbl_received.AutoSize = true;
      this.lbl_received.Location = new System.Drawing.Point(105, 28);
      this.lbl_received.Name = "lbl_received";
      this.lbl_received.Size = new System.Drawing.Size(11, 12);
      this.lbl_received.TabIndex = 6;
      this.lbl_received.Text = "0";
      // 
      // lbl_balance
      // 
      this.lbl_balance.AutoSize = true;
      this.lbl_balance.Location = new System.Drawing.Point(105, 48);
      this.lbl_balance.Name = "lbl_balance";
      this.lbl_balance.Size = new System.Drawing.Size(11, 12);
      this.lbl_balance.TabIndex = 7;
      this.lbl_balance.Text = "0";
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // lbl_msg
      // 
      this.lbl_msg.Location = new System.Drawing.Point(366, 30);
      this.lbl_msg.Name = "lbl_msg";
      this.lbl_msg.Size = new System.Drawing.Size(314, 30);
      this.lbl_msg.TabIndex = 8;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(684, 69);
      this.Controls.Add(this.lbl_msg);
      this.Controls.Add(this.lbl_balance);
      this.Controls.Add(this.lbl_received);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.btnConfirmModify);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(700, 108);
      this.MinimumSize = new System.Drawing.Size(700, 108);
      this.Name = "Form1";
      this.ShowIcon = false;
      this.Text = "XCH Receive Noticer";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnConfirmModify;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lbl_received;
    private System.Windows.Forms.Label lbl_balance;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.Label lbl_msg;
  }
}

