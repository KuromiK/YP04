using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Markup;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace YP04
{
    public class ExcelExport
    {
        public static void CreateExcelfile(ObservableCollection<Abiturient> data)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage abiturient = new ExcelPackage();
            ExcelWorksheet sheet = abiturient.Workbook.Worksheets.Add("Лист");
            string[] headers = { "ID", "Имя", "Фамилия", "Отчество", "Пол", "Дата рождения", "Возраст", "Гражданство", "Место проживания", "Образование", "Аттестат", "Снилс", "Специальность", "Форма обучения", "Зачисление", "Год поступления" };
            for (int i = 1; i <= headers.Length; i++)
            {
                sheet.Cells[1, i].Value = headers[i - 1];
            }
            int currString = 2;
            foreach (var person in data)
            {
                DateTime age = DateTime.Now;
                DateTime dates = DateTime.Parse(person.DateBirthday);
                int tmp = age.Year - dates.Year;
                if (dates > age.AddYears(0 - tmp))
                    tmp--;
                sheet.Cells[currString, 1].Value = person.Id;
                sheet.Cells[currString, 2].Value = person.FirstName;
                sheet.Cells[currString, 3].Value = person.SecondName;
                sheet.Cells[currString, 4].Value = person.Patronymic;
                sheet.Cells[currString, 5].Value = person.Gender;
                sheet.Cells[currString, 6].Value = person.DateBirthday;
                sheet.Cells[currString, 7].Value = tmp;
                sheet.Cells[currString, 8].Value = person.Nationality;
                sheet.Cells[currString, 9].Value = person.PlaceLive;
                sheet.Cells[currString, 10].Value = person.FinishSchool;
                sheet.Cells[currString, 11].Value = person.AttestatRating;
                sheet.Cells[currString, 12].Value = person.Snils;
                sheet.Cells[currString, 13].Value = person.Speciality;
                sheet.Cells[currString, 14].Value = person.Budget;
                sheet.Cells[currString, 15].Value = person.Enrollment;
                sheet.Cells[currString, 16].Value = person.YearEntry;
                currString += 1;
            }
            for (int i = 1; i <= headers.Length; i++)
            {
                sheet.Column(i).AutoFit();
            }
            string DRpath = "Reports";
            if (Directory.Exists(DRpath) == false)
            {
                Directory.CreateDirectory(DRpath);
            }
            string exportfile = "Report.xlsx";
            DRpath = System.IO.Path.Combine(DRpath, exportfile);
            if (File.Exists(DRpath))
                File.Delete(DRpath);
            FileStream objFileStrm = File.Create(DRpath);
            objFileStrm.Close();
            File.WriteAllBytes(DRpath, abiturient.GetAsByteArray());
            abiturient.Dispose();
        }
    }
}
