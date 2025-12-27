namespace BasicProgrammingLab6
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label titleLabel;

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
            titleLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(220, 37);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(221, 36);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Winform Menu";
            // 
            // button1
            // 
            button1.BackColor = Color.Teal;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.White;
            button1.Location = new Point(192, 103);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(267, 77);
            button1.TabIndex = 1;
            button1.Text = "Math Game";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Teal;
            button2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.ForeColor = Color.White;
            button2.Location = new Point(192, 190);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(267, 77);
            button2.TabIndex = 2;
            button2.Text = "Author";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Teal;
            button3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.ForeColor = Color.White;
            button3.Location = new Point(192, 277);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(267, 77);
            button3.TabIndex = 3;
            button3.Text = "Array";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Teal;
            button4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.ForeColor = Color.White;
            button4.Location = new Point(192, 364);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(267, 77);
            button4.TabIndex = 4;
            button4.Text = "Connect Four";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(650, 500);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(titleLabel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainMenuForm";
            Text = "Главное меню";
            Load += MainMenuForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}