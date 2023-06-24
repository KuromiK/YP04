using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

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
            int ye;
            ye = DateTime.Now.Year;
            year_hell.Text = ye.ToString();
            Abiturient.YearEntry = ye;
            DialogResult = true;

            /*
                bool tmp = String.IsNullOrEmpty(Abiturient.FirstName);
                tmp = String.IsNullOrEmpty(Abiturient.SecondName);
                tmp = String.IsNullOrEmpty(Abiturient.Patronymic);
                tmp = String.IsNullOrEmpty(Abiturient.Gender);
                tmp = String.IsNullOrEmpty(Abiturient.DateBirthday.ToString());
                tmp = String.IsNullOrEmpty(Abiturient.Nationality);
                tmp = String.IsNullOrEmpty(Abiturient.PlaceLive);
                tmp = String.IsNullOrEmpty(Abiturient.FinishSchool);
                tmp = String.IsNullOrEmpty(Abiturient.AttestatRating.ToString());
                tmp = String.IsNullOrEmpty(Abiturient.Snils.ToString());
                tmp = String.IsNullOrEmpty(Abiturient.Speciality);
                tmp = String.IsNullOrEmpty(Abiturient.Budget);
                tmp = String.IsNullOrEmpty(Abiturient.Enrollment);
                if (tmp)
                {
                    MessageBox.Show("Заполните поле ЗАЧИСЛЕНИЕ");
                }
                else
                    DialogResult = true;
            */
        }
        
        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Content.Equals("Женский     "))
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
            if (pressed.Content.Equals("Зачислен     "))
            {
                Abiturient.Enrollment = "Зачислен";
            }
            else
            {
                Abiturient.Enrollment = "Не зачислен";
            }
        }
        private void bud1_Click(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Content.Equals("Бюджет       "))
            {
                Abiturient.Budget = "Бюджет";
            }
            else
            {
                Abiturient.Budget = "Договор об оказании плат. образ. услуг";
            }
        }
        private void RadioButtonSchool_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            Drugoe_obr.IsEnabled = false;
            if (pressed.Content.Equals("9     "))
            {
                Abiturient.FinishSchool = "9";
            }
            else if (pressed.Content.Equals("11    "))
            {
                Abiturient.FinishSchool = "11";
            }
            else if (pressed.Content.Equals("Другое:"))
            {
                Drugoe_obr.IsEnabled = true;
            }
        }

        private void especiality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock text = (TextBlock)speciality_list.SelectedItem;
            Abiturient.Speciality = text.Text;
        }
        
        private void nationality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock text = (TextBlock)nationality_list.SelectedItem;
            Abiturient.Nationality = text.Text;
        }
        
        private void placeLive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock text = (TextBlock)subject_list.SelectedItem;
            if (text.Text == "Костромская область")
            {
                kostroma_list.IsEnabled = true;
                TextBlock text2 = (TextBlock)kostroma_list.SelectedItem;
                text_kostroma.Text = "Выберите район Костромы:";

            }
            else
            {
                Abiturient.PlaceLive = text.Text;
                kostroma_list.IsEnabled = false;
                text_kostroma.Text = " ";
            }

        }
        private void kostroma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock text = (TextBlock)kostroma_list.SelectedItem;
            Abiturient.PlaceLive = "Костромская область-" + text.Text;
        }

        private void arrivalCalendarDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            DateTime date = arrivalCalendarDatePicker.SelectedDate.Value;
            Abiturient.DateBirthday = date.ToString();
            DateTime age = DateTime.Now;
            int tmp = age.Year - date.Year;
            if (date > age.AddYears(0 - tmp))
                tmp--;
            age_label.Text = tmp.ToString();
        }

        private void RadioButtonInvalid_Checked(object sender, RoutedEventArgs e) 
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Content.Equals("Есть:"))
            {
                scan_invalid.IsEnabled = true;

            }
            else
                scan_invalid.IsEnabled = false;
        }
        private void RadioButtonOrphan_Checked(object sender, RoutedEventArgs e) 
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Content.Equals("Есть:"))
            {
                scan_orphan.IsEnabled = true;
            }
            else
                scan_orphan.IsEnabled = false;
        }

        private void scan_invalid_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Выберите файл";

            openFileDialog.Filter = "Файлы изображения (*.jpg, *.jpeg, *-png)|*.jpg;*-jpeg;*-png|Bce dalinu (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                selectedFile = openFileDialog.FileName;

            byte[]? attFile = File.ReadAllBytes(selectedFile);
            Abiturient.InvalidScan = attFile;

        }
        private void scan_orphan_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Выберите файл";

            openFileDialog.Filter = "Файлы изображения (*.jpg, *.jpeg, *-png)|*.jpg;*-jpeg;*-png|Bce dalinu (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                selectedFile = openFileDialog.FileName;

            byte[]? attFile = File.ReadAllBytes(selectedFile);
            Abiturient.OrphanScan = attFile;

        }
        private void scan_attestat_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Выберите файл";

            openFileDialog.Filter = "Файлы изображения (*.jpg, *.jpeg, *-png)|*.jpg;*-jpeg;*-png|Bce dalinu (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                selectedFile = openFileDialog.FileName;

            byte[]? attFile = File.ReadAllBytes(selectedFile);
            Abiturient.AttestatScan = attFile;

        }
    }
}
