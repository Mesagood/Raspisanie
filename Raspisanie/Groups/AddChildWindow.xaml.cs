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
    public partial class AddChildWindow : Window
    {
        RaspisanieEntities db = new RaspisanieEntities();
        DispatcherTimer time;

        public AddChildWindow()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            time.Tick += new EventHandler(Time_Tick);
            time.Interval = new TimeSpan(0, 0, 2);
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            Child child = new Child();

            if (FirstNameChild.Text == "" || LastNameChild.Text == "" || DateOfBird.SelectedDate == null
                || FirstNameParent.Text == "" || LastNameParent.Text == "" || TelephoneNumber.Text == ""
                || Pfdo.Text =="" || ProgramTB.Text =="" || ClassTB.Text == "" || Shift.Text == "" || EducatorTB.Text == "")
            {
                Finally.Visibility = Visibility.Hidden;
                NotAll.Visibility = Visibility.Visible;
                time.Start();
            }
            else
            {
                try
                {
                    child.first_name_child = FirstNameChild.Text;
                    child.last_name_child = LastNameChild.Text;
                    child.middle_name_child = MiddleNameChild.Text;
                    child.data_of_bird = Convert.ToDateTime(DateOfBird.SelectedDate);
                    child.first_name_parent = FirstNameParent.Text;
                    child.last_name_parent = LastNameParent.Text;
                    child.middle_name_parent = MiddleNameParent.Text;
                    child.telephone_parent = TelephoneNumber.Text;
                    child.SNILS = Snils.Text;
                    child.PFDO = Convert.ToInt64(Pfdo.Text);
                    child.program = ProgramTB.Text;
                    child.@class = int.Parse(ClassTB.Text);
                    child.shift = int.Parse(Shift.Text);
                    child.school = School.Text;
                    child.address = AddressTB.Text;
                    child.educator = int.Parse(EducatorTB.Text);
                    child.Status = "true";
                    db.Child.Add(child);
                    db.SaveChanges();
                    Cleaner();
                    NotAll.Visibility = Visibility.Hidden;
                    Finally.Visibility = Visibility.Visible;
                    time.Start();
                }
                catch (Exception)
                {
                    Error_.Visibility = Visibility.Visible;
                    Cleaner();
                }
            }
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            Finally.Visibility = Visibility.Hidden;
            NotAll.Visibility = Visibility.Hidden;
            time.IsEnabled = false;
        }

        private void CancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cleaner()
        {
            FirstNameChild.Clear();
            LastNameChild.Clear();
            MiddleNameChild.Clear();
            FirstNameParent.Clear();
            LastNameParent.Clear();
            MiddleNameParent.Clear();
            TelephoneNumber.Clear();
            Snils.Clear();
            Pfdo.Clear();
            ProgramTB.Clear();
            ClassTB.Clear();
            Shift.Clear();
            School.Clear();
            AddressTB.Clear();
            EducatorTB.Clear();
        }
    }
}
