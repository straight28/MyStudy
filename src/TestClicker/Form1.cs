using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClicker
{
    public partial class Form1 : Form
    {

        private double Tick = 0;
        private double Total = 0;

        private int l1Add = 1;
        private int l1Level = 1;

        private int l3Add = 3;
        private int l3Level = 1;

        private int l50Add = 0;
        private int l50Level = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer oTimer = new Timer();

            oTimer.Enabled = true;

            // 몇초마다 타이머를 호출할 지
            oTimer.Interval = 100;  //0.1초  1000-> 1초
            oTimer.Tick += OTimer_Tick;
            oTimer.Start();
        }

        // 타이머에서 호출 할 Event (interval 간격 기준)
        private void OTimer_Tick(object sender, EventArgs e)
        {

            

            Tick = l1Add + l3Add + l50Add;
            Total = Total + Tick;
            lblTickPoint.Text = string.Format("{0} (1:{1}), (3:{2}), (50:{3})"
                                             ,Tick.ToString(), l1Level.ToString(), l3Level.ToString(), l50Level.ToString());
            lblTotal.Text = Total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // sender 를 Button으로 형변환
            Button otn = sender as Button;

            switch (otn.Name)
            {
                case "btn1Add":
                    if(Total > 100)
                    {
                        Total = Total - 100;

                        l1Level++;
                        l1Add = 1 * l1Level;
                    }
                    break;

                case "btn3Add":
                    if (Total > 300)
                    {
                        Total = Total - 300;

                        l3Level++;
                        l3Add = 3 * l3Level;
                    }
                  
                    break;

                case "btn50Add":
                    if (Total > 5000)
                    {
                        Total = Total - 500;

                        l50Level++;
                        l50Add = 50 * l50Level;
                    }
                    
                    break;

                default:
                    break;
            }
        }
    }
}
