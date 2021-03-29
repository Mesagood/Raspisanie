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

namespace Raspisanie.Groups
{
    /// <summary>
    /// Логика взаимодействия для ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        RaspisanieEntities db = new RaspisanieEntities();
        public ChildWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            var ene = from i in db.Child
                      where i.Status == "true"
                      select i;

            ChildGrid.ItemsSource = ene.ToList();

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            new AddChildWindow().ShowDialog();
            Load();
        }


        private void del_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show
                ("Вы действительно хотите удалить запись?",
                "Внимаение!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Child child = (Child)ChildGrid.SelectedItem;
                child.Status = "false";
                db.SaveChanges();
                Load();
            }
            else
            {
                
            }



            
        }


        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
