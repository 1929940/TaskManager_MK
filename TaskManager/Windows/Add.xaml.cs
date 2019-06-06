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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();

            Status_ComboBox.ItemsSource = Enum.GetValues(typeof(Statuses)).Cast<Statuses>();

            Status_ComboBox.SelectedItem = Statuses.Nowy;

            

            Priority_ComboBox.ItemsSource = Enum.GetValues(typeof(Priorities)).Cast<Priorities>();

            Priority_ComboBox.SelectedItem = Priorities.Normalny;
        }

        private void TextChange(object sender, TextChangedEventArgs e)
        {
            int counter = 0;

            counter = 1000 - Description_TextBox.Text.Length;

            if (counter == 0)
            {
                WordCount.Opacity = 1;
                WordCount.Foreground = Brushes.Red;

                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                WordCount.Opacity = 0.3;
                WordCount.Foreground = Brushes.Black;
            }
            WordCount.Content = counter;

        }
    }
}
