namespace TravelingSalesman
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.pictureBoxPath = new System.Windows.Forms.PictureBox();
            this.textBoxNodeCount = new System.Windows.Forms.TextBox();
            this.labelProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPath)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgorithm.Items.AddRange(new object[] {
            "One by one (default)"});
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(12, 528);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(320, 21);
            this.comboBoxAlgorithm.TabIndex = 0;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(590, 528);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(182, 21);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "Run";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // pictureBoxPath
            // 
            this.pictureBoxPath.BackColor = System.Drawing.Color.White;
            this.pictureBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPath.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxPath.Name = "pictureBoxPath";
            this.pictureBoxPath.Size = new System.Drawing.Size(760, 510);
            this.pictureBoxPath.TabIndex = 2;
            this.pictureBoxPath.TabStop = false;
            // 
            // textBoxNodeCount
            // 
            this.textBoxNodeCount.Location = new System.Drawing.Point(338, 528);
            this.textBoxNodeCount.Name = "textBoxNodeCount";
            this.textBoxNodeCount.Size = new System.Drawing.Size(80, 20);
            this.textBoxNodeCount.TabIndex = 3;
            this.textBoxNodeCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNodeCount.TextChanged += new System.EventHandler(this.textBoxNodeCount_TextChanged);
            // 
            // labelProgress
            // 
            this.labelProgress.Location = new System.Drawing.Point(424, 528);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(160, 20);
            this.labelProgress.TabIndex = 4;
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.textBoxNodeCount);
            this.Controls.Add(this.pictureBoxPath);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.comboBoxAlgorithm);
            this.Name = "FormMain";
            this.Text = "Traveling Salesman";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.PictureBox pictureBoxPath;
        private System.Windows.Forms.TextBox textBoxNodeCount;
        private System.Windows.Forms.Label labelProgress;
    }
}

