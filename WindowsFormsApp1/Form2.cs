using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        private Form1 _Form1;

        public Form2(Form1 form1)
        {
            _Form1 = form1;
            InitializeComponent();
        }

        private void bt_OK()
        {
            if (textBox1.Text.Equals("wp2") && textBox2.Text.Equals("1234"))
            {
                _Form1.LoginCheck = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디 또는 패스워드가 잘못 입력되었습니다.");

                textBox1.Text = "아이디를 입력 해주세요.";
                textBox2.Text = "비밀번호를 입력 해주세요.";
                textBox2.PasswordChar = '\0';
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bt_OK();
        }

        private void ID_click()
        {
            if (textBox1.Text == "아이디를 입력 해주세요.") textBox1.Text = "";
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            ID_click();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "비밀번호를 입력 해주세요.")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '\0';
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = "아이디를 입력 해주세요.";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "비밀번호를 입력 해주세요.";
                textBox2.PasswordChar = '\0';
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBox2.Focus();
                if (textBox2.Text == "비밀번호를 입력 해주세요.")
                {
                    textBox2.Text = "";
                    textBox2.PasswordChar = '*';
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) bt_OK();
            else if (e.KeyData == (Keys.Shift | Keys.Tab))
            {
                textBox1.Focus();

                ID_click();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                e.SuppressKeyPress = true;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                e.SuppressKeyPress = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
