using System;
using System.ComponentModel.DataAnnotations;

namespace ExamU1Alex.Entities
{
    public class TablaResponse
    {
        public int Numero { get; set; }
        public int Hasta { get; set; }
        public System.Collections.Generic.List<string> Tabla { get; set; } = new System.Collections.Generic.List<string>();
    }
}
