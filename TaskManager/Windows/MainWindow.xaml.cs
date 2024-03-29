﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.Windows;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PrepareDataGridBinding();
        }


        public void PrepareDataGridBinding()
        {
            Display_DataGrid.ItemsSource = TaskManagerDB.GetTasks();

            CollectionView View =
              (CollectionView)CollectionViewSource.GetDefaultView(Display_DataGrid.ItemsSource);

            View.Filter = MyFilter;
        }

        #region Filter

        private void Filter_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(Display_DataGrid.ItemsSource).Refresh();

            // Filter allows one to deselect a row
            // When that happens, the buttons get disabled

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

                // If the filtered phrase matches any of the columns contents, returns true

                return (DescriptionFilter || StatusFilter || PriorityFilter || DeadlineFilter);
            }
        }

        #endregion

        #region Buttons

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            ReSorter sorter = new ReSorter(Display_DataGrid);
            sorter.PrepareToReSort();


            Add addWindow = new Add();
            addWindow.ShowDialog();

            PrepareDataGridBinding();

            sorter.ReSort();
        }

        private void Modify_Button_Click(object sender, RoutedEventArgs e)
        {
            Modify();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to remove the selected task?", "Confirm removal", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (MessageBoxResult.No == result)
            {
                return;
            }


            ReSorter sorter = new ReSorter(Display_DataGrid);
            sorter.PrepareToReSort();

            Task tmp = Display_DataGrid.SelectedItem as Task;

            int index = Display_DataGrid.SelectedIndex;

            TaskManagerDB.RemoveTask(tmp.Id);

            PrepareDataGridBinding();

            // When a row is removed, another one is selected
            // If there are none left to be selected, buttons are disabled

            Display_DataGrid.SelectedIndex = index -1;

            if(Display_DataGrid.SelectedItem == null)
            {
                Modify_Button.IsEnabled = false;
                Remove_Button.IsEnabled = false;
            }
            sorter.ReSort();
        }

        private void Modify()
        {
            ReSorter sorter = new ReSorter(Display_DataGrid);
            sorter.PrepareToReSort();

            Task tmp = Display_DataGrid.SelectedItem as Task;

            Edit editWindow = new Edit(tmp);
            editWindow.ShowDialog();

            PrepareDataGridBinding();

            sorter.ReSort();
        }

        private void Display_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Buttons are disabled until a row is selected

            if (Display_DataGrid.SelectedItem != null)
            {
                Modify_Button.IsEnabled = true;
                Remove_Button.IsEnabled = true;
            }
        }

        private void Display_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(sender.GetType().Name);

            //if (sender is DataGridCell)
            //{
            //    Modify();
            //}

            //System.Diagnostics.Debug.WriteLine(tmp.ToString());

            //if (Display_DataGrid.SelectedItem == null) return;

            Modify();


            //DependencyObject src = System.Windows.Media.VisualTreeHelper.GetParent((DependencyObject)e.OriginalSource);

            //// Checks if the user double clicked on a row in the datagrid [ContentPresenter]
            //if (src.GetType() == typeof(ContentPresenter))
            //{
            //    // Your logic..
            //    Modify();
            //}
        }


        #endregion


    }
}
