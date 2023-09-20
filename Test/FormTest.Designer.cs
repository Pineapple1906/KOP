namespace Test
{
    partial class FormTest
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
            myCheckedListBox1 = new WinFormsLibrary1.MyCheckedListBox();
            myTextBox1 = new WinFormsLibrary1.MyTextBox();
            myTree1 = new WinFormsLibrary1.MyTree();
            buttonInsert = new Button();
            buttonDelete = new Button();
            buttonSelected = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // myCheckedListBox1
            // 
            myCheckedListBox1.Location = new Point(12, 12);
            myCheckedListBox1.Name = "myCheckedListBox1";
            myCheckedListBox1.SelectedElement = "";
            myCheckedListBox1.Size = new Size(208, 187);
            myCheckedListBox1.TabIndex = 0;
            // 
            // myTextBox1
            // 
            myTextBox1.EndRange = 100;
            myTextBox1.Location = new Point(12, 196);
            myTextBox1.Name = "myTextBox1";
            myTextBox1.Size = new Size(208, 40);
            myTextBox1.StartRange = 3;
            myTextBox1.TabIndex = 1;
            // 
            // myTree1
            // 
            myTree1.Location = new Point(308, 12);
            myTree1.Name = "myTree1";
            myTree1.SelectedIndex = -1;
            myTree1.Size = new Size(188, 158);
            myTree1.TabIndex = 2;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(12, 242);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(94, 29);
            buttonInsert.TabIndex = 3;
            buttonInsert.Text = "Добавить";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(12, 277);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 29);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSelected
            // 
            buttonSelected.Location = new Point(126, 242);
            buttonSelected.Name = "buttonSelected";
            buttonSelected.Size = new Size(94, 29);
            buttonSelected.TabIndex = 5;
            buttonSelected.Text = "Сохранить данные";
            buttonSelected.UseVisualStyleBackColor = true;
            buttonSelected.Click += buttonSelected_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 281);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // FormTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(buttonSelected);
            Controls.Add(buttonDelete);
            Controls.Add(buttonInsert);
            Controls.Add(myTree1);
            Controls.Add(myTextBox1);
            Controls.Add(myCheckedListBox1);
            Name = "FormTest";
            Text = "FormTest";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private WinFormsLibrary1.MyCheckedListBox myCheckedListBox1;
        private WinFormsLibrary1.MyTextBox myTextBox1;
        private WinFormsLibrary1.MyTree myTree1;
        private Button buttonInsert;
        private Button buttonDelete;
        private Button buttonSelected;
        private Label label1;
    }
}