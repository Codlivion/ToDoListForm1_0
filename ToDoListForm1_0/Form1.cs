using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListForm1_0
{
    public partial class MainForm : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TodoDB.mdf;Integrated Security=True";

        int listID; //Represents the current Task List.

        public List<Task> taskList = new List<Task>(); //Stores a list of Task objects.
        public List<Button> listRefs = new List<Button>(); //Stores the Controls created.
        List<SplitContainer> taskContainers = new List<SplitContainer>(); //Stores the Controls created.

        Font stdFont = new Font("Arial", 12);
        Size splitSize = new Size(488, 36);
        Size listSize = new Size(184, 20);

        public MainForm()
        {
            InitializeComponent();
            ScanTaskLists();
            TaskPanelVisible(false);
        }

        /// <summary>
        /// Hide and Show the Controls related to creating Tasks.
        /// </summary>
        /// <param name="visible">Set true to show and false to hide.</param>
        private void TaskPanelVisible(bool visible)
        {
            buttonsSplit.Visible = visible;
            listnameSplit.Visible = visible;
            taskFlow.Visible = visible;
        }

        private void newlistButton_Click(object sender, EventArgs e)
        {
            NewList();
            ScanTaskLists();
        }

        private void ListRef_Click(object sender, EventArgs e)
        {
            Button listRef = sender as Button;
            listnameBox.Text = listRef.Text;
            listID = Convert.ToInt32(listRef.Tag);
            TaskPanelVisible(true);
            taskList.Clear();
            FillTaskList();
            RefreshTaskPanel();
        }

        /// <summary>
        /// Adds each Task in the current Task List to the taskList.
        /// </summary>
        private void FillTaskList()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT task_label, task_check, task_details FROM Task WHERE list_ID = @list_ID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@list_ID", listID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string label = reader.GetString(0);
                            bool check = reader.GetBoolean(1);
                            string details = reader.GetString(2);
                            Task task = new Task(label, check, details);
                            taskList.Add(task);
                        }
                    }
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SaveTaskList();
            ScanTaskLists();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete This List?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RemoveList();
                ScanTaskLists();
                TaskPanelVisible(false);
            }
        }

        /// <summary>
        /// Deletes the current Task List.
        /// </summary>
        private void RemoveList()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteList = "DELETE FROM TaskList WHERE list_ID = @list_ID;";
                using (SqlCommand command = new SqlCommand(deleteList, connection))
                {
                    command.Parameters.AddWithValue("@list_ID", listID);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Creates an empty new Task List.
        /// </summary>
        private void NewList()
        {
            TaskPanelVisible(true);
            listnameBox.Text = "New List";
            taskList.Clear();
            RefreshTaskPanel();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertList = "INSERT INTO TaskList (list_name) VALUES ('New List'); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(insertList, connection))
                {
                    listID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Scans the Database for Task Lists and rearranges the Panel on the left to show them properly.
        /// </summary>
        private void ScanTaskLists()
        {
            List<KeyValuePair<int, string>> idNames = new List<KeyValuePair<int, string>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT list_ID, list_name FROM TaskList;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            idNames.Add(new KeyValuePair<int, string>(id, name));
                        }
                    }
                }
            }

            if (listRefs.Count(c => c.Visible) > idNames.Count)
            {
                for (int i = listRefs.Count(c => c.Visible) - 1; i >= idNames.Count; i--)
                {
                    listRefs[i].Tag = 0;
                    listRefs[i].Text = "";
                    listRefs[i].Visible = false;
                }
            }

            for (int i = 0; i < idNames.Count; i++)
            {
                if (i < listRefs.Count)
                {
                    listRefs[i].Visible = true;
                    listRefs[i].Tag = idNames[i].Key;
                    listRefs[i].Text = idNames[i].Value;
                }
                else
                {
                    CreateListRef(idNames[i].Key, idNames[i].Value);
                }
            }
        }

        /// <summary>
        /// Pushes the current Task List and it's Tasks into the Database.
        /// </summary>
        public void SaveTaskList()
        {
            if (listID == 0) return;

            string listName = listnameBox.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateList = "UPDATE TaskList SET list_name = @list_name WHERE list_ID = @list_ID;";
                using (SqlCommand command = new SqlCommand(updateList, connection))
                {
                    command.Parameters.AddWithValue("@list_name", listName);
                    command.Parameters.AddWithValue("@list_ID", listID);
                    command.ExecuteNonQuery();
                }

                string deleteTasks = "DELETE FROM Task WHERE list_ID = @list_ID;";
                using (SqlCommand command = new SqlCommand(deleteTasks, connection))
                {
                    command.Parameters.AddWithValue("@list_ID", listID);
                    command.ExecuteNonQuery();
                }

                string insertTasks = "INSERT INTO Task(list_ID, task_label, task_check, task_details)" +
                "VALUES (@list_ID, @task_label, @task_check, @task_details);";
                using (SqlCommand command = new SqlCommand(insertTasks, connection))
                {
                    foreach (Task task in taskList)
                    {
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@list_ID", listID);
                        command.Parameters.AddWithValue("@task_label", task.Label);
                        command.Parameters.AddWithValue("@task_check", task.Check);
                        command.Parameters.AddWithValue("@task_details", task.Details);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Creates a Button to reference the a Task List.
        /// </summary>
        /// <param name="id">Task List's list_ID in the Database.</param>
        /// <param name="name">Task List's list_name in the Database.</param>
        private void CreateListRef(int id, string name)
        {
            Button listRef = new Button
            {
                Dock = DockStyle.None,
                AutoSize = false,
                Size = listSize,
                Tag = id,
                Text = name
            };
            listRef.Click += ListRef_Click;
            listFlow.Controls.Add(listRef);
            listRefs.Add(listRef);
        }

        /// <summary>
        /// Creates a new Container with a Checkbox and a Button inside, placed in a FlowLayoutPanel.
        /// </summary>
        /// <param name="task">Task object to be referenced.</param>
        public void NewTaskBox(Task task)
        {
            SplitContainer taskContainer = new SplitContainer
            {
                Size = splitSize,
                SplitterDistance = 388
            };
            taskFlow.Controls.Add(taskContainer);
            taskContainers.Add(taskContainer);
            CheckBox taskBox = new CheckBox
            {
                Dock = DockStyle.Fill,
                Font = stdFont,
                Tag = taskContainers.IndexOf(taskContainer),
                Text = task.Label,
                Checked = task.Check
            };
            taskBox.Click += TaskBox_Click;
            taskContainer.Panel1.Controls.Add(taskBox);
            Button showButton = new Button
            {
                Dock = DockStyle.Fill,
                Font = stdFont,
                Tag = taskContainers.IndexOf(taskContainer),
                Text = "Show",
            };
            showButton.Click += showButton_Click;
            taskContainer.Panel2.Controls.Add(showButton);
        }

        /// <summary>
        /// Rearranges the Controls so the current taskList is shown properly.
        /// </summary>
        public void RefreshTaskPanel()
        {
            if (taskContainers.Count(c => c.Visible) > taskList.Count)
            {
                for (int i = taskContainers.Count - 1; i >= taskList.Count; i--)
                {
                    CheckBox taskBox = taskContainers[i].Panel1.Controls[0] as CheckBox;
                    taskBox.Text = "";
                    taskBox.Checked = false;
                    taskContainers[i].Visible = false;
                }
            }

            for (int i = 0; i < taskList.Count; i++)
            {
                if (i < taskContainers.Count)
                {
                    taskContainers[i].Visible = true;
                    CheckBox taskBox = taskContainers[i].Panel1.Controls[0] as CheckBox;
                    taskBox.Text = taskList[i].Label;
                    taskBox.Checked = taskList[i].Check;
                }
                else
                {
                    NewTaskBox(taskList[i]);
                }
            }
        }

        private void newtaskButton_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            taskForm.mainForm = this;
            taskForm.ShowDialog();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int i = Convert.ToInt32(button.Tag);
            TaskForm taskForm = new TaskForm(taskList[i], i);
            taskForm.mainForm = this;
            taskForm.ShowDialog();
        }

        private void TaskBox_Click(object sender, EventArgs e)
        {
            CheckBox taskBox = sender as CheckBox;
            int i = Convert.ToInt32(taskBox.Tag);
            taskList[i].Check = taskBox.Checked;
        }
    }

    /// <summary>
    /// Task object.
    /// </summary>
    public class Task
    {
        public string Label { get; set; }
        public bool Check { get; set; }
        public string Details { get; set; }

        public Task()
        {
            Label = string.Empty;
            Check = false;
            Details = string.Empty;
        }

        public Task(string label, bool check, string details)
        {
            Label = label;
            Check = check;
            Details = details;
        }
    }
}
