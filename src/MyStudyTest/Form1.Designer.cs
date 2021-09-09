
namespace CopyAndPaste
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lboxTextSave = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblactivation = new System.Windows.Forms.Label();
            this.cboxactivation = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Tbar = new System.Windows.Forms.TrackBar();
            this.btnlbtextadd = new System.Windows.Forms.Button();
            this.txtlbtextadd = new System.Windows.Forms.TextBox();
            this.mStrip = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.편집ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공백제거ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모두삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프로그램정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cMStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.공백제거ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.클립보드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.모두삭제ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.프로그램정보ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.저장하기ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.불러오기ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tbar)).BeginInit();
            this.mStrip.SuspendLayout();
            this.cMStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lboxTextSave
            // 
            this.lboxTextSave.ContextMenuStrip = this.cMStrip;
            this.lboxTextSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboxTextSave.FormattingEnabled = true;
            this.lboxTextSave.ItemHeight = 12;
            this.lboxTextSave.Location = new System.Drawing.Point(3, 43);
            this.lboxTextSave.Name = "lboxTextSave";
            this.lboxTextSave.Size = new System.Drawing.Size(329, 177);
            this.lboxTextSave.TabIndex = 0;
            this.lboxTextSave.SelectedIndexChanged += new System.EventHandler(this.lboxTextSave_SelectedIndexChanged);
            this.lboxTextSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lboxTextSave_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lboxTextSave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 263);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblactivation);
            this.panel1.Controls.Add(this.cboxactivation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 34);
            this.panel1.TabIndex = 1;
            // 
            // lblactivation
            // 
            this.lblactivation.AutoSize = true;
            this.lblactivation.Location = new System.Drawing.Point(134, 10);
            this.lblactivation.Name = "lblactivation";
            this.lblactivation.Size = new System.Drawing.Size(153, 12);
            this.lblactivation.TabIndex = 1;
            this.lblactivation.Text = "활성화 상태 (Ctrl + C 가능)";
            // 
            // cboxactivation
            // 
            this.cboxactivation.AutoSize = true;
            this.cboxactivation.Checked = true;
            this.cboxactivation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxactivation.Location = new System.Drawing.Point(9, 9);
            this.cboxactivation.Name = "cboxactivation";
            this.cboxactivation.Size = new System.Drawing.Size(78, 16);
            this.cboxactivation.TabIndex = 0;
            this.cboxactivation.Text = "Activation";
            this.cboxactivation.UseVisualStyleBackColor = true;
            this.cboxactivation.CheckedChanged += new System.EventHandler(this.cboxactivation_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Tbar);
            this.panel2.Controls.Add(this.btnlbtextadd);
            this.panel2.Controls.Add(this.txtlbtextadd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 226);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 34);
            this.panel2.TabIndex = 2;
            // 
            // Tbar
            // 
            this.Tbar.Location = new System.Drawing.Point(189, 0);
            this.Tbar.Minimum = 2;
            this.Tbar.Name = "Tbar";
            this.Tbar.Size = new System.Drawing.Size(131, 45);
            this.Tbar.TabIndex = 2;
            this.Tbar.Value = 10;
            this.Tbar.Scroll += new System.EventHandler(this.tBar_Scrol_Change);
            // 
            // btnlbtextadd
            // 
            this.btnlbtextadd.Location = new System.Drawing.Point(106, 2);
            this.btnlbtextadd.Name = "btnlbtextadd";
            this.btnlbtextadd.Size = new System.Drawing.Size(75, 23);
            this.btnlbtextadd.TabIndex = 1;
            this.btnlbtextadd.Text = "등록";
            this.btnlbtextadd.UseVisualStyleBackColor = true;
            this.btnlbtextadd.Click += new System.EventHandler(this.btnlbtextadd_Click);
            // 
            // txtlbtextadd
            // 
            this.txtlbtextadd.Location = new System.Drawing.Point(0, 3);
            this.txtlbtextadd.Name = "txtlbtextadd";
            this.txtlbtextadd.Size = new System.Drawing.Size(100, 21);
            this.txtlbtextadd.TabIndex = 0;
            this.txtlbtextadd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlbtextadd_KeyDown);
            // 
            // mStrip
            // 
            this.mStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.편집ToolStripMenuItem,
            this.프로그램정보ToolStripMenuItem});
            this.mStrip.Location = new System.Drawing.Point(0, 0);
            this.mStrip.Name = "mStrip";
            this.mStrip.Size = new System.Drawing.Size(335, 24);
            this.mStrip.TabIndex = 2;
            this.mStrip.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.저장하기ToolStripMenuItem,
            this.불러오기ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 저장하기ToolStripMenuItem
            // 
            this.저장하기ToolStripMenuItem.Name = "저장하기ToolStripMenuItem";
            this.저장하기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.저장하기ToolStripMenuItem.Text = "저장하기";
            this.저장하기ToolStripMenuItem.Click += new System.EventHandler(this.저장하기ToolStripMenuItem_Click);
            // 
            // 불러오기ToolStripMenuItem
            // 
            this.불러오기ToolStripMenuItem.Name = "불러오기ToolStripMenuItem";
            this.불러오기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.불러오기ToolStripMenuItem.Text = "불러오기";
            this.불러오기ToolStripMenuItem.Click += new System.EventHandler(this.불러오기ToolStripMenuItem_Click);
            // 
            // 편집ToolStripMenuItem
            // 
            this.편집ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.공백제거ToolStripMenuItem,
            this.모두삭제ToolStripMenuItem});
            this.편집ToolStripMenuItem.Name = "편집ToolStripMenuItem";
            this.편집ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.편집ToolStripMenuItem.Text = "편집";
            // 
            // 공백제거ToolStripMenuItem
            // 
            this.공백제거ToolStripMenuItem.Name = "공백제거ToolStripMenuItem";
            this.공백제거ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.공백제거ToolStripMenuItem.Text = "공백제거";
            this.공백제거ToolStripMenuItem.Click += new System.EventHandler(this.공백제거ToolStripMenuItem_Click);
            // 
            // 모두삭제ToolStripMenuItem
            // 
            this.모두삭제ToolStripMenuItem.Name = "모두삭제ToolStripMenuItem";
            this.모두삭제ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.모두삭제ToolStripMenuItem.Text = "모두삭제";
            this.모두삭제ToolStripMenuItem.Click += new System.EventHandler(this.모두삭제ToolStripMenuItem_Click);
            // 
            // 프로그램정보ToolStripMenuItem
            // 
            this.프로그램정보ToolStripMenuItem.Name = "프로그램정보ToolStripMenuItem";
            this.프로그램정보ToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.프로그램정보ToolStripMenuItem.Text = "프로그램 정보";
            this.프로그램정보ToolStripMenuItem.Click += new System.EventHandler(this.프로그램정보ToolStripMenuItem_Click);
            // 
            // cMStrip
            // 
            this.cMStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.공백제거ToolStripMenuItem1,
            this.클립보드ToolStripMenuItem,
            this.모두삭제ToolStripMenuItem1,
            this.toolStripSeparator1,
            this.프로그램정보ToolStripMenuItem2});
            this.cMStrip.Name = "cMStrip";
            this.cMStrip.Size = new System.Drawing.Size(151, 98);
            // 
            // 공백제거ToolStripMenuItem1
            // 
            this.공백제거ToolStripMenuItem1.Name = "공백제거ToolStripMenuItem1";
            this.공백제거ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.공백제거ToolStripMenuItem1.Text = "공백제거";
            this.공백제거ToolStripMenuItem1.Click += new System.EventHandler(this.공백제거ToolStripMenuItem1_Click);
            // 
            // 클립보드ToolStripMenuItem
            // 
            this.클립보드ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.저장하기ToolStripMenuItem1,
            this.불러오기ToolStripMenuItem1});
            this.클립보드ToolStripMenuItem.Name = "클립보드ToolStripMenuItem";
            this.클립보드ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.클립보드ToolStripMenuItem.Text = "클립보드";
            // 
            // 모두삭제ToolStripMenuItem1
            // 
            this.모두삭제ToolStripMenuItem1.Name = "모두삭제ToolStripMenuItem1";
            this.모두삭제ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.모두삭제ToolStripMenuItem1.Text = "모두삭제";
            this.모두삭제ToolStripMenuItem1.Click += new System.EventHandler(this.모두삭제ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 프로그램정보ToolStripMenuItem2
            // 
            this.프로그램정보ToolStripMenuItem2.Name = "프로그램정보ToolStripMenuItem2";
            this.프로그램정보ToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.프로그램정보ToolStripMenuItem2.Text = "프로그램 정보";
            this.프로그램정보ToolStripMenuItem2.Click += new System.EventHandler(this.프로그램정보ToolStripMenuItem2_Click);
            // 
            // 저장하기ToolStripMenuItem1
            // 
            this.저장하기ToolStripMenuItem1.Name = "저장하기ToolStripMenuItem1";
            this.저장하기ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.저장하기ToolStripMenuItem1.Text = "저장하기";
            this.저장하기ToolStripMenuItem1.Click += new System.EventHandler(this.저장하기ToolStripMenuItem1_Click);
            // 
            // 불러오기ToolStripMenuItem1
            // 
            this.불러오기ToolStripMenuItem1.Name = "불러오기ToolStripMenuItem1";
            this.불러오기ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.불러오기ToolStripMenuItem1.Text = "불러오기";
            this.불러오기ToolStripMenuItem1.Click += new System.EventHandler(this.불러오기ToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 287);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mStrip);
            this.MainMenuStrip = this.mStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tbar)).EndInit();
            this.mStrip.ResumeLayout(false);
            this.mStrip.PerformLayout();
            this.cMStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lboxTextSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblactivation;
        private System.Windows.Forms.CheckBox cboxactivation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar Tbar;
        private System.Windows.Forms.Button btnlbtextadd;
        private System.Windows.Forms.TextBox txtlbtextadd;
        private System.Windows.Forms.MenuStrip mStrip;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 편집ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공백제거ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 모두삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프로그램정보ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cMStrip;
        private System.Windows.Forms.ToolStripMenuItem 공백제거ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 클립보드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 저장하기ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 불러오기ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 모두삭제ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 프로그램정보ToolStripMenuItem2;
    }
}

