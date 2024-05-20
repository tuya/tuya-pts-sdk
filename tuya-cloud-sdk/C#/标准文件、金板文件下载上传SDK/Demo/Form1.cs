using StandardFileHelper;
using StandardFileHelper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        FileHelper filehlper=new FileHelper();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
           int ret= filehlper.Login(txtUsername.Text,txtPassword.Text,ref error);
            if (ret == 0)
            {
                MessageBox.Show("登录成功");
            }
            else
            {
                MessageBox.Show($"登录失败：{error}");
            }
        }

        /// <summary>
        /// 标准文件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            int ret = filehlper.GetStandardParameter(txtproductmodel.Text, txtTestEquipment.Text, textBox1.Text, ref error);

            if (ret == 0)
            {
                MessageBox.Show("标准文件下载成功");
            }
            else
            {
                MessageBox.Show($"标准文件下载失败：{error}");
            }
        }
        /// <summary>
        /// 金板文件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            int ret = filehlper.GetGoldPlateStandard(textBox4.Text, textBox2.Text, ref error);

            if (ret == 0)
            {
                MessageBox.Show("金板文件下载成功");
            }
            else
            {
                MessageBox.Show($"金板文件下载失败：{error}");
            }
        }
        /// <summary>
        /// 线损文件上报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            UploadLineLossPara para = new UploadLineLossPara();
            para.GoldPlateSN = textBox5.Text;
            para.InstrumentSN = textBox7.Text;
            para.ProductModel = textBox6.Text;
            para.SelectRFnum = textBox8.Text;
            int ret = filehlper.UploadLineLoss(para, textBox3.Text, ref error);

            if (ret == 0)
            {
                MessageBox.Show("线损文件上报成功");
            }
            else
            {
                MessageBox.Show($"线损文件上报失败：{error}");
            }
        }
        /// <summary>
        /// 线损文件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            int ret = filehlper.TuyaGetLineLossFile(Convert.ToInt32(textBox9.Text), textBox11.Text, textBox10.Text, textBox13.Text, textBox12.Text, ref error);

            if (ret == 0)
            {
                MessageBox.Show("线损文件下载成功");
            }
            else
            {
                MessageBox.Show($"线损文件下载失败：{error}");
            }
        }
    }
}
