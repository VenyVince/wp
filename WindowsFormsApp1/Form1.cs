using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // 정보저장 버튼 클릭시 발생하는 이벤트.
        {
            // 가게 이름, 전화번호, 주소, 음식 종류의 텍스트 박스 확인.
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                // 가게 이름, 전화번호, 주소, 음식 종류, 메모 텍스트 박스 정보를 받음.
                ListViewItem item = new ListViewItem(textBox1.Text);
                item.SubItems.Add(textBox2.Text);
                item.SubItems.Add(textBox3.Text);
                item.SubItems.Add(textBox4.Text);
                item.SubItems.Add(textBox5.Text);

                // 가게 이름, 전화번호, 주소, 음식 종류, 메모를 리스트뷰에 추가.
                listView1.Items.Add(item);

                // 가게 이름, 전화번호, 주소, 음식 종류 텍스트박스 초기화.
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            // 가게 이름, 전화번호, 주소, 음식 종류중 미입력 정보가 있으면 메세지박스 띄움.
            // + 추가할만한 기능 = 메세지박스 확인후 키보드 포커스 설정
            else if (textBox1.Text == "")
            {
                MessageBox.Show("가게 이름을 입력해 주세요.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("전화번호를 입력해 주세요.");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("주소를 입력해 주세요.");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("음식 종류를 입력해 주세요.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nameToSearch = textBox1.Text; // 검색할 이름
            string newName = textBox2.Text; // 새로운 이름
            string newPhone = textBox3.Text; // 새로운 전화번호
            string newAddress = textBox4.Text; // 새로운 주소
            string newType = textBox5.Text; // 새로운 종류


            // 예시: ListView에서 검색한 이름과 일치하는 항목을 찾고 수정
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text == nameToSearch)
                {
                    item.SubItems[0].Text = newName;
                    item.SubItems[1].Text = newPhone;
                    item.SubItems[2].Text = newAddress;
                    item.SubItems[3].Text = newType;
                }
            }


            // 수정이 성공하면 사용자에게 메시지를 표시합니다.
            MessageBox.Show("정보가 변경되었습니다.");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // ListView에서 선택한 항목의 정보를 가져와서 다른 텍스트 상자에 표시
                ListViewItem selectedItem = listView1.SelectedItems[0];
                textBox1.Text = selectedItem.SubItems[0].Text; // 가게 이름
                textBox2.Text = selectedItem.SubItems[1].Text; // 전화번호
                textBox3.Text = selectedItem.SubItems[2].Text; // 주소
                textBox4.Text = selectedItem.SubItems[3].Text; // 음식 종류
                textBox5.Text = selectedItem.SubItems[4].Text; // 메모
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목이 삭제됩니다.\r계속 하시겠습니다?", "항목 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int index = listView1.FocusedItem.Index;

                    listView1.Items.RemoveAt(index);

                    MessageBox.Show("삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("선택된 항목이 없습니다.");
                }
            }
        }

        // 삭제한 테이터가 들어간 동적배열 리스트
        private List<ListViewItem> deletedItems = new List<ListViewItem>();


        // 이름검색기능
        private void 검색_Click(object sender, EventArgs e)
        {
            string 이름 = textBox6.Text;

            foreach (ListViewItem 가게이름 in listView1.Items)
            {

                if (!가게이름.Text.Contains(이름))
                {
                    listView1.Items.Remove(가게이름);
                    deletedItems.Add(가게이름);
                }

            }
            string 음식종류 = textBox7.Text;

            foreach (ListViewItem 종류 in listView1.Items)
            {

                if (!종류.SubItems[3].Text.Contains(음식종류))
                {
                    listView1.Items.Remove(종류);
                    deletedItems.Add(종류);
                }
            }
        }

        private void 되돌리_Click(object sender, EventArgs e)
        {
            foreach (var item in deletedItems)
            {
                listView1.Items.Add(item); // 삭제된 항목을 다시 ListView에 추가
            }
            deletedItems.Clear(); // 삭제된 항목을 삭제합니다.
        }
    }
    }

// 브랜치 이름 추가 테스트 입니다 
