using Npgsql;

internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Host=localhost;Port=5432;Database=MongoDb;User Id=postgres;Password=xushnud;";

        NpgsqlConnection connection = new NpgsqlConnection(connectionString);

        connection.Open();

        string query = "select * from Darslar";



        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($@"{reader.GetInt32(0)},{reader.GetString(1)}, {reader.GetDateTime(2)},{reader.GetInt32(3)}");
        }

        command.ExecuteNonQuery();

        Console.WriteLine("Databasega Muvofaqiyatli table yaratildi");


        connection.Close();
    }
}









































//string query = "create table Darslar(id serial, mavzu varchar(40),start_date date, students_count int)";

//Darslar table = new Darslar();

//table.mavzu = "Ado .Net";
//table.start_date = DateTime.Now;
//table.student_count = 25;

//IList<Darslar> datalar = new List<Darslar>()
//        {
//              new Darslar(){mavzu = "N11" , start_date = DateTime.Now, student_count = 20},
//              new Darslar(){mavzu = "N21" , start_date = DateTime.Now, student_count = 18},
//              new Darslar(){mavzu = "N30" , start_date = DateTime.Now, student_count = 14},
//        };



//string insertQuery = @$"insert into Darslar(mavzu, start_date, students_count)
//                            values('{table.mavzu}','{table.start_date}',{table.student_count})";

//string baseQuery = "insert into Darslar(mavzu, start_date, students_count) values";
//string query1 = string.Empty;
//for (int i = 0; i < datalar.Count; i++)
//{
//    baseQuery += $@"('{datalar[i].mavzu}','{datalar[i].start_date}', {datalar[i].student_count}),";

//    Console.WriteLine(baseQuery);
//}



//string basefiedString = baseQuery.Substring(0, baseQuery.Length - 1);
