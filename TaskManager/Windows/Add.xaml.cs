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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManager.Models;

namespace TaskManager.Windows
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();

        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            DescriptionHelpers.ValidateTextbox(Description_TextBox, WordCount);

            Create_Button.IsEnabled  = (Description_TextBox.Text == String.Empty) ? false : true;

        }


        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            string desc = Description_TextBox.Text;
            string status = Status_ComboBox.Text;
            string priority = Priority_ComboBox.Text;
            DateTime? deadline = DatePicker.SelectedDate;


            TaskManagerDB.AddTask(desc, status, priority, deadline);

            

            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
