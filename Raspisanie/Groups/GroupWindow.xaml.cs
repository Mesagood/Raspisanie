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
using System.Windows.Threading;

namespace Raspisanie.Groups
{
    /// <summary>
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        RaspisanieEntities db = new RaspisanieEntities();
        DispatcherTimer time;
        public GroupWindow()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            time.Tick += new EventHandler(Time_Tick);
            time.Interval = new TimeSpan(0, 0, 2);
            Load();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            Finally.Visibility = Visibility.Hidden;
            NotAll.Visibility = Visibility.Hidden;
            time.IsEnabled = false;
        }

        private void Load()
        {           
            var quer = from g in db.Group
                       where g.Status == "true"
                       select g;
            GroupGrid.ItemsSource = quer.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Group group = new Group();
            if (NumberGroupTB.Text =="")
            {
                Finally.Visibility = Visibility.Hidden;
                NotAll.Visibility = Visibility.Visible;

                time.Start();
            }
            else
            {
                try
                {
                    group.NumGroup = int.Parse(NumberGroupTB.Text);
                    group.Status = "true";
                    db.Group.Add(group);
                    db.SaveChanges();
                    NotAll.Visibility = Visibility.Hidden;
                    Finally.Visibility = Visibility.Visible;
                    time.Start();
                    Load();
                }
                catch (Exception)
                {
                    Error_.Visibility = Visibility.Visible;
                    NumberGroupTB.Clear();                   
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                Group group = (Group)GroupGrid.SelectedItem;
                group.Status = "false";
                db.SaveChanges();
                Load();
            }
            else
            {

            }
        }
    }
}
