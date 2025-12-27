namespace BasicProgrammingLab6
{
    partial class ConnectFourGameForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectFourGameForm));
            dataGridViewGameBoard = new DataGridView();
            panelGameInfo = new Panel();
            labelGameStatus = new Label();
            labelCurrentPlayer = new Label();
            labelCurrentPlayerValue = new Label();
            labelGameStatusTitle = new Label();
            panelControls = new Panel();
            buttonExit = new Button();
            buttonReset = new Button();
            buttonNewGame = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            panelPlayerInfo = new Panel();
            labelPlayer2Score = new Label();
            labelPlayer1Score = new Label();
            labelPlayer2 = new Label();
            labelPlayer1 = new Label();
            pictureBoxPlayer2 = new PictureBox();
            pictureBoxPlayer1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGameBoard).BeginInit();
            panelGameInfo.SuspendLayout();
            panelControls.SuspendLayout();
            statusStrip.SuspendLayout();
            panelPlayerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewGameBoard
            // 
            dataGridViewGameBoard.AllowUserToAddRows = false;
            dataGridViewGameBoard.AllowUserToDeleteRows = false;
            dataGridViewGameBoard.AllowUserToResizeColumns = false;
            dataGridViewGameBoard.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewGameBoard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewGameBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewGameBoard.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewGameBoard.Location = new Point(220, 30);
            dataGridViewGameBoard.Margin = new Padding(4, 5, 4, 5);
            dataGridViewGameBoard.Name = "dataGridViewGameBoard";
            dataGridViewGameBoard.ReadOnly = true;
            dataGridViewGameBoard.RowHeadersVisible = false;
            dataGridViewGameBoard.RowHeadersWidth = 51;
            dataGridViewGameBoard.Size = new Size(420, 360);
            dataGridViewGameBoard.TabIndex = 0;
            dataGridViewGameBoard.CellClick += dataGridViewGameBoard_CellClick;
            dataGridViewGameBoard.CellMouseEnter += dataGridViewGameBoard_CellMouseEnter;
            dataGridViewGameBoard.CellMouseLeave += dataGridViewGameBoard_CellMouseLeave;
            // 
            // panelGameInfo
            // 
            panelGameInfo.BackColor = Color.LightGray;
            panelGameInfo.BorderStyle = BorderStyle.FixedSingle;
            panelGameInfo.Controls.Add(labelGameStatus);
            panelGameInfo.Controls.Add(labelCurrentPlayer);
            panelGameInfo.Controls.Add(labelCurrentPlayerValue);
            panelGameInfo.Controls.Add(labelGameStatusTitle);
            panelGameInfo.Location = new Point(220, 400);
            panelGameInfo.Name = "panelGameInfo";
            panelGameInfo.Size = new Size(420, 100);
            panelGameInfo.TabIndex = 1;
            // 
            // labelGameStatus
            // 
            labelGameStatus.BackColor = Color.LightBlue;
            labelGameStatus.BorderStyle = BorderStyle.FixedSingle;
            labelGameStatus.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelGameStatus.Location = new Point(150, 50);
            labelGameStatus.Name = "labelGameStatus";
            labelGameStatus.Size = new Size(250, 30);
            labelGameStatus.TabIndex = 3;
            labelGameStatus.Text = "Game in Progress";
            labelGameStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelCurrentPlayer
            // 
            labelCurrentPlayer.AutoSize = true;
            labelCurrentPlayer.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelCurrentPlayer.Location = new Point(20, 20);
            labelCurrentPlayer.Name = "labelCurrentPlayer";
            labelCurrentPlayer.Size = new Size(120, 19);
            labelCurrentPlayer.TabIndex = 0;
            labelCurrentPlayer.Text = "Current Player:";
            // 
            // labelCurrentPlayerValue
            // 
            labelCurrentPlayerValue.BackColor = Color.Red;
            labelCurrentPlayerValue.BorderStyle = BorderStyle.FixedSingle;
            labelCurrentPlayerValue.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelCurrentPlayerValue.ForeColor = Color.White;
            labelCurrentPlayerValue.Location = new Point(150, 15);
            labelCurrentPlayerValue.Name = "labelCurrentPlayerValue";
            labelCurrentPlayerValue.Size = new Size(40, 30);
            labelCurrentPlayerValue.TabIndex = 1;
            labelCurrentPlayerValue.Text = "X";
            labelCurrentPlayerValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelGameStatusTitle
            // 
            labelGameStatusTitle.AutoSize = true;
            labelGameStatusTitle.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelGameStatusTitle.Location = new Point(20, 55);
            labelGameStatusTitle.Name = "labelGameStatusTitle";
            labelGameStatusTitle.Size = new Size(110, 19);
            labelGameStatusTitle.TabIndex = 2;
            labelGameStatusTitle.Text = "Game Status:";
            // 
            // panelControls
            // 
            panelControls.BackColor = SystemColors.ControlLight;
            panelControls.Controls.Add(buttonExit);
            panelControls.Controls.Add(buttonReset);
            panelControls.Controls.Add(buttonNewGame);
            panelControls.Location = new Point(20, 30);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(180, 145);
            panelControls.TabIndex = 2;
            // 
            // buttonExit
            // 
            buttonExit.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonExit.Location = new Point(10, 100);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(160, 35);
            buttonExit.TabIndex = 2;
            buttonExit.Text = "Exit Game";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonReset
            // 
            buttonReset.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonReset.Location = new Point(10, 55);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(160, 35);
            buttonReset.TabIndex = 1;
            buttonReset.Text = "Reset Game";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonNewGame
            // 
            buttonNewGame.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonNewGame.Location = new Point(10, 10);
            buttonNewGame.Name = "buttonNewGame";
            buttonNewGame.Size = new Size(160, 35);
            buttonNewGame.TabIndex = 0;
            buttonNewGame.Text = "New Game";
            buttonNewGame.UseVisualStyleBackColor = true;
            buttonNewGame.Click += buttonNewGame_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 540);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(660, 26);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(50, 20);
            toolStripStatusLabel.Text = "Ready";
            // 
            // panelPlayerInfo
            // 
            panelPlayerInfo.BackColor = Color.LightGray;
            panelPlayerInfo.BorderStyle = BorderStyle.FixedSingle;
            panelPlayerInfo.Controls.Add(labelPlayer2Score);
            panelPlayerInfo.Controls.Add(labelPlayer1Score);
            panelPlayerInfo.Controls.Add(labelPlayer2);
            panelPlayerInfo.Controls.Add(labelPlayer1);
            panelPlayerInfo.Controls.Add(pictureBoxPlayer2);
            panelPlayerInfo.Controls.Add(pictureBoxPlayer1);
            panelPlayerInfo.Location = new Point(20, 185);
            panelPlayerInfo.Name = "panelPlayerInfo";
            panelPlayerInfo.Size = new Size(180, 200);
            panelPlayerInfo.TabIndex = 4;
            // 
            // labelPlayer2Score
            // 
            labelPlayer2Score.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayer2Score.Location = new Point(10, 150);
            labelPlayer2Score.Name = "labelPlayer2Score";
            labelPlayer2Score.Size = new Size(160, 40);
            labelPlayer2Score.TabIndex = 5;
            labelPlayer2Score.Text = "Player O (Yellow)";
            labelPlayer2Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPlayer1Score
            // 
            labelPlayer1Score.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelPlayer1Score.Location = new Point(10, 60);
            labelPlayer1Score.Name = "labelPlayer1Score";
            labelPlayer1Score.Size = new Size(160, 40);
            labelPlayer1Score.TabIndex = 4;
            labelPlayer1Score.Text = "Player X (Red)";
            labelPlayer1Score.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPlayer2
            // 
            labelPlayer2.AutoSize = true;
            labelPlayer2.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer2.Location = new Point(60, 100);
            labelPlayer2.Name = "labelPlayer2";
            labelPlayer2.Size = new Size(60, 19);
            labelPlayer2.TabIndex = 3;
            labelPlayer2.Text = "Player 2";
            // 
            // labelPlayer1
            // 
            labelPlayer1.AutoSize = true;
            labelPlayer1.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            labelPlayer1.Location = new Point(60, 10);
            labelPlayer1.Name = "labelPlayer1";
            labelPlayer1.Size = new Size(60, 19);
            labelPlayer1.TabIndex = 2;
            labelPlayer1.Text = "Player 1";
            // 
            // pictureBoxPlayer2
            // 
            pictureBoxPlayer2.BackColor = Color.Yellow;
            pictureBoxPlayer2.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPlayer2.Location = new Point(60, 125);
            pictureBoxPlayer2.Name = "pictureBoxPlayer2";
            pictureBoxPlayer2.Size = new Size(60, 40);
            pictureBoxPlayer2.TabIndex = 1;
            pictureBoxPlayer2.TabStop = false;
            // 
            // pictureBoxPlayer1
            // 
            pictureBoxPlayer1.BackColor = Color.Red;
            pictureBoxPlayer1.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPlayer1.Location = new Point(60, 35);
            pictureBoxPlayer1.Name = "pictureBoxPlayer1";
            pictureBoxPlayer1.Size = new Size(60, 40);
            pictureBoxPlayer1.TabIndex = 0;
            pictureBoxPlayer1.TabStop = false;
            // 
            // ConnectFourGameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(660, 566);
            Controls.Add(panelPlayerInfo);
            Controls.Add(statusStrip);
            Controls.Add(panelControls);
            Controls.Add(panelGameInfo);
            Controls.Add(dataGridViewGameBoard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(678, 613);
            Name = "ConnectFourGameForm";
            Text = "Connect Four Game";
            Load += ConnectFourGameForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewGameBoard).EndInit();
            panelGameInfo.ResumeLayout(false);
            panelGameInfo.PerformLayout();
            panelControls.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panelPlayerInfo.ResumeLayout(false);
            panelPlayerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPlayer2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewGameBoard;
        private Panel panelGameInfo;
        private Label labelCurrentPlayer;
        private Label labelCurrentPlayerValue;
        private Label labelGameStatus;
        private Label labelGameStatusTitle;
        private Panel panelControls;
        private Button buttonNewGame;
        private Button buttonReset;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Panel panelPlayerInfo;
        private Label labelPlayer1;
        private PictureBox pictureBoxPlayer1;
        private PictureBox pictureBoxPlayer2;
        private Label labelPlayer2;
        private Label labelPlayer2Score;
        private Label labelPlayer1Score;
        private Button buttonExit;
    }
}