using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 生成按钮，点击生成，随机生成自定义的题目数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            int topicN = Convert.ToInt32(topicNum.Text);
            int MaxN = Convert.ToInt32(Max.Text);
            int topicType = comboTopicChange.SelectedIndex;
            if (topicType == -1)
            {
                topicType = 0;
            }
            bool haveBracket = checkBox1.Checked;
            bool haveDecimal = checkBox2.Checked;
            for (int i = 0; i < topicN; i++)
            {
                InfixCreater.InitInfixCreater(haveBracket);
                String str = InfixCreater.InfixCreate(haveDecimal,MaxN,topicType);
                topicText.AppendText(str + "\r\n");
            }

        }
        /// <summary>
        /// 保存按钮作用，点击保存，选择保存路径，将题目
        /// 保存为txt文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "请选择要保存的路径";
            saveFile.Filter = "文本文件|*.txt|所有文件|*.*";
            saveFile.ShowDialog();
            string path = saveFile.FileName;
            if (path == null)
            {
                return;
            }
            try
            {
                using (FileStream fileSaveStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(topicText.Text);
                    fileSaveStream.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            topicText.Clear();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            topicText.Clear();
        }
    }
}
