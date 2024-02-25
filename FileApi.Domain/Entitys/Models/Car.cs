using FileApi.Domain.Entitys.Enums;

namespace FileApi.Domain.Entitys.Models
{
    public class Car
    {
        public int Id { get; set; }
        public ModelEnum Model { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long Year { get; set; }
    }
}
