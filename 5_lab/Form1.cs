﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5_lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add(); // я здесь создаю первую строку пустую чтобы она была
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = (int)numericUpDown1.Value; // номер всегда вписываю строки
            chart1.Titles.Add("Доли продаж по товарам");
            chart1.Series["1"].IsValueShownAsLabel = true;
            columnChart.Series["S2"].IsValueShownAsLabel = true;
            columnChart.Titles.Add("Доли продаж по товарам");
        }
        private void chart1_Click_1(object sender, EventArgs e)
        {
        }


        decimal oldValue = 1; // важная штука
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) // увеличение уменьшение кол-ва строк
        {
            if (numericUpDown1.Value > oldValue)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = (int)numericUpDown1.Value;
            }
            else if (numericUpDown1.Value < oldValue)
            {
                dataGridView1.Rows.RemoveAt((int)numericUpDown1.Value);
            }
            oldValue = numericUpDown1.Value;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) // здесь все проверки и счёт
        {
            chart1.Series["1"].Points.Clear();
            columnChart.Series["S2"].Points.Clear();
            // каждый раз очищаем диаграмму
            // если первые три строки не считая номера не нулевые, то  считаем
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((dataGridView1.Rows[i].Cells[1].Value != null) && (dataGridView1.Rows[i].Cells[2].Value != null) && (dataGridView1.Rows[i].Cells[3].Value != null))
                {
                    string fullNameOfProduct;
                    double price = 0.0;
                    int quantity = 0;
                    double fullPriceOfProduct = 0.0;
                    Double.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out price);
                    Int32.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out quantity);
                    fullPriceOfProduct = price * quantity;
                    fullNameOfProduct = fullPriceOfProduct.ToString() + " " + dataGridView1.Rows[i].Cells[1].Value.ToString();
                    chart1.Series["1"].Points.AddXY(fullNameOfProduct, fullPriceOfProduct);
                    columnChart.Series["S2"].Points.AddXY(fullNameOfProduct, fullPriceOfProduct);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                chart1.Show();
            }
            else
            {
                chart1.Hide();
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked == true)
            {
                columnChart.Show();
            }
            else
            {
                columnChart.Hide();
            }
            
        }
    }
}