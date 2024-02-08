namespace _42_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new List<Student>
            {
                new Student {id = 1,
                    Name = "Xusan",
                    Email = "Xusan@gmail.com",
                    subjects = new Subject[]
                    {
                        new Subject {id = 1, name = "Math"},
                        new Subject {id = 2, name = "History"}
                    }
                },

                new Student {id = 2,
                    Name = "Xushnud",
                    Email = "Xushnud@gmail.com",
                    subjects = new Subject[]
                    {
                        new Subject {id = 5, name = "Math"},
                        new Subject {id = 3, name = "History"}
                    }

                
                },
                new Student {id = 3,
                    Name = "Mary",
                    Email = "Mary@gmail.com",
                    subjects = new Subject[]
                    {
                        new Subject {id = 4, name = "Geometry"},
                        new Subject {id = 6, name = "History"}
                    }
                }

            };

            var subjects = student.SelectMany(s => s.subjects).Distinct();

            var names = student.Select(s => new {s.Name, s.Email});

            foreach (var  name in subjects)
            {
                Console.WriteLine(name.id + name.name );
            }
        }
    }
}
