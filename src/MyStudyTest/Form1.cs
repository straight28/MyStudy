using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CopyAndPaste
{
    public partial class Form1 : Form
    {

        CGlobalKeyboardHook _khook = new CGlobalKeyboardHook();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Version oVersion = Assembly.GetEntryAssembly().GetName().Version;
            this.Text = string.Format("{0} Ver.{1}.{2} / Build Time ({3})", "Copy&Paste", oVersion.Major, oVersion.Minor, GetBuidDateTime(oVersion), "프로그램 상태");



            _khook.hook();
            _khook.KeyDown += khook_keyDown;
        }

        public DateTime GetBuidDateTime(Version oVersion)
        {
            string strVerstion = oVersion.ToString();

            // 날짜등록
            int iDays = Convert.ToInt32(strVerstion.Split('.')[2]);
            DateTime refDate = new DateTime(2000, 1, 1);
            DateTime dtBuildDate = refDate.AddDays(iDays);

            // 초 등록
            int iSeconds = Convert.ToInt32(strVerstion.Split('.')[3]);
            iSeconds = iSeconds * 2;
            dtBuildDate = dtBuildDate.AddSeconds(iSeconds);

            // 시차 조정
            DaylightTime daylighttime = TimeZone.CurrentTimeZone.GetDaylightChanges(dtBuildDate.Year);

            if (TimeZone.IsDaylightSavingTime(dtBuildDate, daylighttime))
            {
                dtBuildDate = dtBuildDate.Add(daylighttime.Delta);
            }
            return dtBuildDate;
        }

        private void khook_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C && cboxactivation.Checked)
            {
                Thread.Sleep(400);
                lboxTextSave.Items.Add(Clipboard.GetData(System.Windows.Forms.DataFormats.UnicodeText).ToString());
            }
        }


        private void lboxTextSave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxTextSave.SelectedIndex != -1)
            {
                Clipboard.SetData(System.Windows.Forms.DataFormats.UnicodeText, lboxTextSave.SelectedItem.ToString());
            }

        }

        private void tBar_Scrol_Change(object sender, EventArgs e)
        {
            this.Opacity = Tbar.Value / 10.0;
        }

        private void btnlbtextadd_Click(object sender, EventArgs e)
        {
            DataSave();
        }

        private void txtlbtextadd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataSave();
            }
        }

        private void DataSave()
        {
            string strText = txtlbtextadd.Text;

            if (!string.IsNullOrEmpty(strText) && !lboxTextSave.Items.Contains(strText))
            {
                lboxTextSave.Items.Add(strText);
                txtlbtextadd.Text = "";
            }
        }

        private void cboxactivation_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxactivation.Checked)
            {
                lblactivation.Text = "활성화 상태 (Ctrl + C 가능)";
                lblactivation.Enabled = true;

                txtlbtextadd.Enabled = true;
                btnlbtextadd.Enabled = true;
            }
            else
            {
                lblactivation.Text = "비 활성화 상태(붙여넣기만 가능)";
                lblactivation.Enabled = false;

                txtlbtextadd.Enabled = false;
                btnlbtextadd.Enabled = false;
            }
        }

        private void lboxTextSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lboxTextSave.SelectedItems.Count > 0)
                {
                    lboxTextSave.Items.RemoveAt(lboxTextSave.SelectedIndex);
                }
            }
        }

        #region + mStrip

        private void 저장하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillSave();
        }

        private void 모두삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllEmptyDelete();
        }

        private void 프로그램정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramInfo();
        }

        private void 공백제거ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmptyDelete();
        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillLoad();
        }

        #endregion

        #region + cMStrip

        private void 공백제거ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EmptyDelete();
        }

        private void 모두삭제ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AllEmptyDelete();
        }

        private void 프로그램정보ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ProgramInfo();
        }

        private void 저장하기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FillSave();
        }

        private void 불러오기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FillLoad();
        }




        #endregion



        #region + Event Function

        /// <summary>
        /// 공백제거용 함수
        /// </summary>
        private void EmptyDelete()
        {
            int iCount = lboxTextSave.Items.Count;

            for (int i = 0; i < iCount; i++)
            {
                lboxTextSave.Items[i] = lboxTextSave.Items[i].ToString().Trim();
            }
        }
        
        /// <summary>
        /// 모두삭제용 함수
        /// </summary>
        private void AllEmptyDelete()
        {
            if(DialogResult.Yes == MessageBox.Show("등록되어 있는 Data를 초기화 합니다. ", "Listbox Item Clear", MessageBoxButtons.YesNo))
            {
                lboxTextSave.Items.Clear();
            }
        }

        /// <summary>
        /// 저장하기용 함수
        /// </summary>
        private void FillSave()
        {
            SaveFileDialog sDialog = new SaveFileDialog();

            int ilbCount = lboxTextSave.Items.Count;
            string strFilPath = string.Empty;

            sDialog.InitialDirectory = Application.StartupPath;
            sDialog.FileName = "*.txt";
            sDialog.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";

            try
            {
                if(sDialog.ShowDialog() == DialogResult.OK)
                {
                    strFilPath = sDialog.FileName;
                    StreamWriter swriter = new StreamWriter(strFilPath);

                    for (int i = 0; i < ilbCount; i++)
                    {
                        swriter.WriteLine(lboxTextSave.Items[i].ToString());
                    }
                    swriter.Close();
                    MessageBox.Show("저장완료");
                }
            }
            catch (Exception ex)
            {
                var text = ex.Message;
                MessageBox.Show("에러내용 : " + text);
            }

            
        }

        /// <summary>
        /// 불러오기용 함수
        /// </summary>
        private void FillLoad()
        {
            OpenFileDialog oDialog = new OpenFileDialog();

            string strFilePath = string.Empty;

            oDialog.InitialDirectory = Application.StartupPath;
            oDialog.FileName = "*.txt";
            oDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            try
            {
                if(oDialog.ShowDialog() == DialogResult.OK)
                {
                    strFilePath = oDialog.FileName;
                    StreamReader sreader = new StreamReader(strFilePath, Encoding.UTF8, true);

                    while (sreader.EndOfStream)
                    {
                        lboxTextSave.Items.Add(sreader.ReadLine());
                    }   
                }
            }
            catch (Exception ex)
            {
                var text = ex.Message;
                MessageBox.Show("에러내용 : " + text);
            }

             
        }

        /// <summary>
        /// 프로그램 정보
        /// </summary>
        private void ProgramInfo()
        {
            string strProgramIfo = "복사 앤 붙여넣기";

            MessageBox.Show(strProgramIfo);
        }


        #endregion

       
    }
}
