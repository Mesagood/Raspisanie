using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Raspisanie.Groups
{
 
    public partial class FormGroupWindow : Window
    {
        RaspisanieEntities db = new RaspisanieEntities();
        DispatcherTimer time;
        public FormGroupWindow()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            time.Tick += new EventHandler(Time_Tick);
            time.Interval = new TimeSpan(0, 0, 2);
            LoadChild();
            LoadGroup();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (CBChild != null && CBGroup != null)
            {
                Child child = CBChild.SelectedItem as Child;
                Group group = CBGroup.SelectedItem as Group;
                Group_Child group_Child = new Group_Child();

                try
                {
                    group_Child.FK_id_group = group.IdGroup;
                    group_Child.FK_id_child = child.id_child;
                    db.Group_Child.Add(group_Child);
                    db.SaveChanges();
                    NotAll.Visibility = Visibility.Hidden;
                    Fine.Visibility = Visibility.Visible;
                    time.Start();
                }
                catch (Exception)
                {
                    Fine.Visibility = Visibility.Hidden;
                    NotAll.Visibility = Visibility.Visible;
                    time.Start();
                }

            }
            else
            {
                Fine.Visibility = Visibility.Hidden;
                NotAll.Visibility = Visibility.Visible;
                time.Start();
            }

        }

        private void LoadChild()
        {
            var quer = from c in db.Child
                       where c.Status == "true"
                       select c;
            CBChild.ItemsSource = quer.ToList();
        }
        private void LoadGroup()
        {
            var quer = from g in db.Group
                       where g.Status == "true"
                       select g;
            CBGroup.ItemsSource = quer.ToList();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            Fine.Visibility = Visibility.Hidden;
            NotAll.Visibility = Visibility.Hidden;
            time.IsEnabled = false;
        }
    }
}
