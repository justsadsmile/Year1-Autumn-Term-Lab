namespace BasicProgrammingLab6
{
    partial class CreateAndSortArrayForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            buttonCheckSorted = new Button();
            buttonClear = new Button();
            labelArraySize = new Label();
            textBoxArraySize = new TextBox();
            buttonCreateArray = new Button();
            buttonDefaultArray = new Button();
            buttonGenerateRandom = new Button();
            dataGridViewArray = new DataGridView();
            panel2 = new Panel();
            buttonSortBubble = new Button();
            buttonSortShell = new Button();
            buttonFindMax = new Button();
            buttonFindMin = new Button();
            buttonCalculateAverage = new Button();
            buttonHighlightMinMax = new Button();
            panel3 = new Panel();
            labelResults = new Label();
            labelMaxValue = new Label();
            labelMinValue = new Label();
            labelAverageValue = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArray).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(buttonCheckSorted);
            panel1.Controls.Add(buttonClear);
            panel1.Controls.Add(labelArraySize);
            panel1.Controls.Add(textBoxArraySize);
            panel1.Controls.Add(buttonCreateArray);
            panel1.Controls.Add(buttonDefaultArray);
            panel1.Controls.Add(buttonGenerateRandom);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(900, 60);
            panel1.TabIndex = 0;
            // 
            // buttonCheckSorted
            // 
            buttonCheckSorted.Location = new Point(760, 16);
            buttonCheckSorted.Name = "buttonCheckSorted";
            buttonCheckSorted.Size = new Size(130, 30);
            buttonCheckSorted.TabIndex = 6;
            buttonCheckSorted.Text = "Check Sorted";
            buttonCheckSorted.UseVisualStyleBackColor = true;
            buttonCheckSorted.Click += buttonCheckSorted_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(630, 16);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(120, 30);
            buttonClear.TabIndex = 5;
            buttonClear.Text = "Clear Array";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelArraySize
            // 
            labelArraySize.AutoSize = true;
            labelArraySize.Location = new Point(12, 20);
            labelArraySize.Name = "labelArraySize";
            labelArraySize.Size = new Size(78, 20);
            labelArraySize.TabIndex = 0;
            labelArraySize.Text = "Array Size:";
            // 
            // textBoxArraySize
            // 
            textBoxArraySize.Location = new Point(94, 17);
            textBoxArraySize.Name = "textBoxArraySize";
            textBoxArraySize.Size = new Size(80, 27);
            textBoxArraySize.TabIndex = 1;
            // 
            // buttonCreateArray
            // 
            buttonCreateArray.Location = new Point(180, 16);
            buttonCreateArray.Name = "buttonCreateArray";
            buttonCreateArray.Size = new Size(120, 30);
            buttonCreateArray.TabIndex = 2;
            buttonCreateArray.Text = "Create Array";
            buttonCreateArray.UseVisualStyleBackColor = true;
            buttonCreateArray.Click += buttonCreateArray_Click;
            // 
            // buttonDefaultArray
            // 
            buttonDefaultArray.Location = new Point(310, 16);
            buttonDefaultArray.Name = "buttonDefaultArray";
            buttonDefaultArray.Size = new Size(150, 30);
            buttonDefaultArray.TabIndex = 3;
            buttonDefaultArray.Text = "Create Default (10)";
            buttonDefaultArray.UseVisualStyleBackColor = true;
            buttonDefaultArray.Click += buttonDefaultArray_Click;
            // 
            // buttonGenerateRandom
            // 
            buttonGenerateRandom.Location = new Point(470, 16);
            buttonGenerateRandom.Name = "buttonGenerateRandom";
            buttonGenerateRandom.Size = new Size(150, 30);
            buttonGenerateRandom.TabIndex = 4;
            buttonGenerateRandom.Text = "Generate Random";
            buttonGenerateRandom.UseVisualStyleBackColor = true;
            buttonGenerateRandom.Click += buttonGenerateRandom_Click;
            // 
            // dataGridViewArray
            // 
            dataGridViewArray.AllowUserToAddRows = false;
            dataGridViewArray.AllowUserToDeleteRows = false;
            dataGridViewArray.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArray.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewArray.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewArray.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewArray.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArray.Dock = DockStyle.Fill;
            dataGridViewArray.Location = new Point(0, 60);
            dataGridViewArray.Name = "dataGridViewArray";
            dataGridViewArray.RowHeadersWidth = 51;
            dataGridViewArray.Size = new Size(900, 450);
            dataGridViewArray.TabIndex = 1;
            dataGridViewArray.CellEndEdit += dataGridViewArray_CellEndEdit;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(buttonSortBubble);
            panel2.Controls.Add(buttonSortShell);
            panel2.Controls.Add(buttonFindMax);
            panel2.Controls.Add(buttonFindMin);
            panel2.Controls.Add(buttonCalculateAverage);
            panel2.Controls.Add(buttonHighlightMinMax);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 390);
            panel2.Name = "panel2";
            panel2.Size = new Size(900, 120);
            panel2.TabIndex = 2;
            // 
            // buttonSortBubble
            // 
            buttonSortBubble.Location = new Point(12, 20);
            buttonSortBubble.Name = "buttonSortBubble";
            buttonSortBubble.Size = new Size(120, 35);
            buttonSortBubble.TabIndex = 0;
            buttonSortBubble.Text = "Bubble Sort";
            buttonSortBubble.UseVisualStyleBackColor = true;
            buttonSortBubble.Click += buttonSortBubble_Click;
            // 
            // buttonSortShell
            // 
            buttonSortShell.Location = new Point(138, 20);
            buttonSortShell.Name = "buttonSortShell";
            buttonSortShell.Size = new Size(120, 35);
            buttonSortShell.TabIndex = 1;
            buttonSortShell.Text = "Shell Sort";
            buttonSortShell.UseVisualStyleBackColor = true;
            buttonSortShell.Click += buttonSortShell_Click;
            // 
            // buttonFindMax
            // 
            buttonFindMax.Location = new Point(264, 20);
            buttonFindMax.Name = "buttonFindMax";
            buttonFindMax.Size = new Size(120, 35);
            buttonFindMax.TabIndex = 2;
            buttonFindMax.Text = "Find Max";
            buttonFindMax.UseVisualStyleBackColor = true;
            buttonFindMax.Click += buttonFindMax_Click;
            // 
            // buttonFindMin
            // 
            buttonFindMin.Location = new Point(390, 20);
            buttonFindMin.Name = "buttonFindMin";
            buttonFindMin.Size = new Size(120, 35);
            buttonFindMin.TabIndex = 3;
            buttonFindMin.Text = "Find Min";
            buttonFindMin.UseVisualStyleBackColor = true;
            buttonFindMin.Click += buttonFindMin_Click;
            // 
            // buttonCalculateAverage
            // 
            buttonCalculateAverage.Location = new Point(516, 20);
            buttonCalculateAverage.Name = "buttonCalculateAverage";
            buttonCalculateAverage.Size = new Size(140, 35);
            buttonCalculateAverage.TabIndex = 4;
            buttonCalculateAverage.Text = "Calculate Average";
            buttonCalculateAverage.UseVisualStyleBackColor = true;
            buttonCalculateAverage.Click += buttonCalculateAverage_Click;
            // 
            // buttonHighlightMinMax
            // 
            buttonHighlightMinMax.Location = new Point(662, 20);
            buttonHighlightMinMax.Name = "buttonHighlightMinMax";
            buttonHighlightMinMax.Size = new Size(140, 35);
            buttonHighlightMinMax.TabIndex = 5;
            buttonHighlightMinMax.Text = "Highlight Min/Max";
            buttonHighlightMinMax.UseVisualStyleBackColor = true;
            buttonHighlightMinMax.Click += buttonHighlightMinMax_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Info;
            panel3.Controls.Add(labelResults);
            panel3.Controls.Add(labelMaxValue);
            panel3.Controls.Add(labelMinValue);
            panel3.Controls.Add(labelAverageValue);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(700, 60);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 330);
            panel3.TabIndex = 3;
            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            labelResults.Location = new Point(10, 10);
            labelResults.Name = "labelResults";
            labelResults.Size = new Size(66, 23);
            labelResults.TabIndex = 0;
            labelResults.Text = "Results";
            // 
            // labelMaxValue
            // 
            labelMaxValue.AutoSize = true;
            labelMaxValue.Font = new Font("Segoe UI", 9F);
            labelMaxValue.Location = new Point(10, 50);
            labelMaxValue.Name = "labelMaxValue";
            labelMaxValue.Size = new Size(44, 20);
            labelMaxValue.TabIndex = 1;
            labelMaxValue.Text = "Max: ";
            // 
            // labelMinValue
            // 
            labelMinValue.AutoSize = true;
            labelMinValue.Font = new Font("Segoe UI", 9F);
            labelMinValue.Location = new Point(10, 80);
            labelMinValue.Name = "labelMinValue";
            labelMinValue.Size = new Size(41, 20);
            labelMinValue.TabIndex = 2;
            labelMinValue.Text = "Min: ";
            // 
            // labelAverageValue
            // 
            labelAverageValue.AutoSize = true;
            labelAverageValue.Font = new Font("Segoe UI", 9F);
            labelAverageValue.Location = new Point(10, 110);
            labelAverageValue.Name = "labelAverageValue";
            labelAverageValue.Size = new Size(71, 20);
            labelAverageValue.TabIndex = 3;
            labelAverageValue.Text = "Average: ";
            // 
            // CreateAndSortArrayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(900, 510);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(dataGridViewArray);
            Controls.Add(panel1);
            MinimumSize = new Size(700, 550);
            Name = "CreateAndSortArrayForm";
            Text = "One-Dimensional Array Processor";
            Load += CreateAndSortArrayForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArray).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridViewArray;
        private Panel panel2;
        private Label labelArraySize;
        private TextBox textBoxArraySize;
        private Button buttonCreateArray;
        private Button buttonDefaultArray;
        private Button buttonGenerateRandom;
        private Button buttonSortBubble;
        private Button buttonSortShell;
        private Button buttonFindMax;
        private Button buttonFindMin;
        private Button buttonCalculateAverage;
        private Button buttonHighlightMinMax;
        private Button buttonClear;
        private Button buttonCheckSorted;
        private Panel panel3;
        private Label labelResults;
        private Label labelMaxValue;
        private Label labelMinValue;
        private Label labelAverageValue;
    }
}