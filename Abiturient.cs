﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace YP04
{
    public class Abiturient
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? Patronymic { get; set; }
        public string? Gender { get; set; }
        public string? DateBirthday { get; set; }
        public string? Nationality { get; set; }
        public string? PlaceLive { get; set; }
        public string? FinishSchool { get; set; }
        public double? AttestatRating { get; set; }
        public int? Snils { get; set; }
        public byte[]? InvalidScan { get; set; }
        public byte[]? OrphanScan { get; set; }
        public string? Speciality { get; set; }
        public byte[]? AttestatScan { get; set; }
        public string? Budget { get; set; }
        public string? Enrollment { get; set; }
        public int? YearEntry { get; set; }


    }
}
