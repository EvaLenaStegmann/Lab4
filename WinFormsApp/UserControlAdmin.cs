using ClassLibrary;
using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class UserControlAdmin : UserControl
    {
        public event EventHandler ClickedPractice;
        public event EventHandler ClickedExit;
        public WordList WordList { get; private set; }
        private string[] Lists { get; set; }

        public UserControlAdmin()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void UserControlAdmin_Load(object sender, EventArgs e)
        {
            GetLists();
        }

        private void GetLists()
        {
            try
            {
                Lists = WordList.GetLists();
                listBoxLists.Items.Clear();

                if (Lists.Length > 0)
                {
                    foreach (string list in Lists)
                    {
                        listBoxLists.Items.Add(list);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not get lists: {ex.Message}.", "Error");
            }
        }

        private void listBoxLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAddWord.Enabled = false;
            buttonPractice.Enabled = false;
            buttonRemoveWord.Enabled = false;
            dataGridViewWords.Columns.Clear();
            dataGridViewWords.Rows.Clear();
            dataGridViewWords.ClearSelection();
            labelNoOfWords.Text = "";

            try
            {
                WordList = WordList.LoadList(listBoxLists.SelectedItem.ToString());

                if (WordList.Languages.Length < 4)
                {
                    dataGridViewWords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    dataGridViewWords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                }

                foreach (string language in WordList.Languages)
                {
                    dataGridViewWords.Columns.Add(language, language.ToUpper());
                }
                ShowAllWords();

                buttonAddWord.Enabled = true;
                if (WordList.Count() > 0)
                {
                    buttonPractice.Enabled = true;
                }
                listBoxLists.Focus();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"The list '{listBoxLists.SelectedItem}' wasn't found.", "Error");
            }
            catch (Exception ex)
            {
                if (ex is FileLoadException || ex is InvalidDataException)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                else
                {
                    MessageBox.Show($"Could not read '{listBoxLists.SelectedItem}': {ex.Message}.", "Error");
                }
            }
        }

        private void buttonNewList_Click(object sender, EventArgs e)
        {
            using (FormNewList formNewList = new FormNewList(Lists))
            {
                formNewList.ShowDialog();
                if (formNewList.DialogResult == DialogResult.OK)
                {
                    try
                    {
                        GetLists();
                        listBoxLists.SetSelected(listBoxLists.FindString(formNewList.AddedListName), true);
                        buttonAddWord.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not get lists': {ex.Message}.", "Error");
                    }
                }
            };
        }

        private void buttonAddWord_Click(object sender, EventArgs e)
        {
            using (FormAddWord formAddWord = new FormAddWord(WordList))
            {
                formAddWord.ShowDialog();
                try
                {
                    ShowAllWords();
                    if (WordList.Count() > 0)
                    {
                        buttonPractice.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not show words: {ex.Message}.", "Error");
                }
            }
        }

        private void ShowAllWords()
        {
            dataGridViewWords.Rows.Clear();
            WordList.List(0, translations => dataGridViewWords.Rows.Add(translations));
            labelNoOfWords.Text = WordList.Count().ToString();
            dataGridViewWords.ClearSelection();
        }

        private void buttonRemoveWord_Click(object sender, EventArgs e)
        {
            try
            {
                WordList.Remove(0, dataGridViewWords.SelectedRows[0].Cells[WordList.Languages[0]].Value.ToString());
                WordList.Save();
                ShowAllWords();
                if (WordList.Count() == 0)
                {
                    buttonPractice.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not remove word: {ex.Message}.", "Error");
            }
        }

        private void dataGridViewWords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonRemoveWord.Enabled = true;
        }

        private void dataGridViewWords_Sorted(object sender, EventArgs e)
        {
            dataGridViewWords.ClearSelection();
        }

        private void dataGridViewWords_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewWords.SelectedRows.Count == 0)
            {
                buttonRemoveWord.Enabled = false;
            }
        }

        private void buttonPractice_Click(object sender, EventArgs e)
        {
            ClickedPractice?.Invoke(this, null);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            ClickedExit?.Invoke(this, null);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                buttonExit.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
