using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_Linq
{
    public class Student
    {
        public int id { get; set; }
        public string Name {  get; set; }
        public string Email { get; set; }
        public IEnumerable<Subject> subjects { get; set; }
    }
}
