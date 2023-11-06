using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ToDoListForm1_0
{
    public partial class MainForm : Form
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TodoDB.mdf;Integrated Security=True";

        int listID; //Represents the current Task List.

        public List<Task> taskList = new List<Task>(); //Stores a list of Task objects.
        public List<(int, string)> listRefs = new List<(int, string)>(); //ID-Name Tuples for Lists.

        Font stdFont = new Font("Arial", 12);
        Size taskSize = new Size(488, 36);
        Size listSize = new Size(184, 20);

        public MainForm()
        {
            InitializeComponent();
            ScanLists();
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

        private void NewListClick(object sender, EventArgs e)
        {
            NewList();
            ScanLists();
        }

        private void NewTaskClick(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            taskForm.mainForm = this;
            taskForm.ShowDialog();
            taskFlow.Invalidate();
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            SaveTaskList();
            ScanLists();
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete This List?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                RemoveList();
                ScanLists();
                TaskPanelVisible(false);
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
            taskFlow.Invalidate();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertList = "INSERT INTO TaskList (list_name) VALUES ('New List'); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(insertList, connection))
                {
                    listID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            listFlow.Invalidate();
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
        /// Adds each Task in the current Task List to the taskList.
        /// </summary>
        private void FillTasks()
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

        /// <summary>
        /// Scans the Database for Task Lists.
        /// </summary>
        private void ScanLists()
        {
            listRefs.Clear();
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
                            listRefs.Add((id, name));
                        }
                    }
                }
            }
            listFlow.Invalidate();
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

        public void TaskPanelClick(object sender, MouseEventArgs e)
        {
            int i = e.Y / taskSize.Height;
            if (i < taskList.Count)
            {
                if (e.X < taskSize.Height)
                {
                    taskList[i].Check = !taskList[i].Check;
                }
                else if (e.X > taskSize.Width * 3 / 4)
                {
                    TaskForm taskForm = new TaskForm(taskList[i], i);
                    taskForm.mainForm = this;
                    taskForm.ShowDialog();
                }
                taskFlow.Invalidate();
            }
        }

        private void ListPanelClick(object sender, MouseEventArgs e)
        {
            int i = e.Y / listSize.Height;
            if (i < listRefs.Count)
            {
                if (e.X < listSize.Width * 3 / 4)
                {
                    listnameBox.Text = listRefs[i].Item2;
                    listID = listRefs[i].Item1;
                    TaskPanelVisible(true);
                    taskList.Clear();
                    FillTasks();
                    taskFlow.Invalidate();
                    listFlow.Invalidate();
                }
            }
        }

        public void DrawTaskPanel(object sender, PaintEventArgs e)
        {
            int width = taskSize.Width;
            int height = taskSize.Height;
            for (int i = 0; i < taskList.Count; i++)
            {
                Rectangle rect = new Rectangle(0, i * height, width, height);
                Rectangle checkRect = new Rectangle(0, i * height, height, height);
                Rectangle showRect = new Rectangle(width * 3 / 4, i * height, width * 1 / 4, height);
                string check = taskList[i].Check ? "V" : " ";
                e.Graphics.DrawRectangle(Pens.Gray, rect);
                e.Graphics.DrawRectangle(Pens.Gray, checkRect);
                e.Graphics.DrawRectangle(Pens.Gray, showRect);
                e.Graphics.DrawString(check, stdFont, Brushes.Green, 10, i * height + 10);
                e.Graphics.DrawString(taskList[i].Label, stdFont, Brushes.Black, height + 5, i * height + 10);
                e.Graphics.DrawString("Show", stdFont, Brushes.Black, width * 3 / 4 + 5, i * height + 10);
            }
        }

        public void DrawListPanel(object sender, PaintEventArgs e)
        {
            int width = listSize.Width;
            int height = listSize.Height;
            int a = -1;
            for (int i = 0; i < listRefs.Count; i++)
            {
                if (listRefs[i].Item1 == listID) a = i;
                else
                {
                    Rectangle rect = new Rectangle(0, i * height, width, height);
                    e.Graphics.DrawRectangle(Pens.Gray, rect);
                    e.Graphics.DrawString(listRefs[i].Item2, stdFont, Brushes.Black, 4, i * height + 4);
                }
            }
            if (a != -1)
            {
                Rectangle aRect = new Rectangle(0, a * height, width, height);
                e.Graphics.DrawRectangle(Pens.Green, aRect);
                e.Graphics.DrawString(listRefs[a].Item2, stdFont, Brushes.Green, 2, a * height + 2);
            }
        }
    }

    public class Task
    {
        public string Label { get; set; }
        public bool Check { get; set; }
        public string Details { get; set; }

        public Task() { }

        public Task(string label, bool check, string details)
        {
            Label = label;
            Check = check;
            Details = details;
        }
    }
}
