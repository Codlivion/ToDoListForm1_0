namespace ToDoListForm1_0
{
    partial class MainForm
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
            this.formLayout = new System.Windows.Forms.TableLayoutPanel();
            this.newlistButton = new System.Windows.Forms.Button();
            this.mylistsLabel = new System.Windows.Forms.Label();
            this.listFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.taskFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.listnameSplit = new System.Windows.Forms.SplitContainer();
            this.listnameBox = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.buttonsSplit = new System.Windows.Forms.SplitContainer();
            this.newtaskButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.formLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listnameSplit)).BeginInit();
            this.listnameSplit.Panel1.SuspendLayout();
            this.listnameSplit.Panel2.SuspendLayout();
            this.listnameSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonsSplit)).BeginInit();
            this.buttonsSplit.Panel1.SuspendLayout();
            this.buttonsSplit.Panel2.SuspendLayout();
            this.buttonsSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // formLayout
            // 
            this.formLayout.ColumnCount = 5;
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.formLayout.Controls.Add(this.newlistButton, 1, 0);
            this.formLayout.Controls.Add(this.mylistsLabel, 1, 1);
            this.formLayout.Controls.Add(this.listFlow, 1, 2);
            this.formLayout.Controls.Add(this.taskFlow, 3, 2);
            this.formLayout.Controls.Add(this.listnameSplit, 3, 1);
            this.formLayout.Controls.Add(this.buttonsSplit, 3, 0);
            this.formLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formLayout.Location = new System.Drawing.Point(0, 0);
            this.formLayout.Name = "formLayout";
            this.formLayout.RowCount = 4;
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.formLayout.Size = new System.Drawing.Size(800, 600);
            this.formLayout.TabIndex = 0;
            // 
            // newlistButton
            // 
            this.newlistButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newlistButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newlistButton.Location = new System.Drawing.Point(37, 5);
            this.newlistButton.Margin = new System.Windows.Forms.Padding(5);
            this.newlistButton.Name = "newlistButton";
            this.newlistButton.Size = new System.Drawing.Size(190, 26);
            this.newlistButton.TabIndex = 0;
            this.newlistButton.Text = "NEW LIST";
            this.newlistButton.UseVisualStyleBackColor = true;
            this.newlistButton.Click += new System.EventHandler(this.NewListClick);
            // 
            // mylistsLabel
            // 
            this.mylistsLabel.AutoSize = true;
            this.mylistsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mylistsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mylistsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mylistsLabel.Location = new System.Drawing.Point(37, 41);
            this.mylistsLabel.Margin = new System.Windows.Forms.Padding(5);
            this.mylistsLabel.Name = "mylistsLabel";
            this.mylistsLabel.Size = new System.Drawing.Size(190, 26);
            this.mylistsLabel.TabIndex = 1;
            this.mylistsLabel.Text = "MY LISTS";
            this.mylistsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listFlow
            // 
            this.listFlow.AutoScroll = true;
            this.listFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.listFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFlow.Location = new System.Drawing.Point(35, 75);
            this.listFlow.Name = "listFlow";
            this.listFlow.Size = new System.Drawing.Size(194, 486);
            this.listFlow.TabIndex = 2;
            this.listFlow.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawListPanel);
            this.listFlow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListPanelClick);
            // 
            // taskFlow
            // 
            this.taskFlow.AutoScroll = true;
            this.taskFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.taskFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskFlow.Location = new System.Drawing.Point(267, 75);
            this.taskFlow.Name = "taskFlow";
            this.taskFlow.Size = new System.Drawing.Size(498, 486);
            this.taskFlow.TabIndex = 3;
            this.taskFlow.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawTaskPanel);
            this.taskFlow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TaskPanelClick);
            // 
            // listnameSplit
            // 
            this.listnameSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listnameSplit.Location = new System.Drawing.Point(267, 39);
            this.listnameSplit.Name = "listnameSplit";
            // 
            // listnameSplit.Panel1
            // 
            this.listnameSplit.Panel1.Controls.Add(this.listnameBox);
            // 
            // listnameSplit.Panel2
            // 
            this.listnameSplit.Panel2.Controls.Add(this.updateButton);
            this.listnameSplit.Size = new System.Drawing.Size(498, 30);
            this.listnameSplit.SplitterDistance = 398;
            this.listnameSplit.TabIndex = 4;
            // 
            // listnameBox
            // 
            this.listnameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listnameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listnameBox.Location = new System.Drawing.Point(0, 0);
            this.listnameBox.Name = "listnameBox";
            this.listnameBox.Size = new System.Drawing.Size(398, 26);
            this.listnameBox.TabIndex = 0;
            this.listnameBox.Text = "New List";
            this.listnameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updateButton.Location = new System.Drawing.Point(0, 0);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(96, 26);
            this.updateButton.TabIndex = 0;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateClick);
            // 
            // buttonsSplit
            // 
            this.buttonsSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonsSplit.Location = new System.Drawing.Point(267, 3);
            this.buttonsSplit.Name = "buttonsSplit";
            // 
            // buttonsSplit.Panel1
            // 
            this.buttonsSplit.Panel1.Controls.Add(this.newtaskButton);
            // 
            // buttonsSplit.Panel2
            // 
            this.buttonsSplit.Panel2.Controls.Add(this.deleteButton);
            this.buttonsSplit.Size = new System.Drawing.Size(498, 30);
            this.buttonsSplit.SplitterDistance = 398;
            this.buttonsSplit.TabIndex = 5;
            // 
            // newtaskButton
            // 
            this.newtaskButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newtaskButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.newtaskButton.Location = new System.Drawing.Point(0, 0);
            this.newtaskButton.Name = "newtaskButton";
            this.newtaskButton.Size = new System.Drawing.Size(398, 30);
            this.newtaskButton.TabIndex = 0;
            this.newtaskButton.Text = "New Task";
            this.newtaskButton.UseVisualStyleBackColor = true;
            this.newtaskButton.Click += new System.EventHandler(this.NewTaskClick);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteButton.Location = new System.Drawing.Point(0, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(96, 30);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.formLayout);
            this.Name = "MainForm";
            this.Text = "TODO LIST";
            this.formLayout.ResumeLayout(false);
            this.formLayout.PerformLayout();
            this.listnameSplit.Panel1.ResumeLayout(false);
            this.listnameSplit.Panel1.PerformLayout();
            this.listnameSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listnameSplit)).EndInit();
            this.listnameSplit.ResumeLayout(false);
            this.buttonsSplit.Panel1.ResumeLayout(false);
            this.buttonsSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonsSplit)).EndInit();
            this.buttonsSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel formLayout;
        private System.Windows.Forms.Button newlistButton;
        private System.Windows.Forms.Label mylistsLabel;
        private System.Windows.Forms.FlowLayoutPanel listFlow;
        private System.Windows.Forms.FlowLayoutPanel taskFlow;
        private System.Windows.Forms.SplitContainer listnameSplit;
        private System.Windows.Forms.TextBox listnameBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button newtaskButton;
        private System.Windows.Forms.SplitContainer buttonsSplit;
        private System.Windows.Forms.Button deleteButton;
    }
}

