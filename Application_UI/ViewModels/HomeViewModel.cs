using Application_Core.Models;
using System.Collections.Generic;

namespace Application_UI.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Student> Students { get; set; }
        public ICollection<Parent> Parents { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
