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
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> List;
        public MainWindow()
        {
            InitializeComponent();

            PrepareBind();

            CollectionView View = 
                (CollectionView)CollectionViewSource.GetDefaultView(Display_DataGrid.ItemsSource);

            View.Filter = MyFilter;
        }


        public void PrepareBind()
        {
            List = new ObservableCollection<Task>();
            List.Add(new Task(1, "dlugi teks do 100 znakow", "Normal", "In Progress"));
            List.Add(new Task(2, "kolejny tekst nie wiem po co ale jest hehe", "High", "Completed"));
            List.Add(new Task(3, "testujemy date teraz", "Low", "New", new DateTime(2019,12,27)));
            List.Add(new Task(4, "Lets play a game. I am here, coding, and its hot outside. Why am i doing this to myself?", "High", "In Progress", DateTime.MinValue));
            Display_DataGrid.ItemsSource = List;

        }



        #region Filter

        private void Filter_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Display_DataGrid.ItemsSource).Refresh();

            // Filter allows to deselect a row
            // When the selected row is deselected by filter
            // Block access to buttons that require a selected item

            if (Display_DataGrid.SelectedItem == null)
            {
                Modify_Button.IsEnabled = false;
                Remove_Button.IsEnabled = false;
            }
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

        #endregion

        #region Buttons

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.ShowDialog();
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {
            Modify();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify()
        {
            Task tmp = Display_DataGrid.SelectedItem as Task;

            Edit editWindow = new Edit(tmp);
            editWindow.ShowDialog();
        }

        private void Display_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Can we ever unselect an item? Perhaps after deleting

            if (Display_DataGrid.SelectedItem != null)
            {
                Modify_Button.IsEnabled = true;
                Remove_Button.IsEnabled = true;
            }
        }

        private void Display_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Modify();
        }

        #endregion


    }
}
