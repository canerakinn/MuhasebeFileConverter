namespace MuhasebeFileConverter
{
    partial class IslemDefteri
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
            this.uploadTxtFile = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBoxAfk = new System.Windows.Forms.CheckedListBox();
            this.saveFile = new System.Windows.Forms.Button();
            this.selectFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uploadTxtFile
            // 
            this.uploadTxtFile.Location = new System.Drawing.Point(1015, 55);
            this.uploadTxtFile.Name = "uploadTxtFile";
            this.uploadTxtFile.Size = new System.Drawing.Size(437, 47);
            this.uploadTxtFile.TabIndex = 0;
            this.uploadTxtFile.Text = "Dosya Yükle\r\n ( .txt )";
            this.uploadTxtFile.UseVisualStyleBackColor = true;
            this.uploadTxtFile.Click += new System.EventHandler(this.uploadTxtFile_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(50, 55);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(935, 794);
            this.dataGridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 23);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1011, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "ACENTE/FON KODU (AFK) : ";
            // 
            // checkedListBoxAfk
            // 
            this.checkedListBoxAfk.FormattingEnabled = true;
            this.checkedListBoxAfk.Location = new System.Drawing.Point(1015, 144);
            this.checkedListBoxAfk.Name = "checkedListBoxAfk";
            this.checkedListBoxAfk.Size = new System.Drawing.Size(437, 497);
            this.checkedListBoxAfk.TabIndex = 5;
            this.checkedListBoxAfk.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxAfk_ItemCheck);
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(1222, 686);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(141, 29);
            this.saveFile.TabIndex = 6;
            this.saveFile.Text = "Dosyayı Kaydet";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // selectFormat
            // 
            this.selectFormat.FormattingEnabled = true;
            this.selectFormat.Items.AddRange(new object[] {
            "TXT"});
            this.selectFormat.Location = new System.Drawing.Point(1015, 691);
            this.selectFormat.Name = "selectFormat";
            this.selectFormat.Size = new System.Drawing.Size(147, 24);
            this.selectFormat.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(1011, 656);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Format Seç:";
            // 
            // IslemDefteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 878);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectFormat);
            this.Controls.Add(this.saveFile);
            this.Controls.Add(this.checkedListBoxAfk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.uploadTxtFile);
            this.Name = "IslemDefteri";
            this.Text = "İşlem Defteri(txt)";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadTxtFile;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxAfk;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.ComboBox selectFormat;
        private System.Windows.Forms.Label label3;
    }
}