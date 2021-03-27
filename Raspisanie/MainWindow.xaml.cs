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
        RaspisanieEntities db = new RaspisanieEntities();

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            
            var lessionchildren = from lc in db.Lession_Child
                                  join gc in db.Group_Child on lc.id_group_child equals gc.id_group_child
                                  join l in db.Lessions on lc.FK_id_Lession equals l.IdLessions
                                  select new
                                  {
                                      gc.id_group_child,
                                      l.NameLessions,
                                      lc.numder_classroom,
                                      lc.date_time_child
                                  };
            RaspisanieGrid.ItemsSource = lessionchildren.ToList();
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
