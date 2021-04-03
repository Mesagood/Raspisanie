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
    /// Логика взаимодействия для AddLessionWindow.xaml
    /// </summary>
    public partial class AddLessionWindow : Window
    {
        RaspisanieEntities db = new RaspisanieEntities();
        DispatcherTimer time;
        public AddLessionWindow()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            time.Tick += new EventHandler(Time_Tick);
            time.Interval = new TimeSpan(0, 0, 2);
            Load();
        }

        

        private void Load()
        {
            var quer = from l in db.Lessions
                       where l.Status == "true"
                       select l;
            LessGrid.ItemsSource = quer.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Lessions lessions = new Lessions();
            if (NameLessTB.Text == "")
            {
                Finally.Visibility = Visibility.Hidden;
                NotAll.Visibility = Visibility.Visible;

                time.Start();
            }
            else
            {
                try
                {
                    lessions.NameLessions = NameLessTB.Text;
                    lessions.Status = "true";
                    db.Lessions.Add(lessions);
                    db.SaveChanges();
                    NotAll.Visibility = Visibility.Hidden;
                    Finally.Visibility = Visibility.Visible;
                    time.Start();
                    Load();
                }
                catch (Exception)
                {
                    Error_.Visibility = Visibility.Visible;
                    Cleaner();
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
                Lessions lessions = (Lessions)LessGrid.SelectedItem;
                lessions.Status = "false";
                db.SaveChanges();
                Load();
            }
            else
            {

            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            Finally.Visibility = Visibility.Hidden;
            NotAll.Visibility = Visibility.Hidden;
            time.IsEnabled = false;
        }

        private void Cleaner()
        {
            NameLessTB.Clear();
        }
    }
}
