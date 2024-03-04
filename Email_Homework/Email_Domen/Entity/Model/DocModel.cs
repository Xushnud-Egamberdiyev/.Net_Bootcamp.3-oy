using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Domen.Entity.Model
{
    public class DocModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Data { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }

    }
}
