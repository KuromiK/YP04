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

namespace YP04
{
    public partial class AbiturientWindow : Window
    {
        public Abiturient Abiturient { get; private set; }
        public AbiturientWindow(Abiturient abiturient)
        {
            InitializeComponent();
            Abiturient = abiturient;
            DataContext = Abiturient;
        }
        void Accept_click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }

        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Content.Equals("Женский"))
            {
                Abiturient.Gender = "Ж";
            }
            else
            {
                Abiturient.Gender = "М";
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Content.Equals("Зачислен"))
            {
                Abiturient.Enrollment = "Зачислен";
            }
            else
            {
                Abiturient.Enrollment = "Не зачислен";
            }
        }

        private void especiality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock text = (TextBlock)speciality_list.SelectedItem;
            Abiturient.Speciality = text.Text;
        }

        private void arrivalCalendarDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            DateTime date = arrivalCalendarDatePicker.SelectedDate.Value;
            Abiturient.DateBirthday = date;
            DateTime age = DateTime.Now;
            int tmp = age.Year - date.Year;
            if (date > age.AddYears(0 - tmp))
                tmp--;
            age_label.Text = tmp.ToString();
            Abiturient.Age = tmp;
        }
    }
}
