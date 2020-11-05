using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormAddWord : Form
    {
        private WordList WordList { get; set; }
        private List<Label> labelList = new List<Label>();
        private List<TextBox> textBoxList = new List<TextBox>();

        public FormAddWord(WordList wordList)
        {
            InitializeComponent();
            this.WordList = wordList;
            toolStripStatusLabel.Text = "";
        }

        private void FormAddWordNew_Load(object sender, EventArgs e)
        {
            Height = WordList.Languages.Length * 25 + 110;
            buttonSave.Enabled = false;

            for (int i = 0; i < WordList.Languages.Length; i++)
            {
                Label label = new Label()
                {
                    Text = WordList.Languages[i].ToUpper(),
                    Location = new Point(12, i * 25 + 12),
                };
                labelList.Add(label);
                Controls.Add(label);

                TextBox textbox = new TextBox()
                {
                    Location = new Point(120, i * 25 + 9),
                };
                textbox.TextChanged += new EventHandler(TextBox_TextChanged);
                textbox.Leave += new EventHandler(TextBox_Leave);
                textBoxList.Add(textbox);
                Controls.Add(textbox);
            }
        }

        private void FormAddWordNew_Shown(object sender, EventArgs e)
        {
            textBoxList[0].Focus();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxList.Count; i++)
            {
                if (textBoxList[i].Text == "" ||
                    textBoxList[i].Text == null)
                {
                    buttonSave.Enabled = false;
                    return;
                }
            }
            buttonSave.Enabled = true;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "";
        }

        private bool SaveWord()
        {
            try
            {
                string[] translations = new string[WordList.Languages.Length];
                for (int i = 0; i < textBoxList.Count; i++)
                {
                    translations[i] = textBoxList[i].Text.ToString();
                }
                if (!translations.Contains(""))
                {
                    WordList.Add(translations);
                    WordList.Save();

                    toolStripStatusLabel.Text = $"The word is successfully saved.";

                    for (int i = 0; i < textBoxList.Count; i++)
                    {
                        translations[i] = textBoxList[i].Text.ToString();
                    }
                    for (int i = 0; i < WordList.Languages.Length; i++)
                    {
                        textBoxList[i].Text = null;
                    }
                    buttonSave.Enabled = false;
                    textBoxList[0].Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sorry, the word could not be added: {ex.Message}.", "Error");
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveWord();
        }

        private void FormAddWordNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] translations = new string[WordList.Languages.Length];
            for (int i = 0; i < textBoxList.Count; i++)
            {
                translations[i] = textBoxList[i].Text.ToString();
            }
            if (!translations.Contains("") && !translations.Contains(null) &&
                MessageBox.Show("Do you want to save your added word?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!SaveWord())
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
