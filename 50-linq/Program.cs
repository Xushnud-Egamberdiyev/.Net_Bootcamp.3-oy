namespace _50_linq
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var Students = new List<Student>
            {
                new Student {
                    id = 1,
                    name = "John",
                    email = "john@gmail.com",
                    subject = new Subject[]
                    {
                        new Subject {id = 1, Name = "Math"},
                        new Subject {id = 2, Name = "Physics"},
                        new Subject {id = 3, Name = "Chemistry"}
                    }
                },

                new Student {
                    id = 2,
                    name = "Mary",
                    email = "mary@icloud.com",
                    subject = new Subject[]
                    {
                        new Subject {id = 1, Name = "Math"},
                        new Subject {id = 3, Name = "Chemistry"}
                    }
                },
                new Student {
                    id = 3,
                    name = "Peter",
                    email = "peter@yandex.ru",
                    subject = new Subject[]
                    {
                        new Subject {id = 2, Name = "Physics"},
                        new Subject {id = 3, Name = "Chemistry"}
                    }
                }

            };

            var SelectSubject = Students.SelectMany(s => s.subject).Select(s => s.Name).Distinct().OrderBy(s => s);


            //foreach (var item in SelectSubject)
            //{
            //    Console.WriteLine(item);
            //}


            //var SelectStudents = Students.Select((s, i) => new StudentShort
            //{
            //    order = i + 1,
            //    name = s.name,
            //    email = s.email,
            //});

            //foreach (var item in SelectStudents)
            //{
            //    await Console.Out.WriteLineAsync(item.order + item.email);
            //}





        }

    }
}
