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


        }
        public void PrepareBind()
        {
            List = new ObservableCollection<Task>();
            List.Add(new Task(1, "dlugi teks do 100 znakow", Priorities.Normalny, Statuses.wRealizacji));
            List.Add(new Task(2, "kolejny tekst nie wiem po co ale jest hehe", Priorities.Wysoki, Statuses.Zakonczony));
            List.Add(new Task(1, "testujemy date teraz", Priorities.Niski, Statuses.Nowy, new DateTime(2019,12,27)));
            Display_ListView.ItemsSource = List;

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.Show();
            
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            //Edit editWindow = new Edit(this);
            //editWindow.show();
        }
    }
}
