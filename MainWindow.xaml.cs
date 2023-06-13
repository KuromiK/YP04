using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace YP04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Abiturients.Load();
            DataContext = db.Abiturients.Local.ToObservableCollection();
        }
        private void Add_click(object sender, RoutedEventArgs e)
        {
            AbiturientWindow abiturientWindow = new AbiturientWindow(new Abiturient());
            if (abiturientWindow.ShowDialog() == true)
            {
                Abiturient Abiturient = abiturientWindow.Abiturient;
                db.Abiturients.Add(Abiturient);
                db.SaveChanges();
            }
        }
        private void Look_click(object sender, RoutedEventArgs e)
        {
            Abiturient? abiturient = ablist.SelectedItem as Abiturient;
            if (abiturient is null) return;
            AbiturientWindow abiturientWindow = new AbiturientWindow(new Abiturient
            {
                Id = abiturient.Id,
                FirstName = abiturient.FirstName,
                SecondName = abiturient.SecondName,
                Patronymic = abiturient.Patronymic,
                Speciality = abiturient.Speciality
            });
            if (abiturientWindow.ShowDialog() == true)
            {
                abiturient = db.Abiturients.Find(abiturientWindow.Abiturient.Id);
            }
        }
        private void Edit_click(object sender, RoutedEventArgs e) 
        {
            Abiturient? abiturient = ablist.SelectedItem as Abiturient;
            if (abiturient is null) return;
            AbiturientWindow AbiturientWindow = new AbiturientWindow (new Abiturient
            {
                Id = abiturient.Id,
                FirstName = abiturient.FirstName,
                SecondName = abiturient.SecondName,
                Patronymic = abiturient.Patronymic,
                Speciality = abiturient.Speciality
            });
            if (AbiturientWindow.ShowDialog() == true)
            {
                abiturient = db.Abiturients.Find(AbiturientWindow.Abiturient.Id);
                if (abiturient != null)
                {
                    abiturient.FirstName = AbiturientWindow.Abiturient.FirstName;
                    abiturient.SecondName = AbiturientWindow.Abiturient.SecondName;
                    abiturient.Speciality = AbiturientWindow.Abiturient.Speciality;
                    abiturient.Patronymic = AbiturientWindow.Abiturient.Patronymic;
                    db.SaveChanges();
                    ablist.Items.Refresh();
                }
            }
        }
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            Abiturient? abiturient = ablist.SelectedItem as Abiturient;
            if(abiturient is null) return;
            db.Abiturients.Remove(abiturient);
            db.SaveChanges();
        }
    }
}
