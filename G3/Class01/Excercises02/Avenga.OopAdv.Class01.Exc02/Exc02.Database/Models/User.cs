using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exc02.Database.Models
{
    public class User
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CorrectAnswers { get; set; }
        public bool HasFinishedTest { get; set; }
        public bool IsTeacher { get; set; }
    }
}
