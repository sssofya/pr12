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


namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        trenyaEntities Db;
        public Window1(trenyaEntities Db, Clients T)
        {
            InitializeComponent();
            this.Db = Db;
            this.DataContext = T;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Клиент успешно добавлен!");
            Db.SaveChanges();
        }

        private void CloseButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
