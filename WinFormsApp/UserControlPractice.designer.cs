namespace WinFormsApp
{
    partial class UserControlPractice
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
            this.labelTranslationResult = new System.Windows.Forms.Label();
            this.labelScorePercentage = new System.Windows.Forms.Label();
            this.buttonStopPracticing = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.textBoxTranslation = new System.Windows.Forms.TextBox();
            this.labelWordToTranslate = new System.Windows.Forms.Label();
            this.labelPractice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTranslationResult
            // 
            this.labelTranslationResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTranslationResult.AutoSize = true;
            this.labelTranslationResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationResult.Location = new System.Drawing.Point(145, 209);
            this.labelTranslationResult.Name = "labelTranslationResult";
            this.labelTranslationResult.Size = new System.Drawing.Size(30, 17);
            this.labelTranslationResult.TabIndex = 17;
            this.labelTranslationResult.Text = "text";
            this.labelTranslationResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelScorePercentage
            // 
            this.labelScorePercentage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScorePercentage.AutoSize = true;
            this.labelScorePercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScorePercentage.Location = new System.Drawing.Point(114, 289);
            this.labelScorePercentage.Name = "labelScorePercentage";
            this.labelScorePercentage.Size = new System.Drawing.Size(43, 13);
            this.labelScorePercentage.TabIndex = 16;
            this.labelScorePercentage.Text = "% result";
            this.labelScorePercentage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonStopPracticing
            // 
            this.buttonStopPracticing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopPracticing.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonStopPracticing.Location = new System.Drawing.Point(324, 386);
            this.buttonStopPracticing.Name = "buttonStopPracticing";
            this.buttonStopPracticing.Size = new System.Drawing.Size(105, 23);
            this.buttonStopPracticing.TabIndex = 1;
            this.buttonStopPracticing.Text = "Stop practicing";
            this.buttonStopPracticing.UseVisualStyleBackColor = true;
            this.buttonStopPracticing.Click += new System.EventHandler(this.buttonStopPracticing_Click);
            // 
            // labelScore
            // 
            this.labelScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(117, 276);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(37, 13);
            this.labelScore.TabIndex = 14;
            this.labelScore.Text = "Result";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxTranslation
            // 
            this.textBoxTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTranslation.Location = new System.Drawing.Point(180, 165);
            this.textBoxTranslation.Name = "textBoxTranslation";
            this.textBoxTranslation.Size = new System.Drawing.Size(100, 20);
            this.textBoxTranslation.TabIndex = 0;
            this.textBoxTranslation.Leave += new System.EventHandler(this.textBoxTranslation_Leave);
            // 
            // labelWordToTranslate
            // 
            this.labelWordToTranslate.AutoSize = true;
            this.labelWordToTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWordToTranslate.Location = new System.Drawing.Point(102, 126);
            this.labelWordToTranslate.Name = "labelWordToTranslate";
            this.labelWordToTranslate.Size = new System.Drawing.Size(299, 17);
            this.labelWordToTranslate.TabIndex = 12;
            this.labelWordToTranslate.Text = "Translate \'word\' from \'ENGLISH\' to \'SWEDISH\'";
            this.labelWordToTranslate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelPractice
            // 
            this.labelPractice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPractice.AutoSize = true;
            this.labelPractice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPractice.Location = new System.Drawing.Point(173, 60);
            this.labelPractice.Name = "labelPractice";
            this.labelPractice.Size = new System.Drawing.Size(113, 20);
            this.labelPractice.TabIndex = 18;
            this.labelPractice.Text = "Practice time!";
            this.labelPractice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UserControlPractice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.labelPractice);
            this.Controls.Add(this.labelTranslationResult);
            this.Controls.Add(this.labelScorePercentage);
            this.Controls.Add(this.buttonStopPracticing);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.textBoxTranslation);
            this.Controls.Add(this.labelWordToTranslate);
            this.Name = "UserControlPractice";
            this.Size = new System.Drawing.Size(460, 428);
            this.SizeChanged += new System.EventHandler(this.UserControlPractice_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.UserControlPractice_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTranslationResult;
        private System.Windows.Forms.Label labelScorePercentage;
        private System.Windows.Forms.Button buttonStopPracticing;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.TextBox textBoxTranslation;
        private System.Windows.Forms.Label labelWordToTranslate;
        private System.Windows.Forms.Label labelPractice;
    }
}
