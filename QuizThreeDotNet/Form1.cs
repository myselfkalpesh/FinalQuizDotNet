using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuizThreeDotNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new object[] {"Civic","CR-V", "Accord"});
            }
            else if (comboBox1.SelectedIndex == 1)
            {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new object[] { "Elantra", "Tucson","Santa Fe" });
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = !groupBox2.Enabled;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !groupBox1.Enabled;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMsg = string.Empty;
         if (textBox1.Text.Length == 0)
            {
                errorMsg += "First Name \n";
            }
         if (textBox2.Text.Length == 0)
        {
            errorMsg += "Last Name \n";
        }
        if (textBox3.Text.Length == 0)
        {
            errorMsg += "Telephone";
        }
        if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Following fields cannot be empty \n" + errorMsg);
            }
        else
            {
                //FileStream myFile = new FileStream(@"C:\Users\1896153\source\repos\QuizThreeDotNet\QuizThreeDotNet\temp.txt", FileMode.Append);
                //StreamWriter sr = new StreamWriter(myFile);
                //sr.WriteLine("\n------New Customer------");
                //sr.WriteLine(comboBox1.SelectedItem.ToString());
                //sr.WriteLine(comboBox2.SelectedItem.ToString());
                //sr.WriteLine(comboBox3.SelectedItem.ToString());
                //sr.WriteLine(textBox1.Text);
                //sr.WriteLine(textBox2.Text);
                //sr.WriteLine(textBox3.Text);

                //sr.Close();

                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        
                        using (var writer = new StreamWriter(myStream))
                        {
                           
                            writer.WriteLine("\n------New Customer------");
                            writer.WriteLine(comboBox1.SelectedItem.ToString());
                            writer.WriteLine(comboBox2.SelectedItem.ToString());
                            writer.WriteLine(comboBox3.SelectedItem.ToString());
                            writer.WriteLine(textBox1.Text);
                            writer.WriteLine(textBox2.Text);
                            writer.WriteLine(textBox3.Text);

                        }
                        myStream.Close();
                    }
                }
                MessageBox.Show("File Saved");


                //SaveFileDialog1.SupportMultiDottedExtensions = true;
                //foreach (String file in SaveFileDialog1.FileNames)
                //{
                //    MessageBox.Show(file);
                //}
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }
    }
}
