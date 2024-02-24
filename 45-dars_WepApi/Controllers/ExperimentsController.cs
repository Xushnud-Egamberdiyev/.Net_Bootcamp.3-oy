using _45_dars_WepApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace _45_dars_WepApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExperimentsController : ControllerBase
    {
        const string connectionstring = "Server=127.0.0.1;Port=5432;Database=MongoDb;username=postgres;Password=xushnud;";

        [HttpGet]
        public List<Experement> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                string query = $"Select * from darslar;";
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                var x = command.ExecuteReader();

                List<Experement> list = new List<Experement>();

                while (x.Read())
                {
                    list.Add(new Experement()
                    {
                        Id = (int)x[0],
                        mavzu = (string)x[1],
                        student_count = (int)x[2]
                    });

                }

                return list;
            }
        }



        [HttpPost]
        public string Create(string mavzu, int student_count)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                string query = $"insert into darslar(mavzu, student_count) values(@mavzu, @student_count)";
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                command.Parameters.AddWithValue("mavzu", mavzu);
                command.Parameters.AddWithValue("student_count", student_count);

                int x = command.ExecuteNonQuery();

                if (x != 0)
                {
                    return "Malumot yaratildi";
                }
                return "Hech narsa qo'shilmadi";

            }
        }

        [HttpDelete]
        public string DeleteData(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                string query = $"Delete from darslar where id = {id}";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.ExecuteNonQuery();

                return $"{id}-Idli malumot ochirildi";
            }
        }

        [HttpPut]
        public string UpdateData(int id, string mavzu)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionstring))
            {
                string query = $"Update dars set mavzu = {mavzu} where id = {id}";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                return "Malumot yangilandi";

            }
        }

    }
}
