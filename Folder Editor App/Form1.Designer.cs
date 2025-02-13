namespace Folder_Editor_App
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
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            treeView2 = new TreeView();
            panel1 = new Panel();
            treeView1 = new TreeView();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button6 = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Location = new Point(426, 395);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 17;
            button5.Text = "Back";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(291, 395);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 16;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(367, 290);
            button3.Name = "button3";
            button3.Size = new Size(53, 29);
            button3.TabIndex = 15;
            button3.Text = "©";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(367, 218);
            button2.Name = "button2";
            button2.Size = new Size(53, 29);
            button2.TabIndex = 14;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(367, 151);
            button1.Name = "button1";
            button1.Size = new Size(53, 29);
            button1.TabIndex = 13;
            button1.Text = ">";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(treeView2);
            panel2.Location = new Point(517, 98);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 277);
            panel2.TabIndex = 12;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(3, 3);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(223, 271);
            treeView2.TabIndex = 0;
            treeView2.BeforeExpand += treeView2_BeforeExpand;
            treeView2.AfterSelect += treeView2_AfterSelect;
            // 
            // panel1
            // 
            panel1.Controls.Add(treeView1);
            panel1.Location = new Point(61, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(222, 277);
            panel1.TabIndex = 11;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(0, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(219, 271);
            treeView1.TabIndex = 0;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(517, 26);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(229, 27);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(54, 26);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(229, 27);
            textBox1.TabIndex = 9;
            // 
            // button6
            // 
            button6.Location = new Point(652, 395);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 1;
            button6.Text = "refresh";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel panel2;
        private Panel panel1;
        private TextBox textBox2;
        private TextBox textBox1;
        private TreeView treeView1;
        private Button button6;
        private TreeView treeView2;
    }
}
