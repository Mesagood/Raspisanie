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

namespace Raspisanie
{
    /// <summary>
    /// Логика взаимодействия для AddChild.xaml
    /// </summary>
    public partial class AddChild : Window
    {
        RaspisanieEntities db = new RaspisanieEntities();

        public AddChild()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            var ene = from i in db.TEST
                      where i.Status == "true"
                      select i;

            testgrid.ItemsSource = ene.ToList();

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            TEST t = new TEST();
            t.Name = addname.Text;
            t.Status = "true";
            db.TEST.Add(t);

            db.SaveChanges();
            MessageBox.Show("Add");
            Load();
        }


        private void del_Click(object sender, RoutedEventArgs e)
        {

            TEST T = (TEST)testgrid.SelectedItem;
            T.Status = "false";           
            db.SaveChanges();
            MessageBox.Show("DEL");
            Load();
        }


        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }


    }
}
