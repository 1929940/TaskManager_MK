using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskManager.Windows
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit(Task selected)
        {
            InitializeComponent();
            
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

        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
