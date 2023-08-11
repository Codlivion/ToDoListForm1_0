using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListForm1_0
{
    public partial class TaskForm : Form
    {
        public MainForm mainForm; //MainForm instance

        bool editMode;
        int editNum;

        /// <summary>
        /// Used to add new Task when called parameterless.
        /// </summary>
        public TaskForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Used to show and edit Task when called with a Task object and it's index in the taskList.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="index"></param>
        public TaskForm(Task task, int index)
        {
            InitializeComponent();

            editMode = true;
            editNum = index;
            topLabel.Text = "Edit Task";
            tasklabelBox.Text = task.Label;
            taskdetailsBox.Text = task.Details;
            addButton.Text = "Edit";
            deleteButton.Visible = true;
            cancelButton.Text = "Close";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (tasklabelBox.Text == string.Empty)
            {
                MessageBox.Show("Task Label cannot be empty!");
                return;
            }

            if (tasklabelBox.Text.Length > 32)
            {
                MessageBox.Show("Task Label exceeds the character limit!");
                return;
            }

            if (taskdetailsBox.Text.Length > 128)
            {
                MessageBox.Show("Task Details exceeds the character limit!");
                return;
            }


            if (editMode)
            {
                mainForm.taskList[editNum].Label = tasklabelBox.Text;
                mainForm.taskList[editNum].Details = taskdetailsBox.Text;
            }
            else
            {
                Task task = new Task(tasklabelBox.Text, false, taskdetailsBox.Text);
                mainForm.taskList.Add(task);
            }

            mainForm.RefreshTaskPanel();
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete This Task?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                mainForm.taskList.Remove(mainForm.taskList[editNum]);
                mainForm.RefreshTaskPanel();
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
