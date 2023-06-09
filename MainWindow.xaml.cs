using System;
using System.Windows;
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
          //  AbiturientWindow abiturientWindow = new AbiturientWindow();
        }
        private void Edit_click(object sender, RoutedEventArgs e) 
        {
            Abiturient? abiturient = ablist.SelectedItem as Abiturient;
            if (abiturient is null) return;
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
