﻿using System;
using System.Collections.ObjectModel;
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
            LookWindow lookWindow = new LookWindow(new Abiturient
            {
                Id = abiturient.Id,
                FirstName = abiturient.FirstName,
                SecondName = abiturient.SecondName,
                Patronymic = abiturient.Patronymic,
                Speciality = abiturient.Speciality,
                Gender = abiturient.Gender,
                DateBirthday = abiturient.DateBirthday,
                Enrollment = abiturient.Enrollment,
                Nationality = abiturient.Nationality,
                PlaceLive = abiturient.PlaceLive,
                FinishSchool = abiturient.FinishSchool,
                AttestatRating = abiturient.AttestatRating,
                Snils = abiturient.Snils,
                Budget = abiturient.Budget,
                YearEntry = abiturient.YearEntry
            });
            if (lookWindow.ShowDialog() == true)
            {
                abiturient = db.Abiturients.Find(lookWindow.Abiturient.Id);
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
                Speciality = abiturient.Speciality,
                Gender = abiturient.Gender,
                Enrollment = abiturient.Enrollment,
                DateBirthday = abiturient.DateBirthday,
                Nationality = abiturient.Nationality,
                PlaceLive = abiturient.PlaceLive,
                FinishSchool = abiturient.FinishSchool,
                AttestatRating = abiturient.AttestatRating,
                InvalidScan = abiturient.InvalidScan,
                Snils = abiturient.Snils,
                Budget = abiturient.Budget,
                YearEntry = abiturient.YearEntry
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
                    abiturient.Gender = AbiturientWindow.Abiturient.Gender;
                    abiturient.DateBirthday = AbiturientWindow.Abiturient.DateBirthday;
                    abiturient.Enrollment = AbiturientWindow.Abiturient.Enrollment;
                    abiturient.Nationality = AbiturientWindow.Abiturient.Nationality;
                    abiturient.PlaceLive = AbiturientWindow.Abiturient.PlaceLive;
                    abiturient.FinishSchool = AbiturientWindow.Abiturient.FinishSchool;
                    abiturient.AttestatRating = AbiturientWindow.Abiturient.AttestatRating;
                    abiturient.Snils = AbiturientWindow.Abiturient.Snils;
                    abiturient.Budget = AbiturientWindow.Abiturient.Budget;
                    abiturient.InvalidScan = AbiturientWindow.Abiturient.InvalidScan;
                    abiturient.YearEntry = AbiturientWindow.Abiturient.YearEntry;
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

        private void CreateExcelfile(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Abiturient> abiturients = db.Abiturients.Local.ToObservableCollection();
            ExcelExport.CreateExcelfile(abiturients);

        }
    }
}
