namespace NW.QALogger
{
    partial class MainApp
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
            label1 = new Label();
            listBox1 = new ListBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            textBox1 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(27, 21);
            label1.Name = "label1";
            label1.Size = new Size(303, 38);
            label1.TabIndex = 0;
            label1.Text = "Welcome to QA Logger!";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.InfoText;
            listBox1.Font = new Font("Segoe UI Emoji", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.White;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 26;
            listBox1.Items.AddRange(new object[] { "confirmed-bugs", "cannot-reproduce", "uncertain-if-bug", "event-bugs", "map-generator-bugs", "not-scpsl-bugs", "duplicates", "old-bugs", "fixed", "unity-issues", "crash-reports" });
            listBox1.Location = new Point(27, 72);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(199, 82);
            listBox1.TabIndex = 1;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox1.ForeColor = Color.Chartreuse;
            checkBox1.Location = new Point(251, 81);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(52, 25);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "✅";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox2.ForeColor = Color.Red;
            checkBox2.Location = new Point(251, 112);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(52, 25);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "❌";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(33, 268);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(303, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Snow;
            label2.Location = new Point(12, 244);
            label2.Name = "label2";
            label2.Size = new Size(150, 21);
            label2.TabIndex = 0;
            label2.Text = "Link to message";
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(101, 312);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Emoji", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Snow;
            label3.Location = new Point(27, 185);
            label3.Name = "label3";
            label3.Size = new Size(83, 21);
            label3.TabIndex = 0;
            label3.Text = "Username";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(33, 209);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(303, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox1_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(182, 312);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "RESET";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button1_Click;
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InfoText;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(366, 361);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(listBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainApp";
            Text = "QA Logger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private TextBox textBox1;
        private Label label2;
        private Button button1;
        private Label label3;
        private TextBox textBox2;
        private Button button2;
    }
}
