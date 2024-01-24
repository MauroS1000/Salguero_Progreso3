using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Salguero_Progreso3.Model
{
    internal class ResultModel
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }
    }
}
