using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _50_Homework
{
    public class Servesi
    {
        public static List<ProgrammingLanguage> ModelProgram()
        {
            var Programming = new List<ProgrammingLanguage>
            {
                new ProgrammingLanguage { Id = 1, Name_p = "C#" },
                new ProgrammingLanguage { Id = 2, Name_p = "Java" },
                new ProgrammingLanguage { Id = 3, Name_p = "C" },
                new ProgrammingLanguage { Id = 4, Name_p = "C#" },
                new ProgrammingLanguage { Id = 5, Name_p = "Go" },
                new ProgrammingLanguage { Id = 6, Name_p = "C#" },
                new ProgrammingLanguage { Id = 7, Name_p = "Python" },
                new ProgrammingLanguage { Id = 8, Name_p = "Java" },
                new ProgrammingLanguage { Id = 9, Name_p = "C#" },
                new ProgrammingLanguage { Id = 10, Name_p = "C" }


            };
            return Programming;
        }

        public static List<Buxgalters> ModelBugalter()
        {
            var Buxgalter = new List<Buxgalters>
            {
                new Buxgalters { Id = 1, Name_b = "Akromjon", Programming_id = 7},
                new Buxgalters { Id = 2, Name_b = "Tohirjon", Programming_id = 4},
                new Buxgalters { Id = 3, Name_b = "MuhammadAbdulloh", Programming_id = 8},
                new Buxgalters { Id = 4, Name_b = "Ozodbek", Programming_id = 3},
                new Buxgalters { Id = 5, Name_b = "Elyor", Programming_id = 5},
                new Buxgalters { Id = 6, Name_b = "Mahsud", Programming_id = 1},
                new Buxgalters { Id = 7, Name_b = "Xusan", Programming_id = 2},
                new Buxgalters { Id = 8, Name_b = "Xasan", Programming_id = 9},
                new Buxgalters { Id = 9, Name_b = "Abdulloh", Programming_id = 10},
                new Buxgalters { Id = 10, Name_b = "Abduxoliq", Programming_id = 6},
            };

            return Buxgalter;
        }

        public static void Task1()
        {
            var result = ModelProgram().Join(ModelBugalter(), p => p.Id, b => b.Programming_id, (p, b)
                    => new { p.Name_p, b.Name_b });

            foreach (var item in result)
            {
                Console.WriteLine(item.Name_b + " " + "->" + " " + item.Name_p);
            }
            Console.WriteLine();
        }

      
        public static void Task2(string Program_Name)
        {
            var result = ModelProgram().Join(ModelBugalter(), p => p.Id, b => b.Programming_id, (p, b)
                    => new { p.Name_p, b.Name_b }).Where(p => p.Name_p == Program_Name);

            foreach (var item in result)
            {
                Console.WriteLine(item.Name_b + " " + "->" + " " + item.Name_p);
            }
        }
    }
}
