using ClassLibrary;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormNewList : Form
    {
        public string AddedListName { get; private set; }
        private string[] Lists { get; set; }
        private bool NeedSaving { get; set; } = false;

        public FormNewList(string[] lists)
        {
            InitializeComponent();
            Lists = lists;
        }

        private void FormNewList_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (SaveFile())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool SaveFile()
        {
            foreach (string list in Lists)
            {
                if (list.ToUpper() == textBoxListName.Text.ToUpper())
                {
                    MessageBox.Show($"You already have a list called '{list}'. Try another name.", "Error");
                    return false;
                }
            }

            try
            {
                var languages = textBoxLanguages.Text.ToLower().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var wordList = new WordList(textBoxListName.Text, languages);
                wordList.Save();
                AddedListName = textBoxListName.Text;
                NeedSaving = false;
            }
            catch (Exception ex)
            {
                if (ex is InvalidDataException || ex is ArgumentException)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                else
                {
                    MessageBox.Show($"Couldn't create the list '{textBoxListName.Text}': {ex.Message}", "Error");
                }
                return false;
            }
            return true;
        }

        private void textBoxListName_TextChanged(object sender, EventArgs e)
        {
            var languages = textBoxLanguages.Text.ToLower().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (textBoxListName.Text == "" || languages.Length < 2)
            {
                buttonSave.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
            }
            NeedSaving = buttonSave.Enabled;
        }

        private void textBoxLanguages_TextChanged(object sender, EventArgs e)
        {
            var languages = textBoxLanguages.Text.ToLower().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (textBoxListName.Text == "" || languages.Length < 2)
            {
                buttonSave.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
            }
            NeedSaving = buttonSave.Enabled;
        }

        private void FormNewList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NeedSaving)
            {
                if (MessageBox.Show("Do you want to save your new list?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!SaveFile())
                    {
                        e.Cancel = true;
                    }
                }
            }

        }
    }
}
