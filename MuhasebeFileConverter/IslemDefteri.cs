using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MuhasebeFileConverter
{
    public partial class IslemDefteri : Form
    {
        private DataTable dataTable;

        private string[] headersEnglish;
        public IslemDefteri()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        private void uploadTxtFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string klasorYolu = folderBrowserDialog.SelectedPath;

                // OpenFileDialog ile dosya seçme işlemi
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                openFileDialog.Title = "Dosya Seç";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dosyaYolu = Path.Combine(klasorYolu, openFileDialog.SafeFileName);

                    dataTable.Clear();

                    string[] headersTurkish = File.ReadLines(dosyaYolu).First().Split(';');
                    foreach (string header in headersTurkish)
                    {
                        dataTable.Columns.Add(header, typeof(string));
                    }

                    headersEnglish = File.ReadLines(dosyaYolu).Skip(1).First().Split(';');
                    DataRow englishHeadersRow = dataTable.NewRow();
                    for (int i = 0; i < headersTurkish.Length; i++)
                    {
                        englishHeadersRow[i] = headersEnglish[i];
                    }

                    foreach (string line in File.ReadLines(dosyaYolu).Skip(2))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] rowValues = line.Split(';');

                            // Satırı DataTable'a ekle
                            dataTable.Rows.Add(rowValues);
                        }
                        else
                        {
                            DataRow emptyRow = dataTable.NewRow();
                            dataTable.Rows.Add(emptyRow);
                        }
                    }

                    int expectedColumnCount = headersTurkish.Length;

                    foreach (string line in File.ReadLines(dosyaYolu).Skip(2))
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] rowValues = line.Split(';');

                            int acigaSatisIndex = Array.FindIndex(headersTurkish, header => header == "ACIGA SATIS ISARETI");
                            if (acigaSatisIndex != -1)
                            {
                                rowValues[acigaSatisIndex] = (rowValues[acigaSatisIndex]);
                            }

                            int actualColumnCount = rowValues.Length;

                            if (actualColumnCount != expectedColumnCount)
                            {
                                MessageBox.Show($"Satır sütun sayısı, DataTable sütun sayısından farklı. Satır: {line}\nBeklenen Sütun Sayısı: {expectedColumnCount}, Gerçek Sütun Sayısı: {actualColumnCount}");
                            }

                            dataTable.Rows.Add(rowValues);
                        }
                        else
                        {
                            DataRow emptyRow = dataTable.NewRow();
                            dataTable.Rows.Add(emptyRow);
                        }
                    }


                    // DataGridView'a DataTable'ı ata
                    dataGridView.DataSource = dataTable;
                    CorrectData();
                    LoadAfkCodesToCheckedListBox();
                }
            }
        }
        private void CorrectData()
        {
            DataTable correctedDataTable = new DataTable();

            foreach (DataColumn column in dataTable.Columns)
            {
                correctedDataTable.Columns.Add(column.ColumnName, column.DataType);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow correctedRow = correctedDataTable.NewRow();

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    string columnName = dataTable.Columns[i].ColumnName;
                    string originalValue = row[i].ToString();


                    if (columnName == "ISLEM KODU")
                    {
                        originalValue = originalValue.Replace(".E.", ".E");
                    }

                    if (columnName == "TAKAS TARIHI")
                    {
                        originalValue = originalValue.Replace("; ;", ";;");
                    }

                    correctedRow[i] = originalValue;
                }

                correctedDataTable.Rows.Add(correctedRow);
            }

            dataGridView.DataSource = correctedDataTable;
        }
        private void LoadAfkCodesToCheckedListBox()
        {
            try
            {
                DataColumn afkColumn = dataTable.Columns["ACENTE/FON KODU (AFK)"];

                checkedListBoxAfk.Items.Clear();

                checkedListBoxAfk.Items.Add("Tümünü Göster");

                HashSet<string> uniqueValues = new HashSet<string>();
                foreach (DataRow row in dataTable.Rows.Cast<DataRow>().Skip(1))
                {
                    object value = row[afkColumn];
                    if (value != DBNull.Value)
                    {
                        uniqueValues.Add(value.ToString());
                    }
                }

                


                foreach (string uniqueValue in uniqueValues)
                {
                    checkedListBoxAfk.Items.Add(uniqueValue);
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }
        private void checkedListBoxAfk_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            List<string> selectedValues = new List<string>();
            foreach (var item in checkedListBoxAfk.CheckedItems)
            {
                selectedValues.Add(item.ToString());
            }


            if (e.NewValue == CheckState.Checked)
            {
                string newItem = checkedListBoxAfk.Items[e.Index].ToString();
                if (!selectedValues.Contains(newItem))
                {
                    selectedValues.Add(newItem);
                }
            }
            else
            {
                string removedItem = checkedListBoxAfk.Items[e.Index].ToString();
                selectedValues.Remove(removedItem);
            }

            UpdateDataTable(selectedValues);
        }

        private void UpdateDataTable(List<string> selectedValues)
        {
            if (selectedValues.Count == 0 || (selectedValues.Count == 1 && selectedValues[0] == "Tümünü Göster"))
            {
                dataGridView.DataSource = dataTable;
            }
            else
            {
                DataView dv = new DataView(dataTable);
                StringBuilder filterExpression = new StringBuilder();
                foreach (string value in selectedValues)
                {
                    if (filterExpression.Length > 0)
                    {
                        filterExpression.Append(" OR ");
                    }
                    filterExpression.Append($"[ACENTE/FON KODU (AFK)] = '{value.Replace("'", "''")}'");
                }
                dv.RowFilter = filterExpression.ToString();
                dataGridView.DataSource = dv.ToTable();
            }
        }
        private void saveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = GetFileFilter();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                switch (selectFormat.SelectedItem.ToString())
                {
                    case "TXT":
                        SaveAsTxt(filePath);
                        break;
                }

                MessageBox.Show("Dosya başarıyla kaydedildi.");
            }
        }

        private string GetFileFilter()
        {
            string selectedFormat = selectFormat.SelectedItem.ToString();

            switch (selectedFormat)
            {
                case "TXT":
                    return "Metin Dosyaları (*.txt)|*.txt";
                default:
                    return "Tüm Dosyalar (*.*)|*.*";
            }
        }

        private void SaveAsTxt(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Başlıkları yaz
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    writer.Write(dataTable.Columns[i].ColumnName);
                    if (i < dataTable.Columns.Count - 1)
                    {
                        writer.Write(";");
                    }
                }
                
                writer.WriteLine();
                for (int i = 0; i < headersEnglish.Length; i++)
                {
                    writer.Write(headersEnglish[i]);
                    if (i < headersEnglish.Length - 1)
                    {
                        writer.Write(";");
                    }
                }
                writer.WriteLine();  // Add a newline character after each line





                writer.WriteLine(); 

                foreach (DataGridViewRow dgvRow in dataGridView.Rows)
                {
                    DataRowView rowView = dgvRow.DataBoundItem as DataRowView;
                    if (rowView != null)
                    {
                        DataRow row = rowView.Row;

                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            writer.Write(row[i].ToString());
                            if (i < dataTable.Columns.Count - 1)
                            {
                                writer.Write(";");
                            }
                        }

                        writer.WriteLine(); 
                    }
                }
            }
        }
    }
}