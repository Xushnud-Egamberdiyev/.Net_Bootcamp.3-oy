namespace _43_Homeworkk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Homework homework = new Homework();

            //homework.Create_table("Darslar", "id Serial", "mavzu varchar(40) ","student_count int");

            //homework.One_Insert("Darslar", "mavzu", "student_count", "Ado . net", 25);

            //IList<Darslar_info> datalar = new List<Darslar_info>()
            //        {
            //              new Darslar_info(){mavzu = "MongoDb" , student_count = 20},
            //              new Darslar_info(){mavzu = "OOP" , student_count = 18},
            //              new Darslar_info(){mavzu = "DataBase" , student_count = 14},
            //        };

            //homework.Insert("Darslar", datalar);

            //homework.GetAll("Darslar");

            //homework.GetById("Darslar", 2);

            homework.Delete("Darslar", 3);




        }
    }
}
