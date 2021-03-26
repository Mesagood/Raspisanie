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

namespace Raspisanie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Users> users = new List<Users>();

        public MainWindow()
        {
            InitializeComponent();
            users = Helper.db.Users.ToList();
            Load();

        }
        private void Load()
        {            
            //UserListView.ItemsSource = Helper.db.Users.ToList();
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            AddChild addChild = new AddChild();
            addChild.ShowDialog();
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FormAGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisbandGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddLession_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTeacher_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteLession_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
