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
            buttonInsert = new Button();
            buttonDelete = new Button();
            buttonSelected = new Button();
            label1 = new Label();
            buttonImage = new Button();
            buttonTable = new Button();
            buttonChart = new Button();
            myTree2 = new WinFormsLibrary1.MyTree();
            SuspendLayout();
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(11, 243);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(94, 29);
            buttonInsert.TabIndex = 3;
            buttonInsert.Text = "Добавить";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(11, 277);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 29);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSelected
            // 
            buttonSelected.Location = new Point(126, 243);
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
            // buttonImage
            // 
            buttonImage.Location = new Point(14, 404);
            buttonImage.Margin = new Padding(3, 4, 3, 4);
            buttonImage.Name = "buttonImage";
            buttonImage.Size = new Size(155, 31);
            buttonImage.TabIndex = 7;
            buttonImage.Text = "Пдф с изображением";
            buttonImage.UseVisualStyleBackColor = true;
            buttonImage.Click += buttonImage_Click;
            // 
            // buttonTable
            // 
            buttonTable.Location = new Point(176, 404);
            buttonTable.Margin = new Padding(3, 4, 3, 4);
            buttonTable.Name = "buttonTable";
            buttonTable.Size = new Size(160, 31);
            buttonTable.TabIndex = 8;
            buttonTable.Text = "Пдф с таблицей";
            buttonTable.UseVisualStyleBackColor = true;
            buttonTable.Click += buttonTable_Click;
            // 
            // buttonChart
            // 
            buttonChart.Location = new Point(343, 404);
            buttonChart.Margin = new Padding(3, 4, 3, 4);
            buttonChart.Name = "buttonChart";
            buttonChart.Size = new Size(189, 31);
            buttonChart.TabIndex = 9;
            buttonChart.Text = "Пдф с диаграммой";
            buttonChart.UseVisualStyleBackColor = true;
            buttonChart.Click += buttonChart_Click;
            // 
            // myTree2
            // 
            myTree2.Location = new Point(271, 12);
            myTree2.Name = "myTree2";
            myTree2.SelectedIndex = -1;
            myTree2.Size = new Size(517, 385);
            myTree2.TabIndex = 10;
            // 
            // FormTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(myTree2);
            Controls.Add(buttonChart);
            Controls.Add(buttonTable);
            Controls.Add(buttonImage);
            Controls.Add(label1);
            Controls.Add(buttonSelected);
            Controls.Add(buttonDelete);
            Controls.Add(buttonInsert);
            Name = "FormTest";
            Text = "FormTest";
            Load += FormTest_Load;
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
        private Button buttonImage;
        private Button buttonTable;
        private Button buttonChart;
        private WinFormsLibrary1.MyTree myTree2;
    }
}