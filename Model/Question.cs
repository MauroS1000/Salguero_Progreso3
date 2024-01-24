using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salguero_Progreso3.Model
{

    public class Rootobject
    {
        public int response_code { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public string type { get; set; }
        public string difficulty { get; set; }
        public string category { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public string[] incorrect_answers { get; set; }
    }

}
