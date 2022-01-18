using Application_Core.Models;
using System;
using System.Collections.Generic;

namespace Application_UI.ViewModels
{
    public class TeacherViewModel
    {
        public Guid Id { get; set; }
        public string TeacherName { get; set; }
        public int Age { get; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public string Degree { get; set; }

        public Guid GeneralId { get; set; }
        public ICollection<General> General { get; set; }
    }
}
