namespace NiggaWay
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            fileDiag = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            lengthLbl = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Załaduj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // fileDiag
            // 
            fileDiag.Filter = "Json|*.json";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Location = new Point(8, 36);
            pictureBox1.MinimumSize = new Size(500, 500);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 500);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // lengthLbl
            // 
            lengthLbl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lengthLbl.AutoSize = true;
            lengthLbl.Location = new Point(84, 7);
            lengthLbl.Name = "lengthLbl";
            lengthLbl.Size = new Size(430, 15);
            lengthLbl.TabIndex = 3;
            lengthLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label1, 2);
            label1.Location = new Point(3, 543);
            label1.Name = "label1";
            label1.Size = new Size(511, 15);
            label1.TabIndex = 4;
            label1.Text = "Czerwony - punkt początkowy\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(lengthLbl, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 2);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(517, 558);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 558);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private OpenFileDialog fileDiag;
        private PictureBox pictureBox1;
        private Label lengthLbl;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
    }
}
