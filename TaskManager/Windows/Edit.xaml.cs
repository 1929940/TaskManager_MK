using System;
using System.Windows;
using System.Windows.Controls;
using TaskManager.Models;

namespace TaskManager.Windows
{
    public partial class Edit : Window
    {
        int id;

        public Edit(Task selected)
        {
            InitializeComponent();

            id = selected.Id;
            
            //Sets initial values of controls based on the selected item

            Description_TextBox.Text = selected.Description;

            switch (selected.Status)
            {
                case "New":
                    Status_ComboBox.SelectedIndex = 0;
                    break;
                case "In Progress":
                    Status_ComboBox.SelectedIndex = 1;
                    break;
                case "Completed":
                    Status_ComboBox.SelectedIndex = 2;
                    break;
            }

            switch (selected.Priority)
            {
                case "Low":
                    Priority_ComboBox.SelectedIndex = 0;
                    break;
                case "Normal":
                    Priority_ComboBox.SelectedIndex = 1;
                    break;
                case "High":
                    Priority_ComboBox.SelectedIndex = 2;
                    break;
            }

            if (selected.Deadline != DateTime.MinValue)
            {
                DatePicker.SelectedDate = selected.Deadline;
            }

        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            DescriptionHelpers.ValidateTextbox(Description_TextBox, WordCount);

            Modify_Button.IsEnabled = (Description_TextBox.Text == String.Empty) ? false : true;
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {
            string desc = Description_TextBox.Text;
            string status = Status_ComboBox.Text;
            string priority = Priority_ComboBox.Text;
            DateTime? deadline = DatePicker.SelectedDate;

            TaskManagerDB.ModifyTask(id, desc, status, priority, deadline);

            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
