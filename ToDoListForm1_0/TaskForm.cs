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
        public MainForm mainForm;

        bool editMode;
        int editNum;

        public TaskForm()
        {
            InitializeComponent();
        }

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
            //Check if all input fields are valid
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
            //After showing a confirm dialog:
            mainForm.taskList.Remove(mainForm.taskList[editNum]);
            mainForm.RefreshTaskPanel();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
