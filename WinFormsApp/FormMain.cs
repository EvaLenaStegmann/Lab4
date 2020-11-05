using ClassLibrary;
using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FormMain : Form
    {
        public WordList wordList { get; private set; }
        private UserControlAdmin ucAdmin { get; set; }
        private UserControlPractice ucPractice { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            ucAdmin = new UserControlAdmin()
            {
                Visible = true
            };
            ucAdmin.ClickedPractice += SwitchUserControl;
            ucAdmin.ClickedExit += CloseForm;
            panelMain.Controls.Add(ucAdmin);

            ucPractice = new UserControlPractice()
            {
                Visible = false
            };
            ucPractice.ClickedStopPracticing += SwitchUserControl;
            panelMain.Controls.Add(ucPractice);
        }

        private void SwitchUserControl(object sender, EventArgs e)
        {
            if (ucAdmin.Visible)
            {
                wordList = ucAdmin.WordList;
                ucAdmin.Visible = false;
                ucPractice.Visible = true;
            }
            else
            {
                ucAdmin.Visible = true;
                ucPractice.Visible = false;
            }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            Close();
        }

        private void aboutMyDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAbout formAbout = new FormAbout())
            {
                formAbout.ShowDialog();
            }
        }
    }
}
