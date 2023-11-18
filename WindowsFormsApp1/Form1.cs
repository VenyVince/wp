using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

            // FormClosing 이벤트 핸들러를 등록합니다.
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
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
            // 메세지박스 확인후 키보드 포커스 설정
            else if (textBox1.Text == "")
            {
                if (MessageBox.Show("가게 이름을 입력해 주세요.", "error") == DialogResult.OK)
                    textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                if (MessageBox.Show("전화번호를 입력해 주세요.", "error") == DialogResult.OK)
                    textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                if (MessageBox.Show("주소를 입력해 주세요.", "error") == DialogResult.OK)
                    textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                if (MessageBox.Show("음식 종류를 입력해 주세요.", "error") == DialogResult.OK)
                    textBox4.Focus();
            }

        }
        private void SaveFormFile()
        {
            string sourceFilePath = @"C:\path\to\your\Form1.cs"; // 실제 Form1.cs 파일 경로로 대체해주세요
            string destinationFilePath = @"C:\준이\Form1_copy.cs"; // Form1.cs를 저장할 목적지 경로

            try
            {
                // Form1.cs 파일의 내용을 읽어옵니다.
                string fileContent = File.ReadAllText(sourceFilePath);

                // 다른 위치에 파일 내용을 저장합니다.
                File.WriteAllText(destinationFilePath, fileContent);

                MessageBox.Show("Form 파일이 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일 저장 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDataToFile()
        {
            string directoryPath = @"C:\준이"; // 원하는 디렉터리 경로
            string fileName = "a.txt"; // 원하는 파일 이름

            // 디렉터리가 존재하지 않으면 생성합니다.
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName); // 경로와 파일 이름을 합쳐 전체 파일 경로 생성

            StringBuilder contentToSave = new StringBuilder();

            foreach (ListViewItem item in listView1.Items)
            {
                contentToSave.AppendLine("가게 이름: " + item.SubItems[0].Text);
                contentToSave.AppendLine("전화번호: " + item.SubItems[1].Text);
                contentToSave.AppendLine("주소: " + item.SubItems[2].Text);
                contentToSave.AppendLine("음식 종류: " + item.SubItems[3].Text);
                contentToSave.AppendLine("메모: " + item.SubItems[4].Text);
                contentToSave.AppendLine();
            }

            try
            {
                File.WriteAllText(filePath, contentToSave.ToString());
                MessageBox.Show("파일이 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일 저장 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveToFile()
        {
            OpenFileDialog saveFileDialog = new OpenFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                string filePath = saveFileDialog.FileName;

                StringBuilder contentToSave = new StringBuilder();

                foreach (ListViewItem item in listView1.Items)
                {
                    contentToSave.AppendLine("가게 이름: " + item.SubItems[0].Text);
                    contentToSave.AppendLine("전화번호: " + item.SubItems[1].Text);
                    contentToSave.AppendLine("주소: " + item.SubItems[2].Text);
                    contentToSave.AppendLine("음식 종류: " + item.SubItems[3].Text);
                    contentToSave.AppendLine("메모: " + item.SubItems[4].Text);
                    contentToSave.AppendLine();
                }

                try
                {
                    File.WriteAllText(filePath, contentToSave.ToString());
                    MessageBox.Show("텍스트 파일에 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("파일 저장 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해 주세요.");
                return;
            }

            ListViewItem selectedItem = listView1.SelectedItems[0];
            selectedItem.SubItems[0].Text = textBox1.Text;
            selectedItem.SubItems[1].Text = textBox2.Text;
            selectedItem.SubItems[2].Text = textBox3.Text;
            selectedItem.SubItems[3].Text = textBox4.Text;
            selectedItem.SubItems[4].Text = textBox5.Text;

            // 입력 필드를 지웁니다
            ClearTextBoxes();

            MessageBox.Show("정보가 변경되었습니다.");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                textBox1.Text = selectedItem.SubItems[0].Text;
                textBox2.Text = selectedItem.SubItems[1].Text;
                textBox3.Text = selectedItem.SubItems[2].Text;
                textBox4.Text = selectedItem.SubItems[3].Text;
                textBox5.Text = selectedItem.SubItems[4].Text;
            }
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            // 여기에 더블클릭 이벤트가 발생했을 때 수행할 작업을 추가합니다.
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    SaveDataToFile(); // Call the method to save data to the file
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}