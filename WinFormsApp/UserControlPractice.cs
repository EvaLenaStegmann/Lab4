using ClassLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class UserControlPractice : UserControl
    {
        public event EventHandler ClickedStopPracticing;
        private double NoOfCorrectTranslations { get; set; }
        private double NoOfAttempts { get; set; }
        private WordList WordList { get; set; }
        private Word Word { get; set; }

        public UserControlPractice()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void UserControlPractice_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                FormMain myParentForm = (FormMain)this.ParentForm;
                WordList = myParentForm.wordList;
                labelTranslationResult.Text = "";
                NoOfCorrectTranslations = 0;
                NoOfAttempts = 0;
                GetWordToPractice();
            }
        }

        private void GetWordToPractice()
        {
            Word = WordList.GetWordToPractice();
            labelWordToTranslate.Text = $"Translate '{Word.Translations[Word.FromLanguage]}' " +
                                        $"from {WordList.Languages[Word.FromLanguage].ToUpper()} " +
                                        $"to {WordList.Languages[Word.ToLanguage].ToUpper()}:";

            labelScore.Text = $"You have {NoOfCorrectTranslations} correct answers out of {NoOfAttempts} attempts.";

            double result = NoOfAttempts > 0 ? (NoOfCorrectTranslations / NoOfAttempts * 100) : 0;
            labelScorePercentage.Text = $"That means {result:0}% correct answers so far...";

            textBoxTranslation.Text = "";
            textBoxTranslation.Focus();
        }

        private void textBoxTranslation_Leave(object sender, EventArgs e)
        {
            if (textBoxTranslation.Text.ToLower() == Word.Translations[Word.ToLanguage])
            {
                NoOfCorrectTranslations++;
                labelTranslationResult.ForeColor = Color.Green;
                labelTranslationResult.Text = "Well done - that's correct!";
            }
            else
            {
                labelTranslationResult.ForeColor = Color.Red;
                labelTranslationResult.Text = $"That wasn't correct unfortunately. " + Environment.NewLine +
                                                $"The answer should have been '{Word.Translations[Word.ToLanguage]}'.";
            }
            NoOfAttempts++;
            GetWordToPractice();
            CenterControls();
        }

        private void buttonStopPracticing_Click(object sender, EventArgs e)
        {
            ClickedStopPracticing?.Invoke(this, null);
        }

        private void CenterControls()
        {
            labelPractice.Location = new Point((Width - labelPractice.Width) / 2, labelPractice.Location.Y);
            labelWordToTranslate.Location = new Point((Width - labelWordToTranslate.Width) / 2, labelWordToTranslate.Location.Y);
            labelScore.Location = new Point((Width - labelScore.Width) / 2, labelScore.Location.Y);
            labelScorePercentage.Location = new Point((Width - labelScorePercentage.Width) / 2, labelScorePercentage.Location.Y);
            labelTranslationResult.Location = new Point((Width - labelTranslationResult.Width) / 2, labelTranslationResult.Location.Y);
            textBoxTranslation.Location = new Point((Width - textBoxTranslation.Width) / 2, textBoxTranslation.Location.Y);
        }

        private void UserControlPractice_SizeChanged(object sender, EventArgs e)
        {
            CenterControls();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                buttonStopPracticing.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
