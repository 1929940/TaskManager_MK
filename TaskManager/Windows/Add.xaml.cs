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

            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(Statuses)).Cast<Statuses>();

            Status_ComboBox.SelectedItem = Statuses.New;



            Priority_ComboBox.ItemsSource = Enum.GetValues(typeof(Priorities)).Cast<Priorities>();

            Priority_ComboBox.SelectedItem = Priorities.Normal;
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            DescriptionHelpers.ValidateTextbox(Description_TextBox, WordCount);

            Create_Button.IsEnabled  = (Description_TextBox.Text == String.Empty) ? false : true;

        }


        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
