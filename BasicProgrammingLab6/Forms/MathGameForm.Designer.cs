namespace BasicProgrammingLab6
{
    partial class MathGameForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathGameForm));
            pictureBox1 = new PictureBox();
            labelFormula = new Label();
            labelA = new Label();
            textBoxA = new TextBox();
            labelB = new Label();
            textBoxB = new TextBox();
            labelAttempts = new Label();
            numericUpDownAttempts = new NumericUpDown();
            labelGuess = new Label();
            textBoxGuess = new TextBox();
            buttonCheck = new Button();
            buttonNewGame = new Button();
            labelResult = new Label();
            textBoxResult = new TextBox();
            labelInstructions = new Label();
            labelFunction = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAttempts).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(50, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelFormula
            // 
            labelFormula.AutoSize = true;
            labelFormula.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelFormula.Location = new Point(50, 200);
            labelFormula.Name = "labelFormula";
            labelFormula.Size = new Size(436, 28);
            labelFormula.TabIndex = 1;
            labelFormula.Text = "f(a, b) = (cos⁷(π) + √(ln(b⁴))) / sin((π/2 + a)²)";
            // 
            // labelA
            // 
            labelA.AutoSize = true;
            labelA.Location = new Point(50, 250);
            labelA.Name = "labelA";
            labelA.Size = new Size(91, 20);
            labelA.TabIndex = 2;
            labelA.Text = "Value a:";
            // 
            // textBoxA
            // 
            textBoxA.Location = new Point(150, 247);
            textBoxA.Name = "textBoxA";
            textBoxA.Size = new Size(125, 27);
            textBoxA.TabIndex = 3;
            // 
            // labelB
            // 
            labelB.AutoSize = true;
            labelB.Location = new Point(50, 290);
            labelB.Name = "labelB";
            labelB.Size = new Size(92, 20);
            labelB.TabIndex = 4;
            labelB.Text = "Value b:";
            // 
            // textBoxB
            // 
            textBoxB.Location = new Point(150, 287);
            textBoxB.Name = "textBoxB";
            textBoxB.Size = new Size(125, 27);
            textBoxB.TabIndex = 5;
            // 
            // labelAttempts
            // 
            labelAttempts.AutoSize = true;
            labelAttempts.Location = new Point(50, 330);
            labelAttempts.Name = "labelAttempts";
            labelAttempts.Size = new Size(157, 20);
            labelAttempts.TabIndex = 6;
            labelAttempts.Text = "Number of attempts:";
            // 
            // numericUpDownAttempts
            // 
            numericUpDownAttempts.Location = new Point(200, 328);
            numericUpDownAttempts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownAttempts.Name = "numericUpDownAttempts";
            numericUpDownAttempts.Size = new Size(75, 27);
            numericUpDownAttempts.TabIndex = 7;
            numericUpDownAttempts.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // labelGuess
            // 
            labelGuess.AutoSize = true;
            labelGuess.Location = new Point(400, 250);
            labelGuess.Name = "labelGuess";
            labelGuess.Size = new Size(167, 20);
            labelGuess.TabIndex = 8;
            labelGuess.Text = "Your guess:";
            // 
            // textBoxGuess
            // 
            textBoxGuess.Location = new Point(580, 247);
            textBoxGuess.Name = "textBoxGuess";
            textBoxGuess.Size = new Size(125, 27);
            textBoxGuess.TabIndex = 9;
            // 
            // buttonCheck
            // 
            buttonCheck.Location = new Point(580, 290);
            buttonCheck.Name = "buttonCheck";
            buttonCheck.Size = new Size(125, 35);
            buttonCheck.TabIndex = 10;
            buttonCheck.Text = "Check";
            buttonCheck.UseVisualStyleBackColor = true;
            buttonCheck.Click += buttonCheck_Click;
            // 
            // buttonNewGame
            // 
            buttonNewGame.Location = new Point(580, 330);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new Size(125, 35);
            buttonNewGame.TabIndex = 11;
            buttonNewGame.Text = "New Game";
            buttonNewGame.UseVisualStyleBackColor = true;
            buttonNewGame.Click += buttonNewGame_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(400, 380);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(78, 20);
            labelResult.TabIndex = 12;
            labelResult.Text = "Result:";
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new Point(400, 410);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.ReadOnly = true;
            textBoxResult.ScrollBars = ScrollBars.Vertical;
            textBoxResult.Size = new Size(305, 100);
            textBoxResult.TabIndex = 13;
            // 
            // labelFunction
            // 
            labelFunction.AutoSize = true;
            labelFunction.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelFunction.Location = new Point(300, 30);
            labelFunction.Name = "labelFunction";
            labelFunction.Size = new Size(289, 32);
            labelFunction.TabIndex = 15;
            labelFunction.Text = "Game 'Guess the Function'";
            // 
            // MathGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 550);
            Controls.Add(labelFunction);
            Controls.Add(labelInstructions);
            Controls.Add(textBoxResult);
            Controls.Add(labelResult);
            Controls.Add(buttonNewGame);
            Controls.Add(buttonCheck);
            Controls.Add(textBoxGuess);
            Controls.Add(labelGuess);
            Controls.Add(numericUpDownAttempts);
            Controls.Add(labelAttempts);
            Controls.Add(textBoxB);
            Controls.Add(labelB);
            Controls.Add(textBoxA);
            Controls.Add(labelA);
            Controls.Add(labelFormula);
            Controls.Add(pictureBox1);
            Name = "MathGameForm";
            Text = "Math Game - Guess the Function Value";
            Load += MathGameForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAttempts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelFormula;
        private Label labelA;
        private TextBox textBoxA;
        private Label labelB;
        private TextBox textBoxB;
        private Label labelAttempts;
        private NumericUpDown numericUpDownAttempts;
        private Label labelGuess;
        private TextBox textBoxGuess;
        private Button buttonCheck;
        private Button buttonNewGame;
        private Label labelResult;
        private TextBox textBoxResult;
        private Label labelInstructions;
        private Label labelFunction;
    }
}