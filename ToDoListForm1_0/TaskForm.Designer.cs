namespace ToDoListForm1_0
{
    partial class TaskForm
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
            this.taskformLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topLabel = new System.Windows.Forms.Label();
            this.tasklabelBox = new System.Windows.Forms.TextBox();
            this.taskdetailsBox = new System.Windows.Forms.TextBox();
            this.buttonsFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.taskformLayout.SuspendLayout();
            this.buttonsFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskformLayout
            // 
            this.taskformLayout.ColumnCount = 3;
            this.taskformLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taskformLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.taskformLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taskformLayout.Controls.Add(this.topLabel, 1, 1);
            this.taskformLayout.Controls.Add(this.tasklabelBox, 1, 2);
            this.taskformLayout.Controls.Add(this.taskdetailsBox, 1, 3);
            this.taskformLayout.Controls.Add(this.buttonsFlow, 1, 4);
            this.taskformLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskformLayout.Location = new System.Drawing.Point(0, 0);
            this.taskformLayout.Name = "taskformLayout";
            this.taskformLayout.RowCount = 6;
            this.taskformLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taskformLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taskformLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taskformLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.taskformLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.taskformLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.taskformLayout.Size = new System.Drawing.Size(480, 320);
            this.taskformLayout.TabIndex = 0;
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.topLabel.Location = new System.Drawing.Point(51, 32);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(378, 32);
            this.topLabel.TabIndex = 0;
            this.topLabel.Text = "New Task";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tasklabelBox
            // 
            this.tasklabelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasklabelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tasklabelBox.Location = new System.Drawing.Point(51, 67);
            this.tasklabelBox.Name = "tasklabelBox";
            this.tasklabelBox.Size = new System.Drawing.Size(378, 26);
            this.tasklabelBox.TabIndex = 1;
            // 
            // taskdetailsBox
            // 
            this.taskdetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskdetailsBox.Location = new System.Drawing.Point(51, 99);
            this.taskdetailsBox.Multiline = true;
            this.taskdetailsBox.Name = "taskdetailsBox";
            this.taskdetailsBox.Size = new System.Drawing.Size(378, 138);
            this.taskdetailsBox.TabIndex = 2;
            // 
            // buttonsFlow
            // 
            this.buttonsFlow.Controls.Add(this.addButton);
            this.buttonsFlow.Controls.Add(this.deleteButton);
            this.buttonsFlow.Controls.Add(this.cancelButton);
            this.buttonsFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsFlow.Location = new System.Drawing.Point(51, 243);
            this.buttonsFlow.Name = "buttonsFlow";
            this.buttonsFlow.Size = new System.Drawing.Size(378, 42);
            this.buttonsFlow.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(120, 36);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "ADD";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteButton.Location = new System.Drawing.Point(129, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(120, 36);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cancelButton.Location = new System.Drawing.Point(255, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(120, 36);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "CANCEL";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.taskformLayout);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.taskformLayout.ResumeLayout(false);
            this.taskformLayout.PerformLayout();
            this.buttonsFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel taskformLayout;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.TextBox tasklabelBox;
        private System.Windows.Forms.TextBox taskdetailsBox;
        private System.Windows.Forms.FlowLayoutPanel buttonsFlow;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button cancelButton;
    }
}