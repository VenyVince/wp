using System;
using System.Collections;
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
        // 입력한 정보들을 저장할 백업 리스트 생성 /     -   -   -   -   -   -   -   -   -   -   -   -   -   -(11.15)음식 종류 - 오금빈
        private List<ListViewItem> allItems = new List<ListViewItem>();

        private Boolean m_blLoginCheck = false;

        public Form1()
        {
            InitializeComponent();
        }

        public Boolean LoginCheck
        {
            get { return m_blLoginCheck; }
            set { m_blLoginCheck = value; }
        }

=======
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

                // 백업 리스트에도 정보 저장 /     -   -   -   -   -   -   -   -   -   -   -   -   (11.15) 음식 종류 - 오금빈
                allItems.Add((ListViewItem)item.Clone());


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

        private Stack<ListViewItem> deletedStack = new Stack<ListViewItem>();


        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목이 삭제됩니다.\r계속 하시겠습니다?", "항목 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    int index = listView1.FocusedItem.Index;

                    ListViewItem deletedItem = listView1.Items[index].Clone() as ListViewItem;// 
                    deletedStack.Push(deletedItem); // 삭제한 항목 스텍에 푸쉬 // 수정자 - 박정호

                    listView1.Items.RemoveAt(index);

                    MessageBox.Show("삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("선택된 항목이 없습니다.");
                }
            }
        }

        // 검색시 - 삭제한 테이터가 들어간 동적배열 리스트
        private List<ListViewItem> deletedItems = new List<ListViewItem>();

        // 이름검색기능
        private void 검색_Click(object sender, EventArgs e)
        {
            string 이름 = textBox6.Text;

            foreach (ListViewItem 가게이름 in listView1.Items)
            {
                ListViewItem.ListViewSubItemCollection subItem = 가게이름.SubItems; // 리스트뷰 가게이름 가져오기

                if (subItem[0].Text == 이름)
                {
                    if (MessageBox.Show("가게이름\t전화번호\t주소\t종류\t메모\n" +
                        subItem[0].Text + "\t" + subItem[1].Text + "\t" + subItem[2].Text + "\t" + subItem[3].Text + "\t" + subItem[4].Text + "\n" +
                        "네이버에 검색하시겠습니까?",
                        subItem[0].Text + " 검색 결과", MessageBoxButtons.YesNo) == DialogResult.Yes) // 메세지박스 YES == 네이버에 해당 가게이름 검색
                    {
                        Process.Start("https://map.naver.com/p/search/" + subItem[0].Text);
                    }
                }
                else
                {
                    if(MessageBox.Show("검색 결과가 없습니다.", "오류")==DialogResult.OK)
                        textBox6.Focus();
                }
            }

            foreach (ListViewItem 가게이름 in listView1.Items)
            {
                
                if (!가게이름.Text.Contains(이름))
                {
                    listView1.Items.Remove(가게이름);
                    deletedItems.Add(가게이름);
                }

            }
            /* 삭제해도 문제 없는 부분 -  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -(11,15) 오금빈
            string 음식종류 = textBox7.Text;

            foreach (ListViewItem 종류 in listView1.Items)
            {

                if (!종류.SubItems[3].Text.Contains(음식종류))
                {
                    listView1.Items.Remove(종류);
                    deletedItems.Add(종류);
                }
            } */
        }

        private void 되돌리_Click(object sender, EventArgs e)
        {
            foreach (var item in deletedItems)
            {
                listView1.Items.Add(item); // 삭제된 항목을 다시 ListView에 추가
            }
            deletedItems.Clear(); // 삭제된 항목을 삭제합니다.
        }


        private void listView1_DoubleClick(object sender, EventArgs e) // 하이퍼링크 실험중(가게이름 더블클릭)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = item.SubItems; // 리스트뷰 가게이름 가져오기

                // 메세지박스 YES == 네이버에 해당 가게이름 검색
                if (MessageBox.Show("'" + subItem[0].Text + "'" + " 네이버에 검색", subItem[0].Text + " 링크", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("https://map.naver.com/p/search/" + subItem[0].Text);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Form2 _Form = new Form2(this);
            _Form.ShowDialog();

            if (!m_blLoginCheck) this.Close();
            this.KeyPreview = true; // KeyPreview 속성을 true로 설정하여 폼에서 키 이벤트를 처리할 수 있도록 함
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // KeyDown 이벤트 핸들러 등록
        }

        // Ctrl + z 눌러을 때 - 스택에서 푸쉬되었던 데이터가 하나씩 팝하여 되돌리기가 된다.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z && e.Handled == false)
            {
                e.Handled = true; // 키 이벤트 처리 완료

                if (deletedStack.Count > 0)
                {
                    ListViewItem popedItem = deletedStack.Pop();
                    listView1.Items.Add(popedItem);

                }
                else
                {
                    MessageBox.Show("더 이상 삭제한 항목이 없습니다.");
                }
            }

        

        }


        // 리스트뷰 컬럼 정렬 기능     -  -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -    (11.15) - 오금빈
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView1.Sorting == SortOrder.Ascending)//오름차순 정렬
                listView1.Sorting = SortOrder.Descending;//내림차순 정렬
            else
                listView1.Sorting = SortOrder.Ascending;

            listView1.ListViewItemSorter = new ListViewItemComparer(e.Column, listView1.Sorting);
        }

        //비교 정렬을 위한  IComparer 인터페이스
        public class ListViewItemComparer : IComparer
        {
            private int col; // 컬럼 정보
            private SortOrder order; // (오름,내림)차순 정렬 결정 값 

            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                if (order == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
        }

        // 음식 종류별 정렬    -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   -   (11.15) - 오금빈
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string selected = comboBox1.SelectedItem.ToString();

            if (selected != "음식 종류")
            {
                foreach (ListViewItem item in allItems)
                {
                    if (item.SubItems[3].Text == selected)
                    {
                        listView1.Items.Add((ListViewItem)item.Clone());
                    }
                }
            }
            else // '음식 종류'를 선택한 경우
            {
                foreach (ListViewItem item in allItems)
                {
                    listView1.Items.Add((ListViewItem)item.Clone());
                }
            }
        }

    }
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

