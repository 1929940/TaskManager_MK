using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Windows;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> List;
        public MainWindow()
        {
            InitializeComponent();

            PrepareBind();

            CollectionView View = 
                (CollectionView)CollectionViewSource.GetDefaultView(Display_ListView.ItemsSource);

            View.Filter = MyFilter;
        }


        public void PrepareBind()
        {
            List = new ObservableCollection<Task>();
            List.Add(new Task(1, "dlugi teks do 100 znakow", Priorities.Normal, Statuses.InProgress));
            List.Add(new Task(2, "kolejny tekst nie wiem po co ale jest hehe", Priorities.High, Statuses.Completed));
            List.Add(new Task(1, "testujemy date teraz", Priorities.Low, Statuses.New, new DateTime(2019,12,27)));
            Display_ListView.ItemsSource = List;

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.Show();
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {
            Task tmp = Display_ListView.SelectedItem as Task;

            Edit editWindow = new Edit(tmp);
            editWindow.Show();
        }

        private void Display_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Can we ever unselect an item? Perhaps after deleting

            if (Display_ListView.SelectedItem != null)
            {
                Modify_Button.IsEnabled = true;
            }
        }

        private void Filter_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Display_ListView.ItemsSource).Refresh();
        }

        public bool MyFilter(object item)
        {
            if (String.IsNullOrEmpty(Filter_TextBox.Text)) return true;
            else
            {
                // Searches for match in each of the four columns

                bool DescriptionFilter = ((item as Task).Description.IndexOf(
                    Filter_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

                bool StatusFilter = ((item as Task).Status.ToString().IndexOf(
                    Filter_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

                bool PriorityFilter = ((item as Task).Priority.ToString().IndexOf(
                    Filter_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

                bool DeadlineFilter = ((item as Task).Deadline.ToString().IndexOf(
                    Filter_TextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

                // If finds any matches, returns true

                return (DescriptionFilter || StatusFilter || PriorityFilter || DeadlineFilter);
            }
        }

        private void Task_Header_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Line Clicked");
        }
    }
}
