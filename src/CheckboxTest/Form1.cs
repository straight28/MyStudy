using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckboxTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        // {
        //     Console.WriteLine("체크");
        // }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor = Color.Red;
                }
            }

            dataGridView1.EndEdit();
            dataGridView1.CellMouseUp -= dataGridView1_CellMouseUp;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.RowHeadersVisible = false;


            DataGridViewCheckBoxColumn checkBoxColumn1 = new DataGridViewCheckBoxColumn();
            checkBoxColumn1.HeaderText = "테스트1";

            DataGridViewCheckBoxColumn checkBoxColumn2 = new DataGridViewCheckBoxColumn();
            checkBoxColumn2.HeaderText = "테스트2";

            DataGridViewCheckBoxColumn checkBoxColumn3 = new DataGridViewCheckBoxColumn();
            checkBoxColumn3.HeaderText = "테스트3";

            dataGridView1.Columns.Add(checkBoxColumn1);
            dataGridView1.Columns.Add(checkBoxColumn2);
            dataGridView1.Columns.Add(checkBoxColumn3);

            dataGridView1.Rows.Add(0, 1, 0);
            dataGridView1.Rows.Add(0, 0, 0);
            dataGridView1.Rows.Add(0, 1, 1);
            dataGridView1.Rows.Add(0, 0, 1);
            dataGridView1.Rows.Add(0, 1, 0);
            dataGridView1.Rows.Add(0, 0, 0);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value) == true)
                {
                    dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Green;
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Red;
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                }
            }

        }
    }
}
