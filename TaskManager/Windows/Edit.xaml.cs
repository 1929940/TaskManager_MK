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
            


            Description_TextBox.Text = selected.Description;

            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(Statuses)).Cast<Statuses>();

            Status_ComboBox.SelectedItem = selected.Status;

            Priority_ComboBox.ItemsSource = Enum.GetValues(typeof(Priorities)).Cast<Priorities>();

            Priority_ComboBox.SelectedItem = selected.Priority;

            if (selected.Deadline != DateTime.MinValue)
            {
                DatePicker.SelectedDate = selected.Deadline;
            }
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            DescriptionHelpers.ValidateTextbox(Description_TextBox, WordCount);
        }
    }
}
