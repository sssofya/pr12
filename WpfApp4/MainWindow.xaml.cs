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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        trenyaEntities Db;
        List<Clients> TableClient;
        public MainWindow()
        {
            InitializeComponent();
            Db = new trenyaEntities();
            TableClient = Db.Clients.ToList();
            TableGrid.ItemsSource = TableClient;
        }
        private void RefreshDataGrid()
        {
            TableGrid.ItemsSource = Db.Clients.ToList();
            TableGrid.Items.Refresh();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Search = Db.Clients.ToList();
            Search = Search.Where(x => x.FirstName.ToLower().StartsWith(SearchBox.Text.ToLower()) ||
            x.MiddleName.ToLower().StartsWith(SearchBox.Text.ToLower())).ToList();
            TableGrid.ItemsSource = Search.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var Nw = new Clients();
            Db.Clients.Add(Nw);
            Window1 Add = new Window1(Db, Nw);
            Add.ShowDialog();
            RefreshDataGrid();
        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            Db = new trenyaEntities();
            Clients Item = TableGrid.SelectedItem as Clients;
            Clients Del = Db.Clients.Where(D => D.ClientID == Item.ClientID).Single();
            Db.Clients.Remove(Del);
            Db.SaveChanges();
            MessageBox.Show("Клиент удален успешно!");
            RefreshDataGrid();
        }
    }
}

