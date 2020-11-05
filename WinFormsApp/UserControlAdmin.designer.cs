namespace WinFormsApp
{
    partial class UserControlAdmin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNoOfWords = new System.Windows.Forms.Label();
            this.dataGridViewWords = new System.Windows.Forms.DataGridView();
            this.buttonRemoveWord = new System.Windows.Forms.Button();
            this.buttonPractice = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAddWord = new System.Windows.Forms.Button();
            this.buttonNewList = new System.Windows.Forms.Button();
            this.labelNoOfWordsText = new System.Windows.Forms.Label();
            this.labelLists = new System.Windows.Forms.Label();
            this.listBoxLists = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWords)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNoOfWords
            // 
            this.labelNoOfWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoOfWords.AutoSize = true;
            this.labelNoOfWords.Location = new System.Drawing.Point(401, 149);
            this.labelNoOfWords.Name = "labelNoOfWords";
            this.labelNoOfWords.Size = new System.Drawing.Size(28, 13);
            this.labelNoOfWords.TabIndex = 32;
            this.labelNoOfWords.Text = " 123";
            // 
            // dataGridViewWords
            // 
            this.dataGridViewWords.AllowUserToAddRows = false;
            this.dataGridViewWords.AllowUserToDeleteRows = false;
            this.dataGridViewWords.AllowUserToResizeRows = false;
            this.dataGridViewWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWords.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWords.Location = new System.Drawing.Point(22, 165);
            this.dataGridViewWords.MultiSelect = false;
            this.dataGridViewWords.Name = "dataGridViewWords";
            this.dataGridViewWords.ReadOnly = true;
            this.dataGridViewWords.RowHeadersVisible = false;
            this.dataGridViewWords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWords.Size = new System.Drawing.Size(407, 207);
            this.dataGridViewWords.TabIndex = 3;
            this.dataGridViewWords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWords_CellClick);
            this.dataGridViewWords.SelectionChanged += new System.EventHandler(this.dataGridViewWords_SelectionChanged);
            this.dataGridViewWords.Sorted += new System.EventHandler(this.dataGridViewWords_Sorted);
            // 
            // buttonRemoveWord
            // 
            this.buttonRemoveWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveWord.Enabled = false;
            this.buttonRemoveWord.Location = new System.Drawing.Point(103, 386);
            this.buttonRemoveWord.Name = "buttonRemoveWord";
            this.buttonRemoveWord.Size = new System.Drawing.Size(104, 23);
            this.buttonRemoveWord.TabIndex = 5;
            this.buttonRemoveWord.Text = "Remove word";
            this.buttonRemoveWord.UseVisualStyleBackColor = true;
            this.buttonRemoveWord.Click += new System.EventHandler(this.buttonRemoveWord_Click);
            // 
            // buttonPractice
            // 
            this.buttonPractice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPractice.Enabled = false;
            this.buttonPractice.Location = new System.Drawing.Point(354, 62);
            this.buttonPractice.Name = "buttonPractice";
            this.buttonPractice.Size = new System.Drawing.Size(75, 23);
            this.buttonPractice.TabIndex = 2;
            this.buttonPractice.Text = "Practice";
            this.buttonPractice.UseVisualStyleBackColor = true;
            this.buttonPractice.Click += new System.EventHandler(this.buttonPractice_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(354, 386);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonAddWord
            // 
            this.buttonAddWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddWord.Enabled = false;
            this.buttonAddWord.Location = new System.Drawing.Point(22, 386);
            this.buttonAddWord.Name = "buttonAddWord";
            this.buttonAddWord.Size = new System.Drawing.Size(75, 23);
            this.buttonAddWord.TabIndex = 4;
            this.buttonAddWord.Text = "Add word";
            this.buttonAddWord.UseVisualStyleBackColor = true;
            this.buttonAddWord.Click += new System.EventHandler(this.buttonAddWord_Click);
            // 
            // buttonNewList
            // 
            this.buttonNewList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewList.Location = new System.Drawing.Point(354, 33);
            this.buttonNewList.Name = "buttonNewList";
            this.buttonNewList.Size = new System.Drawing.Size(75, 23);
            this.buttonNewList.TabIndex = 1;
            this.buttonNewList.Text = "New list";
            this.buttonNewList.UseVisualStyleBackColor = true;
            this.buttonNewList.Click += new System.EventHandler(this.buttonNewList_Click);
            // 
            // labelNoOfWordsText
            // 
            this.labelNoOfWordsText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoOfWordsText.AutoSize = true;
            this.labelNoOfWordsText.Location = new System.Drawing.Point(324, 149);
            this.labelNoOfWordsText.Name = "labelNoOfWordsText";
            this.labelNoOfWordsText.Size = new System.Drawing.Size(67, 13);
            this.labelNoOfWordsText.TabIndex = 25;
            this.labelNoOfWordsText.Text = "No of words:";
            // 
            // labelLists
            // 
            this.labelLists.AutoSize = true;
            this.labelLists.Location = new System.Drawing.Point(19, 17);
            this.labelLists.Name = "labelLists";
            this.labelLists.Size = new System.Drawing.Size(61, 13);
            this.labelLists.TabIndex = 24;
            this.labelLists.Text = "Select a list";
            // 
            // listBoxLists
            // 
            this.listBoxLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLists.FormattingEnabled = true;
            this.listBoxLists.Location = new System.Drawing.Point(22, 33);
            this.listBoxLists.Name = "listBoxLists";
            this.listBoxLists.Size = new System.Drawing.Size(317, 108);
            this.listBoxLists.TabIndex = 0;
            this.listBoxLists.SelectedIndexChanged += new System.EventHandler(this.listBoxLists_SelectedIndexChanged);
            // 
            // UserControlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.labelNoOfWords);
            this.Controls.Add(this.dataGridViewWords);
            this.Controls.Add(this.buttonRemoveWord);
            this.Controls.Add(this.buttonPractice);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAddWord);
            this.Controls.Add(this.buttonNewList);
            this.Controls.Add(this.labelNoOfWordsText);
            this.Controls.Add(this.labelLists);
            this.Controls.Add(this.listBoxLists);
            this.Name = "UserControlAdmin";
            this.Size = new System.Drawing.Size(460, 428);
            this.Load += new System.EventHandler(this.UserControlAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNoOfWords;
        private System.Windows.Forms.DataGridView dataGridViewWords;
        private System.Windows.Forms.Button buttonRemoveWord;
        private System.Windows.Forms.Button buttonPractice;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonAddWord;
        private System.Windows.Forms.Button buttonNewList;
        private System.Windows.Forms.Label labelNoOfWordsText;
        private System.Windows.Forms.Label labelLists;
        private System.Windows.Forms.ListBox listBoxLists;
    }
}
