namespace CPM_Cost
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.nodeBox = new System.Windows.Forms.GroupBox();
            this.prevField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nextField = new System.Windows.Forms.TextBox();
            this.idField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.kgrField = new System.Windows.Forms.TextBox();
            this.knField = new System.Windows.Forms.TextBox();
            this.tgrField = new System.Windows.Forms.TextBox();
            this.tnField = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.pointsList = new System.Windows.Forms.ComboBox();
            this.solutionBox = new System.Windows.Forms.GroupBox();
            this.costField = new System.Windows.Forms.RichTextBox();
            this.timeField = new System.Windows.Forms.RichTextBox();
            this.solutionField = new System.Windows.Forms.RichTextBox();
            this.critPathLabel = new System.Windows.Forms.Label();
            this.normalTimeField = new System.Windows.Forms.RichTextBox();
            this.nodeBox.SuspendLayout();
            this.solutionBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeBox
            // 
            this.nodeBox.Controls.Add(this.prevField);
            this.nodeBox.Controls.Add(this.label7);
            this.nodeBox.Controls.Add(this.actionLabel);
            this.nodeBox.Controls.Add(this.label6);
            this.nodeBox.Controls.Add(this.nextField);
            this.nodeBox.Controls.Add(this.idField);
            this.nodeBox.Controls.Add(this.label5);
            this.nodeBox.Controls.Add(this.label4);
            this.nodeBox.Controls.Add(this.label3);
            this.nodeBox.Controls.Add(this.label2);
            this.nodeBox.Controls.Add(this.label1);
            this.nodeBox.Controls.Add(this.kgrField);
            this.nodeBox.Controls.Add(this.knField);
            this.nodeBox.Controls.Add(this.tgrField);
            this.nodeBox.Controls.Add(this.tnField);
            this.nodeBox.Controls.Add(this.saveButton);
            this.nodeBox.Location = new System.Drawing.Point(12, 12);
            this.nodeBox.Name = "nodeBox";
            this.nodeBox.Size = new System.Drawing.Size(217, 301);
            this.nodeBox.TabIndex = 0;
            this.nodeBox.TabStop = false;
            this.nodeBox.Text = "Node info";
            // 
            // prevField
            // 
            this.prevField.Location = new System.Drawing.Point(62, 202);
            this.prevField.Name = "prevField";
            this.prevField.Size = new System.Drawing.Size(149, 20);
            this.prevField.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Prev";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.BackColor = System.Drawing.SystemColors.Control;
            this.actionLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.actionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.actionLabel.Location = new System.Drawing.Point(3, 272);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(139, 13);
            this.actionLabel.TabIndex = 16;
            this.actionLabel.Text = "ACTION [ WAITING... ]";
            this.actionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.actionLabel.UseMnemonic = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Next";
            // 
            // nextField
            // 
            this.nextField.Location = new System.Drawing.Point(62, 176);
            this.nextField.Name = "nextField";
            this.nextField.Size = new System.Drawing.Size(149, 20);
            this.nextField.TabIndex = 13;
            // 
            // idField
            // 
            this.idField.BackColor = System.Drawing.SystemColors.Window;
            this.idField.Cursor = System.Windows.Forms.Cursors.No;
            this.idField.Enabled = false;
            this.idField.Location = new System.Drawing.Point(62, 29);
            this.idField.Name = "idField";
            this.idField.Size = new System.Drawing.Size(149, 20);
            this.idField.TabIndex = 12;
            this.idField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kgr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tgr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tn";
            // 
            // kgrField
            // 
            this.kgrField.Location = new System.Drawing.Point(62, 150);
            this.kgrField.Name = "kgrField";
            this.kgrField.Size = new System.Drawing.Size(149, 20);
            this.kgrField.TabIndex = 6;
            this.kgrField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // knField
            // 
            this.knField.Location = new System.Drawing.Point(62, 124);
            this.knField.Name = "knField";
            this.knField.Size = new System.Drawing.Size(149, 20);
            this.knField.TabIndex = 5;
            this.knField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tgrField
            // 
            this.tgrField.Location = new System.Drawing.Point(62, 98);
            this.tgrField.Name = "tgrField";
            this.tgrField.Size = new System.Drawing.Size(149, 20);
            this.tgrField.TabIndex = 4;
            this.tgrField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tnField
            // 
            this.tnField.Location = new System.Drawing.Point(62, 72);
            this.tnField.Name = "tnField";
            this.tnField.Size = new System.Drawing.Size(149, 20);
            this.tnField.TabIndex = 3;
            this.tnField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(6, 246);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(205, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 346);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(217, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add new...";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Enabled = false;
            this.calculateButton.Location = new System.Drawing.Point(12, 375);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(217, 23);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // pointsList
            // 
            this.pointsList.Enabled = false;
            this.pointsList.FormattingEnabled = true;
            this.pointsList.Location = new System.Drawing.Point(12, 319);
            this.pointsList.Name = "pointsList";
            this.pointsList.Size = new System.Drawing.Size(217, 21);
            this.pointsList.TabIndex = 4;
            this.pointsList.SelectedIndexChanged += new System.EventHandler(this.pointsList_SelectedIndexChanged);
            // 
            // solutionBox
            // 
            this.solutionBox.Controls.Add(this.normalTimeField);
            this.solutionBox.Controls.Add(this.costField);
            this.solutionBox.Controls.Add(this.timeField);
            this.solutionBox.Controls.Add(this.solutionField);
            this.solutionBox.Controls.Add(this.critPathLabel);
            this.solutionBox.Location = new System.Drawing.Point(235, 12);
            this.solutionBox.Name = "solutionBox";
            this.solutionBox.Size = new System.Drawing.Size(378, 386);
            this.solutionBox.TabIndex = 5;
            this.solutionBox.TabStop = false;
            this.solutionBox.Text = "Solution";
            // 
            // costField
            // 
            this.costField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.costField.Enabled = false;
            this.costField.Location = new System.Drawing.Point(6, 82);
            this.costField.Name = "costField";
            this.costField.Size = new System.Drawing.Size(366, 25);
            this.costField.TabIndex = 3;
            this.costField.Text = "";
            // 
            // timeField
            // 
            this.timeField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeField.Enabled = false;
            this.timeField.Location = new System.Drawing.Point(6, 51);
            this.timeField.Name = "timeField";
            this.timeField.Size = new System.Drawing.Size(366, 25);
            this.timeField.TabIndex = 2;
            this.timeField.Text = "";
            // 
            // solutionField
            // 
            this.solutionField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.solutionField.Enabled = false;
            this.solutionField.Location = new System.Drawing.Point(6, 20);
            this.solutionField.Name = "solutionField";
            this.solutionField.Size = new System.Drawing.Size(366, 25);
            this.solutionField.TabIndex = 1;
            this.solutionField.Text = "";
            // 
            // critPathLabel
            // 
            this.critPathLabel.AutoSize = true;
            this.critPathLabel.Location = new System.Drawing.Point(7, 20);
            this.critPathLabel.Name = "critPathLabel";
            this.critPathLabel.Size = new System.Drawing.Size(0, 13);
            this.critPathLabel.TabIndex = 0;
            // 
            // normalTimeField
            // 
            this.normalTimeField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.normalTimeField.Enabled = false;
            this.normalTimeField.Location = new System.Drawing.Point(6, 113);
            this.normalTimeField.Name = "normalTimeField";
            this.normalTimeField.Size = new System.Drawing.Size(366, 25);
            this.normalTimeField.TabIndex = 4;
            this.normalTimeField.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 408);
            this.Controls.Add(this.solutionBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.pointsList);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.nodeBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple CPM_COST Method - Hubert Pięta, Kacper Popczyński";
            this.nodeBox.ResumeLayout(false);
            this.nodeBox.PerformLayout();
            this.solutionBox.ResumeLayout(false);
            this.solutionBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nodeBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.ComboBox pointsList;
        private System.Windows.Forms.GroupBox solutionBox;
        private System.Windows.Forms.TextBox idField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox kgrField;
        private System.Windows.Forms.TextBox knField;
        private System.Windows.Forms.TextBox tgrField;
        private System.Windows.Forms.TextBox tnField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nextField;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label critPathLabel;
        private System.Windows.Forms.TextBox prevField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox solutionField;
        private System.Windows.Forms.RichTextBox costField;
        private System.Windows.Forms.RichTextBox timeField;
        private System.Windows.Forms.RichTextBox normalTimeField;
    }
}

