namespace _50_linq
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int GradeId { get; set; }
        public IEnumerable<Subject> subject { get; set; }
    }
}
