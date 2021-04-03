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
    /// Логика взаимодействия для AddRecordWindow.xaml
    /// </summary>
    public partial class AddRecordWindow : Window
    {
        RaspisanieEntities db = new RaspisanieEntities();
        DispatcherTimer time;
        public AddRecordWindow()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            time.Tick += new EventHandler(Time_Tick);
            time.Interval = new TimeSpan(0, 0, 2);
            LoadLess();
            LoadGroup();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime;
            if (DateTime.TryParse(DateTimeLess.Text, out dateTime))
            {
                Group asd = GroupCB.SelectedItem as Group;
                Lessions lessions = LessionCB.SelectedItem as Lessions;

                
                var query = (from gc in db.Group_Child
                             where gc.FK_id_group == asd.IdGroup
                             select gc).ToList();
                for (int i = 0; i < query.Count(); i++)
                {
                    Lession_Child lession_Child = new Lession_Child
                    {
                        id_group_child = query[i].id_group_child,
                        FK_id_Lession = lessions.IdLessions,
                        numder_classroom = int.Parse(NumberCub.Text),
                        date_time_child = Convert.ToDateTime(DateTimeLess.Text)
                    };
                    db.Lession_Child.Add(lession_Child);
                    db.SaveChanges();
                }
                NotAll.Visibility = Visibility.Hidden;
                Fine.Visibility = Visibility.Visible;
                time.Start();
            }
            else
            {
                NotAll.Visibility = Visibility.Visible;
                Fine.Visibility = Visibility.Hidden;
                time.Start();
            }

        }

        private void LoadLess()
        {
            var quer = from l in db.Lessions
                       where l.Status == "true"
                       select l;

            LessionCB.ItemsSource = quer.ToList();
        }
        private void LoadGroup()
        {
            var quer = from g in db.Group
                       where g.Status == "true"
                       select g;

            GroupCB.ItemsSource = quer.ToList();
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            Fine.Visibility = Visibility.Hidden;
            NotAll.Visibility = Visibility.Hidden;
            time.IsEnabled = false;
        }
    }
}





