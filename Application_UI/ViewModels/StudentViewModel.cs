using Application_Core.Models;
using System;
using System.Collections.Generic;

namespace Application_UI.ViewModels
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public DateTime Birthday { get; set; }

        public Guid ClassesId { get; set; }
        public ICollection<Classes> classes { get; set; }

        public Guid GeneralId { get; set; }
        public ICollection<General> General { get; set; }

        public Guid ParentId { get; set; }
        public ICollection<Parent> Parent { get; set; }
    }
}
