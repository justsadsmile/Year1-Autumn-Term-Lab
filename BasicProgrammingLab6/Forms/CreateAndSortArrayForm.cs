using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicProgrammingLab6
{
    public partial class CreateAndSortArrayForm : Form
    {
        private ArrayProcessor arrayProcessor;
        private const int DEFAULT_ARRAY_SIZE = 10;

        public CreateAndSortArrayForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            arrayProcessor = new ArrayProcessor(DEFAULT_ARRAY_SIZE);
            arrayProcessor.FillRandom();
            UpdateDataGridView();
            UpdateResults();
        }

        private void InitializeDataGridView()
        {
            // Configure DataGridView
            dataGridViewArray.AutoGenerateColumns = false;
            dataGridViewArray.AllowUserToAddRows = false;
            dataGridViewArray.AllowUserToDeleteRows = false;
            dataGridViewArray.RowHeadersVisible = false;

            // Add column for index
            DataGridViewTextBoxColumn indexColumn = new DataGridViewTextBoxColumn();
            indexColumn.Name = "Index";
            indexColumn.HeaderText = "Index";
            indexColumn.ReadOnly = true;
            indexColumn.Width = 50;
            dataGridViewArray.Columns.Add(indexColumn);

            // Add column for value
            DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.Name = "Value";
            valueColumn.HeaderText = "Value";
            valueColumn.ReadOnly = false;
            valueColumn.Width = 100;
            dataGridViewArray.Columns.Add(valueColumn);
        }

        private void UpdateDataGridView()
        {
            // Clear existing rows
            dataGridViewArray.Rows.Clear();

            // Add rows for each array element
            for (int i = 0; i < arrayProcessor.Array.Length; i++)
            {
                dataGridViewArray.Rows.Add(i, arrayProcessor.Array[i]);
            }

            ClearHighlights();
        }

        private void ClearHighlights()
        {
            foreach (DataGridViewRow row in dataGridViewArray.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void HighlightMinMaxValues()
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            ClearHighlights();

            int minValue = arrayProcessor.FindMin();
            int maxValue = arrayProcessor.FindMax();

            foreach (DataGridViewRow row in dataGridViewArray.Rows)
            {
                if (row.Cells["Value"].Value != null)
                {
                    int cellValue = Convert.ToInt32(row.Cells["Value"].Value);

                    if (cellValue == minValue)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                        row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                    else if (cellValue == maxValue)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }

        private void UpdateResults()
        {
            if (arrayProcessor.Array.Length == 0)
            {
                labelMaxValue.Text = "Max: N/A";
                labelMinValue.Text = "Min: N/A";
                labelAverageValue.Text = "Average: N/A";
                return;
            }

            labelMaxValue.Text = $"Max: {arrayProcessor.FindMax()}";
            labelMinValue.Text = $"Min: {arrayProcessor.FindMin()}";
            labelAverageValue.Text = $"Average: {arrayProcessor.CalculateAverage():F2}";
        }

        private void CreateAndSortArrayForm_Load(object sender, EventArgs e)
        {
            textBoxArraySize.Text = DEFAULT_ARRAY_SIZE.ToString();
        }

        private void buttonCreateArray_Click(object sender, EventArgs e)
        {
            try
            {
                int size = int.Parse(textBoxArraySize.Text);
                if (size <= 0 || size > 100)
                {
                    MessageBox.Show("Array size must be between 1 and 100", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                arrayProcessor = new ArrayProcessor(size);
                UpdateDataGridView();
                UpdateResults();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid integer for array size", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDefaultArray_Click(object sender, EventArgs e)
        {
            arrayProcessor = new ArrayProcessor(DEFAULT_ARRAY_SIZE);
            textBoxArraySize.Text = DEFAULT_ARRAY_SIZE.ToString();
            arrayProcessor.FillRandom();
            UpdateDataGridView();
            UpdateResults();
        }

        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            if (arrayProcessor == null)
                arrayProcessor = new ArrayProcessor(DEFAULT_ARRAY_SIZE);

            arrayProcessor.FillRandom();
            UpdateDataGridView();
            UpdateResults();
        }

        private void buttonSortBubble_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            arrayProcessor.SortBubble();
            UpdateDataGridView();
            UpdateResults();
            HighlightMinMaxValues();
        }

        private void buttonSortShell_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            arrayProcessor.SortShell();
            UpdateDataGridView();
            UpdateResults();
            HighlightMinMaxValues();
        }

        private void buttonFindMax_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            int maxValue = arrayProcessor.FindMax();
            int[] maxIndices = arrayProcessor.FindValueIndices(maxValue);

            MessageBox.Show($"Maximum value: {maxValue}\nFound at indices: {string.Join(", ", maxIndices)}",
                "Maximum Value", MessageBoxButtons.OK, MessageBoxIcon.Information);

            HighlightMinMaxValues();
        }

        private void buttonFindMin_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            int minValue = arrayProcessor.FindMin();
            int[] minIndices = arrayProcessor.FindValueIndices(minValue);

            MessageBox.Show($"Minimum value: {minValue}\nFound at indices: {string.Join(", ", minIndices)}",
                "Minimum Value", MessageBoxButtons.OK, MessageBoxIcon.Information);

            HighlightMinMaxValues();
        }

        private void buttonCalculateAverage_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            double average = arrayProcessor.CalculateAverage();
            MessageBox.Show($"Average value: {average:F2}", "Average",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonHighlightMinMax_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            HighlightMinMaxValues();
            UpdateResults();
        }

        private void dataGridViewArray_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewArray.Columns["Value"].Index)
            {
                try
                {
                    string valueStr = dataGridViewArray.Rows[e.RowIndex].Cells["Value"].Value?.ToString();
                    if (!string.IsNullOrEmpty(valueStr))
                    {
                        int value = int.Parse(valueStr);
                        arrayProcessor.Array[e.RowIndex] = value;
                        UpdateResults();
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid integer", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Restore original value
                    dataGridViewArray.Rows[e.RowIndex].Cells["Value"].Value = arrayProcessor.Array[e.RowIndex];
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            // Set all array values to 0
            for (int i = 0; i < arrayProcessor.Array.Length; i++)
            {
                arrayProcessor.Array[i] = 0;
            }

            UpdateDataGridView();
            UpdateResults();
            ClearHighlights();
        }

        private void buttonCheckSorted_Click(object sender, EventArgs e)
        {
            if (arrayProcessor.Array.Length == 0)
                return;

            bool isSorted = arrayProcessor.IsSorted();
            MessageBox.Show($"Array is {(isSorted ? "" : "not ")}sorted in ascending order",
                "Sort Check", MessageBoxButtons.OK,
                isSorted ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }


    }
}